using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMembers;

public interface IBoardMemberManager
{
    public Task<List<BoardMember?>> GetBoardMembersListAsync();
    public Task<BoardMember?> GetBoardMemberByIDAsync(int boardMemberID);
    public Task<bool> AddBoardMemberAsync(BoardMember boardMember);
    public Task<bool> UpdateBoardMemberAsync(BoardMember boardMember);
    public Task<bool> DeleteBoardMemberAsync(BoardMember boardMember);
}
