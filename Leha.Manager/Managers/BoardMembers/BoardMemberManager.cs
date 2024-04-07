using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.BoardMembers;

public class BoardMemberManager : IBoardMemberManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBoardMemberRepository _boardMemberRepository;
    #endregion

    #region Constructors
    public BoardMemberManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _boardMemberRepository = unitOfWork.BoardMemberRepository;
    }

    #endregion

    #region Handle Functions

    public IQueryable<BoardMember?> GetBoardMembersListAsync()
    {
        return _boardMemberRepository.GetTableNoTracking();
    }

    public async Task<BoardMember?> GetBoardMemberByIDAsync(int id)
    {
        return await _boardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x!.ID == id);
    }
    public Task<bool> AddBoardMemberAsync(BoardMember pm)
    {
        return _boardMemberRepository.AddAsync(pm);
    }

    public Task<bool> UpdateBoardMemberAsync(BoardMember pm)
    {
        return _boardMemberRepository.UpdateAsync(pm);
    }
    public async Task<bool> DeleteBoardMemberAsync(BoardMember pm)
    {

        var transaction = _boardMemberRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.BoardMemberSpeechRepository.GetBoardMemberSpeechesListByBoardMemberId(pm.ID).ToList();

            if (dms != null)
                await _unitOfWork.BoardMemberSpeechRepository.DeleteRangeAsync(dms);

            await _boardMemberRepository.DeleteAsync(pm);

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
    #endregion
}
