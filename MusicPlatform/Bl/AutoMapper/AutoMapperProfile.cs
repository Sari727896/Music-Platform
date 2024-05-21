using AutoMapper;
using BL.Bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Singer, Dal.Do.Singer>().ReverseMap();

            CreateMap<Song, Dal.Do.Song>()
              .ForMember(dest => dest.ComposerName, opt => opt.MapFrom(src => GetComposerName(src)))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => GetDescription(src)))
              .ForMember(dest=>dest.ProcessorName, opt => opt.MapFrom(src => GetProcessorName(src)))
              .ForMember(dest=>dest.TheSongWriter, opt => opt.MapFrom(src => GetSongWriter(src)))
              .ReverseMap();

            CreateMap<Subscriber, Dal.Do.Subscriber>().ReverseMap();
            CreateMap<SubscriberSong, Dal.Do.SubscriberSong>().ReverseMap();
        }

        private string GetComposerName(Song song)
        {
            return "Unknown";
        }
        private string GetDescription(Song song)
        {
            return "Unknown Song";
        }
        private string GetProcessorName(Song song)
        {
            return "Unknown";
        }
        private string GetSongWriter(Song song)
        {
            return "Unknown";
        }
    }

}
