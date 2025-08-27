using AutoMapper;
using BookManagement.Services.Dtos.BookDTO;
using BookManagement.Core.Models;

namespace BookManagement.Services.Helpers.Profiles.BookProfile;

public class BookProfile : Profile
{
    public BookProfile()
    {
        // 1. Base Mapping (Shared Properties)
        CreateMap<BookBaseDTO, Book>();
        CreateMap<Book, BookBaseDTO>();

        // 2. Create Mapping
        CreateMap<BookCreateDTO, Book>()
            .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.AuthorIds.Select(id => new BookAuthor { AuthorId = id })));

        // 3. Read Mapping (Output DTO)
        CreateMap<Book, BookDTO>()
            .ForMember(dest => dest.BookID, opt => opt.MapFrom(src => src.BookID))
            .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.AuthorId)));

        // 4. Update Mapping (Input DTO)
        CreateMap<BookUpdateDTO, Book>()
            .ForMember(dest => dest.BookID, opt => opt.MapFrom(src => src.BookID))
            .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.AuthorIds.Select(id => new BookAuthor { AuthorId = id })));
    }
}