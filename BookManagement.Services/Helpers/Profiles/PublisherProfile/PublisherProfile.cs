using AutoMapper;
using BookManagement.Services.Dtos.PublisherDTO;
using BookManagement.Core.Models;

namespace BookManagement.Services.Helpers.Profiles.PublisherProfile;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        // 1. Base Mapping (Shared Properties)
        CreateMap<PublisherBaseDTO, Publisher>();
        CreateMap<Publisher, PublisherBaseDTO>();

        // 2. Create Mapping
        CreateMap<PublisherCreateDTO, Publisher>();

        // 3. Read Mapping (Output DTO)
        CreateMap<Publisher, PublisherDTO>()
            .ForMember(dest => dest.PublisherID, opt => opt.MapFrom(src => src.PublisherID))
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.Books.Select(b => b.BookID)));

        // 4. Update Mapping (Input DTO)
        CreateMap<PublisherUpdateDTO, Publisher>()
            .ForMember(dest => dest.PublisherID, opt => opt.MapFrom(src => src.PublisherID));
    }
}