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
    public ISingerRepoDal Singers { get; set; }
    public ISongRepoDal Songs { get; set; }
    public ISubscriberRepoDal Subscribers { get; set; }
    public DalManager(string connStr)
    {
        //ServiceCollection collecion =new ServiceCollection();
        //collecion
        
        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<MusicContext>(opt => opt.UseSqlServer(connStr));
        services.AddSingleton<MusicContext>();
        services.AddScoped<ISingerRepoDal, SingerRepo>();
        services.AddScoped<ISongRepoDal, SongRepo>();
        services.AddScoped<ISubscriberRepoDal,SubscriberRepo>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();

        Singers = servicesProvider.GetRequiredService<ISingerRepoDal>();
        Songs = servicesProvider.GetRequiredService<ISongRepoDal>();
        Subscribers = servicesProvider.GetRequiredService<ISubscriberRepoDal>();

    }

}
