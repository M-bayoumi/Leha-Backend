using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.BoardMemberSpeeches;
using Leha.Infrastructure.UnitOfWorks;

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

    public IQueryable<BoardMemberSpeech?> GetAll()
    {
        return _boardMemberSpeechRepository.GetAll();
    }

    public IQueryable<BoardMemberSpeech?> GetAllByBoardMemberID(int id)
    {
        return _boardMemberSpeechRepository.GetAllByBoardMemberID(id);

    }

    public async Task<BoardMemberSpeech?> GetByIdAsync(int id)
    {
        return await _boardMemberSpeechRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(BoardMemberSpeech pm)
    {
        var dm = await _unitOfWork.BoardMemberRepository.GetByIdAsync(pm.BoardMemberID);
        if (dm != null)
            return await _boardMemberSpeechRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(BoardMemberSpeech pm)
    {
        var dm = await _unitOfWork.BoardMemberRepository.GetByIdAsync(pm.BoardMemberID);
        if (dm != null)
            return await _boardMemberSpeechRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(BoardMemberSpeech pm)
    {
        return await _boardMemberSpeechRepository.DeleteAsync(pm);
    }
    #endregion
}
