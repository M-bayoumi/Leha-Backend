using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Posts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Posts.Commands.Handlers;

public class UpdatePostCommandHandler : ResponseHandler, IRequestHandler<UpdatePostCommand, Response<string>>
{

    #region Fields
    private readonly IPostManager _postManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdatePostCommandHandler(IPostManager postManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetByIdAsync(request.CompanyID);
        if (company != null)
        {
            var post = _mapper.Map<Post>(request);

            if (await _postManager.UpdateAsync(post))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
