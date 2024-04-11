﻿namespace Leha.Core.Features.BoardMembers.Quaries.Results;

public class GetBoardMemberByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
}
