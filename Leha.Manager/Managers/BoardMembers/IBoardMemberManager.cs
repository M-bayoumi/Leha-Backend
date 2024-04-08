using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMembers;

public interface IBoardMemberManager
{
    public IQueryable<BoardMember?> GetAll();
    public Task<BoardMember?> GetByIdAsync(int id);
    public Task<bool> AddAsync(BoardMember pm);
    public Task<bool> UpdateAsync(BoardMember pm);
    public Task<bool> DeleteAsync(BoardMember pm);
}
