using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMembers;

public interface IBoardMemberManager
{
    public IQueryable<BoardMember?> GetBoardMembersListAsync();
    public Task<BoardMember?> GetBoardMemberByIDAsync(int id);
    public Task<bool> AddBoardMemberAsync(BoardMember pm);
    public Task<bool> UpdateBoardMemberAsync(BoardMember pm);
    public Task<bool> DeleteBoardMemberAsync(BoardMember pm);
}
