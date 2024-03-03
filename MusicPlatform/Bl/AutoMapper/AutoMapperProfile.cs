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
            CreateMap<Singer, Dal.Do.Singer>();

            _ = CreateMap<Song, Dal.Do.Song>();
                //.ForMember(dest => dest.Singer, opt => opt.MapFrom(src => MapSinger(src.SingerName)));

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


    }

}
