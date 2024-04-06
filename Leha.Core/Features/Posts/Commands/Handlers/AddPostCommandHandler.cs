using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Posts;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Handlers;


public class AddPostCommandHandler : ResponseHandler, IRequestHandler<AddPostCommand, Response<string>>
{

    #region Fields
    private readonly IPostManager _postManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddPostCommandHandler(IPostManager postManager, ICompanyManager companyManager, IMapper mapper)
    {
        _postManager = postManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var post = _mapper.Map<Post>(request);

            if (await _postManager.AddPostAsync(post))
                return Created("Post Added Successfully");
            return BadRequest<string>("Failed To Add Post");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
