using BookManagement.Services.Dtos.PublisherDTO;
using BookManagement.Core.Repositories;
using BookManagement.Core.Models;
using AutoMapper;
using FluentValidation;
using System.Threading.Tasks;

namespace BookManagement.Services;

public interface IPublisherService
{
    Task<PublisherDTO> CreateAsync(PublisherCreateDTO dto);
    Task<PublisherDTO> UpdateAsync(PublisherUpdateDTO dto);
    Task<PublisherDTO> GetByIdAsync(int id);
    Task<List<PublisherDTO>> GetAllAsync();
    Task DeleteAsync(int id);
}