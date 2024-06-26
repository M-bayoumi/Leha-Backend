﻿using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.BoardMembers;

public class BoardMemberManager : IBoardMemberManager
{


    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBoardMemberRepository _boardMemberRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    #endregion

    #region Constructors
    public BoardMemberManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _boardMemberRepository = unitOfWork.BoardMemberRepository;
        _webHostEnvironment = webHostEnvironment;

    }
    #endregion

    #region Handle Functions
    public IQueryable<BoardMember?> GetAll()
    {
        return _boardMemberRepository.GetAll();
    }
    public async Task<BoardMember?> GetByIdAsync(int id)
    {
        return await _boardMemberRepository.GetByIdAsync(id);
    }
    public Task<bool> AddAsync(BoardMember pm)
    {
        return _boardMemberRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateAsync(BoardMember pm)
    {
        var oldImage = await _boardMemberRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _boardMemberRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteAsync(BoardMember pm)
    {
        var transaction = _boardMemberRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.BoardMemberSpeechRepository.GetAllByBoardMemberId(pm.Id).ToList();

            if (dms != null)
                await _unitOfWork.BoardMemberSpeechRepository.DeleteRangeAsync(dms);

            var oldImage = await _boardMemberRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

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
