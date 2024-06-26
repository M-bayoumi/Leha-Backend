﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class UpdateCompanyCommandHandler : ResponseHandler, IRequestHandler<UpdateCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateCompanyCommandHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyDB = await _companyManager.GetByIdAsync(request.Id);
        if (companyDB == null) return NotFound<string>("");
        var company = _mapper.Map<Company>(request); // create a new object and fill it >> any field doesn't exist in requst will set by null 
        //var company = _mapper.Map(request, companyDB); // update companyDB by request fields >> any field doesn't exist in requst will set by old value 
        if (await _companyManager.UpdateAsync(company))
            return Created("");
        return BadRequest<string>("");
    }
    #endregion
}
