using AutoMapper;
using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Services.Dtos.PublisherDTO;
using FluentValidation;

namespace BookManagement.Services.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<PublisherCreateDTO> _createValidator;
    private readonly IValidator<PublisherUpdateDTO> _updateValidator;

    public PublisherService(
        IPublisherRepository repository,
        IMapper mapper,
        IValidator<PublisherCreateDTO> createValidator,
        IValidator<PublisherUpdateDTO> updateValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<PublisherDTO> CreateAsync(PublisherCreateDTO dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var publisher = _mapper.Map<Publisher>(dto);

        var createdPublisher = await _repository.Create(publisher);

        return _mapper.Map<PublisherDTO>(createdPublisher);
    }

    public async Task<PublisherDTO> UpdateAsync(PublisherUpdateDTO dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var publisher = _mapper.Map<Publisher>(dto);

        var updatedPublisher = await _repository.Update(publisher);

        return _mapper.Map<PublisherDTO>(updatedPublisher);
    }

    public async Task<PublisherDTO> GetByIdAsync(int id)
    {
        var publisher = await _repository.GetById(id);
        return _mapper.Map<PublisherDTO>(publisher);
    }

    public async Task<List<PublisherDTO>> GetAllAsync()
    {
        var publishers = await _repository.GetAll();
        return _mapper.Map<List<PublisherDTO>>(publishers);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Delete(id);
    }
}