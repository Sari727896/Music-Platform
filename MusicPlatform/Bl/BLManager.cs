using AutoMapper;
using BL.BlApi;
using Dal;
using Dal.DalApi;
using Dal.Dalimplementaion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class BLManager
{
    public ISingerRepoBl Singers { get;  }
    public ISongRepoBl Songs { get;  }
    public ISubscriberRepoBl Subscribers { get; }
    public BLManager(string connStr)
    {
        ServiceCollection services = new ServiceCollection();
     
        services.AddAutoMapper(typeof(AutoMapper.AutoMapperProfile));

        services.AddSingleton<DalManager>(x => new DalManager(connStr));
        services.AddScoped<ISingerRepoDal, SingerRepo>();
        services.AddScoped<ISongRepoDal, SongRepo>();
        services.AddScoped<ISubscriberRepoDal, SubscriberRepo>();

        ServiceProvider provider = services.BuildServiceProvider();  
   
        Singers = provider.GetRequiredService<ISingerRepoBl>();
        Songs = provider.GetRequiredService<ISongRepoBl>();
        Subscribers = provider.GetRequiredService<ISubscriberRepoBl>();

    }
}
