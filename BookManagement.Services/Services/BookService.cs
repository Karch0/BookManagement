using BookManagement.Services.Dtos.BookDTO;
using BookManagement.Core.Repositories;
using BookManagement.Core.Models;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Services.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<BookCreateDTO> _createValidator;
    private readonly IValidator<BookUpdateDTO> _updateValidator;

    public BookService(
        IBookRepository repository,
        IMapper mapper,
        IValidator<BookCreateDTO> createValidator,
        IValidator<BookUpdateDTO> updateValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<BookDTO> CreateAsync(BookCreateDTO dto)
    {
        // Validate input
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Map to entity
        var book = _mapper.Map<Book>(dto);

        // Save to repository
        var createdBook = await _repository.Create(book);

        // Map to DTO and return
        return _mapper.Map<BookDTO>(createdBook);
    }

    public async Task<BookDTO> UpdateAsync(BookUpdateDTO dto)
    {
        // Validate input
        var validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Map to entity
        var book = _mapper.Map<Book>(dto);

        // Update in repository
        var updatedBook = await _repository.Update(book);

        // Map to DTO and return
        return _mapper.Map<BookDTO>(updatedBook);
    }

    public async Task<BookDTO> GetByIdAsync(int id)
    {
        var book = await _repository.GetById(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task<List<BookDTO>> GetAllAsync()
    {
        var books = await _repository.GetAll();
        return _mapper.Map<List<BookDTO>>(books);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Delete(id);
    }
}