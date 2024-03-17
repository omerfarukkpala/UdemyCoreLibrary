using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMemoryCache();

            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting")); // Bu kod, IpRateLimitOptions sýnýfýnýn yapýlandýrma bölümünü ("IpRateLimiting") kullanarak IP sýnýrlama seçeneklerini yapýlandýrýr. Yapýlandýrma dosyasýnda belirli bir bölüm adý altýnda tanýmlanan IP sýnýrlama ayarlarý, bu seçeneklere yansýtýlýr.
            services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));

            //services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies")); // Bu kod, IpRateLimitPolicies sýnýfýnýn yapýlandýrma bölümünü ("IpRateLimitPolicies") kullanarak IP sýnýrlama politikalarýný yapýlandýrýr. Yapýlandýrma dosyasýnda belirli bir bölüm adý altýnda tanýmlanan IP sýnýrlama politikalarý, bu yapýlandýrmaya yansýtýlýr. 
            services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));

            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>(); // Bu kod, IIpPolicyStore arabirimini MemoryCacheIpPolicyStore sýnýfýna baðýmlýlýk olarak kaydeder. IIpPolicyStore, IP sýnýrlama politikalarýný saklamak ve yönetmek için kullanýlan bir arabirimdir. Bu durumda, bellek tabanlý depolama kullanýlarak IP sýnýrlama politikalarý saklanýr.
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); // Bu kod, IRateLimitCounterStore arabirimini MemoryCacheRateLimitCounterStore sýnýfýna baðýmlýlýk olarak kaydeder. IRateLimitCounterStore, IP sýnýrlama sayaçlarýný saklamak ve yönetmek için kullanýlan bir arabirimdir. Bu durumda, bellek tabanlý depolama kullanýlarak IP sýnýrlama sayaçlarý saklanýr.

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Bu kod, IHttpContextAccessor arabirimini HttpContextAccessor sýnýfýna baðýmlýlýk olarak kaydeder. IHttpContextAccessor, HTTP istekleri ve yanýtlarýyla ilgili bilgilere eriþmek için kullanýlýr. Bu baðýmlýlýk, IP sýnýrlama iþlemleri sýrasýnda mevcut HTTP isteðinin bilgisine eriþmek için kullanýlýr.

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseIpRateLimiting(); // Bu yukarda yazdýklarýmý kullanarak bir IP kýsýtlamasý ekleyecek.
            app.UseClientRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
