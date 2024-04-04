using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.BoardMemberSpeeches;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.BoardMemberSpeeches;

public class BoardMemberSpeechManager : IBoardMemberSpeechManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBoardMemberSpeechRepository _boardMemberSpeechRepository;
    #endregion

    #region Constructors
    public BoardMemberSpeechManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _boardMemberSpeechRepository = unitOfWork.BoardMemberSpeechRepository;
    }
    #endregion

    #region Handle Functions

    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListAsync()
    {
        return _boardMemberSpeechRepository.GetTableNoTracking();
    }

    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListByBoardMemberId(int boardMemberID)
    {
        return _boardMemberSpeechRepository.GetBoardMemberSpeechesListByBoardMemberId(boardMemberID);

    }

    public async Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int boardMemberSpeechID)
    {
        return await _boardMemberSpeechRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == boardMemberSpeechID);
    }

    public async Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        var boardMember = await _unitOfWork.BoardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == boardMemberSpeech.BoardMemberID);
        if (boardMember != null)
            return await _boardMemberSpeechRepository.AddAsync(boardMemberSpeech);
        return false;
    }

    public async Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        var boardMember = await _unitOfWork.BoardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == boardMemberSpeech.BoardMemberID);
        if (boardMember != null)
            return await _boardMemberSpeechRepository.UpdateAsync(boardMemberSpeech);
        return false;
    }

    public async Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        return await _boardMemberSpeechRepository.DeleteAsync(boardMemberSpeech);

    }
    #endregion
}
