﻿using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Models;

public class DeleteProjectPhaseCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteProjectPhaseCommand()
    {

    }

    public DeleteProjectPhaseCommand(int iD)
    {
        Id = iD;
    }
}
