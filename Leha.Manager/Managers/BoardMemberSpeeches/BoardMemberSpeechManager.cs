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

    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListByBoardMemberId(int id)
    {
        return _boardMemberSpeechRepository.GetBoardMemberSpeechesListByBoardMemberId(id);

    }

    public async Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int id)
    {
        return await _boardMemberSpeechRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech pm)
    {
        var dm = await _unitOfWork.BoardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == pm.BoardMemberID);
        if (dm != null)
            return await _boardMemberSpeechRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech pm)
    {
        var dm = await _unitOfWork.BoardMemberRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == pm.BoardMemberID);
        if (dm != null)
            return await _boardMemberSpeechRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech pm)
    {
        return await _boardMemberSpeechRepository.DeleteAsync(pm);

    }
    #endregion
}
