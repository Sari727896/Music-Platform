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
            //CreateMap<Singer, Dal.Do.Singer>();


            //CreateMap<Song, Dal.Do.Song>()
            //      .ForMember(dest => dest.SingerId, opt => opt.MapFrom(src => src.SingerId))
            //      .ForMember(dest => dest.Singer, opt => opt.Ignore());
            //CreateMap<Subscriber, Dal.Do.Subscriber>();
            CreateMap<Singer, Dal.Do.Singer>().ReverseMap();

            CreateMap<Song, Dal.Do.Song>()
      .ForMember(dest => dest.ComposerName, opt => opt.MapFrom(src => GetComposerName(src)))
      .ForMember(dest => dest.Description, opt => opt.MapFrom(src => GetDescription(src)))
      .ForMember(dest=>dest.ProcessorName, opt => opt.MapFrom(src => GetProcessorName(src)))
      .ForMember(dest=>dest.TheSongWriter, opt => opt.MapFrom(src => GetSongWriter(src)))
      .ReverseMap();


            //    .ForMember(dest => dest.Singer, opt => opt.MapFrom(src => MapSinger(src.SingerName)));

            //CreateMap<Dal.Do.Song,Song>();
            CreateMap<Subscriber, Dal.Do.Subscriber>();
            //Dal.Do.Singer MapSinger(string singerName)
            //{
            //    string[] nameParts = singerName.Split(' ');

            //    Dal.Do.Singer singer = new Dal.Do.Singer
            //    {
            //        FirstName = nameParts[0],
            //        LastName = nameParts[1]
            //    };

            //    return singer;
            //}
        }

        private string GetComposerName(Song song)
        {
            // החזרת ערך ריק או ערך קבוע
            return "Unknown";
        }
        private string GetDescription(Song song)
        {
            return "Unknown Song";
        }
        private string GetProcessorName(Song song)
        {
            // החזרת ערך ריק או ערך קבוע
            return "Unknown";
        }
        private string GetSongWriter(Song song)
        {
            // החזרת ערך ריק או ערך קבוע
            return "Unknown";
        }
    }

}
