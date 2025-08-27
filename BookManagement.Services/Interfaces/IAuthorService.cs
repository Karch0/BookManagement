using AutoMapper;
using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Services.Dtos.AuthorDTO;

namespace BookManagement.Services;

public interface IAuthorService
{
    Task<AuthorDTO> CreateAsync(AuthorCreateDTO dto);
    Task<AuthorDTO> UpdateAsync(AuthorUpdateDTO dto);
    Task<AuthorDTO> GetByIdAsync(int id);
    Task<List<AuthorDTO>> GetAllAsync();
    Task DeleteAsync(int id);
}