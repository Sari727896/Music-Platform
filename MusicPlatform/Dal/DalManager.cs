using Dal.DalApi;
using Dal.Dalimplementaion;
using Dal.Do;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public class DalManager
{
    public ISingerRepoDal SingersRepo { get; set; }
    public ISongRepoDal SongsRepo { get; set; }
    public ISubscriberRepoDal SubscribersRepo { get; set; }
    public DalManager(string connStr)
    {
        //ServiceCollection collecion =new ServiceCollection();
        //collecion

        ServiceCollection services = new ServiceCollection();
     
        services.AddSingleton<MusicContext>();
        services.AddScoped<ISingerRepoDal, SingerRepo>();
        services.AddScoped<ISongRepoDal, SongRepo>();
        services.AddScoped<ISubscriberRepoDal,SubscriberRepo>();
        services.AddDbContext<MusicContext>(opt => opt.UseSqlServer(connStr));
        ServiceProvider servicesProvider = services.BuildServiceProvider();

        SingersRepo = servicesProvider.GetRequiredService<ISingerRepoDal>();
        SongsRepo = servicesProvider.GetRequiredService<ISongRepoDal>();
        SubscribersRepo = servicesProvider.GetRequiredService<ISubscriberRepoDal>();

    }

}
