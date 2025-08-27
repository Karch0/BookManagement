using AutoMapper;
using BookManagement.Services.Dtos.AuthorDTO;
using BookManagement.Core.Models;

namespace BookManagement.Services.Helpers.Profiles.AuthorProfile;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // 1. Base Mapping (Shared Properties)
        CreateMap<AuthorBaseDTO, Author>();
        CreateMap<Author, AuthorBaseDTO>();

        // 2. Create Mapping
        CreateMap<AuthorCreateDTO, Author>();

        // 3. Read Mapping (Output DTO)
        CreateMap<Author, AuthorDTO>()
            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.BookId)));

        // 4. Update Mapping (Input DTO)
        CreateMap<AuthorDTO, Author>()
            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
            .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.BookIds.Select(id => new BookAuthor { BookId = id })));

        // 5. Update Mapping (Update DTO)
        CreateMap<AuthorUpdateDTO, Author>();
    }
}