﻿using AutoMapper;
using BL.BlApi;
using BL.BlImplementaion;
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
    public ISingerRepoBl Singers { get; set; }
    public ISongRepoBl Songs { get; set; }
    public ISubscriberRepoBl Subscribers { get; set; }
    public BLManager(string connStr)
    {
        ServiceCollection services = new ServiceCollection();
     
        services.AddAutoMapper(typeof(AutoMapper.AutoMapperProfile));


        services.AddSingleton<DalManager>(x => new DalManager(connStr));
        services.AddScoped<ISingerRepoBl, SingerServiceBl>();
        services.AddScoped<ISongRepoBl, SongServiceBl>();
        services.AddScoped<ISubscriberRepoBl, SubscriberServiceBl>();

        ServiceProvider provider = services.BuildServiceProvider();  
   
        Singers = provider.GetRequiredService<ISingerRepoBl>();
        Songs = provider.GetRequiredService<ISongRepoBl>();
        Subscribers = provider.GetRequiredService<ISubscriberRepoBl>();
    }
}
