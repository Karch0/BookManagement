using BookManagement.Services.Dtos.AuthorDTO;
using BookManagement.Core.Repositories;
using BookManagement.Core.Models;
using AutoMapper;
using FluentValidation;
using System.Threading.Tasks;

namespace BookManagement.Services.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<AuthorCreateDTO> _createValidator;
    private readonly IValidator<AuthorUpdateDTO> _updateValidator;

    public AuthorService(
        IAuthorRepository repository,
        IMapper mapper,
        IValidator<AuthorCreateDTO> createValidator,
        IValidator<AuthorUpdateDTO> updateValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<AuthorDTO> CreateAsync(AuthorCreateDTO dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var author = _mapper.Map<Author>(dto);

        var createdAuthor = await _repository.Create(author);

        return _mapper.Map<AuthorDTO>(createdAuthor);
    }

    public async Task<AuthorDTO> UpdateAsync(AuthorUpdateDTO dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var author = _mapper.Map<Author>(dto);

        var updatedAuthor = await _repository.Update(author);

        return _mapper.Map<AuthorDTO>(updatedAuthor);
    }

    public async Task<AuthorDTO> GetByIdAsync(int id)
    {
        var author = await _repository.GetById(id);
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task<List<AuthorDTO>> GetAllAsync()
    {
        var authors = await _repository.GetAll();
        return _mapper.Map<List<AuthorDTO>>(authors);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Delete(id);
    }
}