using AutoMapper;
using MusicApp.Entities;
using MusicApp.Entities.Models;
using MusicApp.WebApi.DTO;

namespace MusicApp.WebApi.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ArtistModel, Artist>().ReverseMap();
            CreateMap<SongModel, Song>().ReverseMap();
            CreateMap<AlbumModel, Album>().ReverseMap();
            CreateMap<SignUpModel, ApplicationUser>()
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Email)
                    )
                 .ForMember(
                    dest => dest.PasswordHash,
                    opt => opt.MapFrom(src => src.Password)
                    )
                 .ReverseMap();

        }
    }
}
