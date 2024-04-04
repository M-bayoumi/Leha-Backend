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

    public async Task<BoardMember?> GetBoardMemberByIDAsync(int boardMemberID)
    {
        return await _boardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x!.ID == boardMemberID);
    }
    public Task<bool> AddBoardMemberAsync(BoardMember boardMember)
    {
        return _boardMemberRepository.AddAsync(boardMember);
    }

    public Task<bool> UpdateBoardMemberAsync(BoardMember boardMember)
    {
        return _boardMemberRepository.UpdateAsync(boardMember);
    }
    public async Task<bool> DeleteBoardMemberAsync(BoardMember boardMember)
    {

        var transaction = _boardMemberRepository.BeginTransaction();
        try
        {
            var boardMemberSpeeches = _unitOfWork.BoardMemberSpeechRepository.GetBoardMemberSpeechesListByBoardMemberId(boardMember.ID).ToList();

            if (boardMemberSpeeches != null)
                await _unitOfWork.BoardMemberSpeechRepository.DeleteRangeAsync(boardMemberSpeeches);

            await _boardMemberRepository.DeleteAsync(boardMember);

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
