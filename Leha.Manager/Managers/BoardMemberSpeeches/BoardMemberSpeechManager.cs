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

    public async Task<List<BoardMemberSpeech?>> GetBoardMemberSpeechesListAsync()
    {
        return await _boardMemberSpeechRepository.GetTableNoTracking().ToListAsync();
    }
    public async Task<List<BoardMemberSpeech?>> GetBoardMemberSpeechesListByBoardMemberId(int boardMemberID)
    {
        return await _boardMemberSpeechRepository.GetBoardMemberSpeechesListByBoardMemberId(boardMemberID);

    }

    public async Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int boardMemberSpeechID)
    {
        return await _boardMemberSpeechRepository.GetByIdAsync(boardMemberSpeechID);
    }

    public async Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        return await _boardMemberSpeechRepository.AddAsync(boardMemberSpeech);
    }

    public async Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        return await _boardMemberSpeechRepository.UpdateAsync(boardMemberSpeech);
    }

    public async Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech)
    {
        return await _boardMemberSpeechRepository.DeleteAsync(boardMemberSpeech);

    }
    #endregion
}
