using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smidge;
using Smidge.Options;
using Smidge.Cache;

namespace SmidgeApp.Web
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
            services.AddSmidge(Configuration.GetSection("smidge"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSmidge(bundle =>
            {
                bundle.CreateJs("my-js-bundle", "~/js/").WithEnvironmentOptions(BundleEnvironmentOptions.Create().ForDebug(builder => builder.EnableCompositeProcessing().EnableFileWatcher().SetCacheBusterType<AppDomainLifetimeCacheBuster>().CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0)).Build()); // Bý koda
                bundle.CreateCss("my-css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
            }); // Burda olmasý önemli

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

/*
 * bundle.CreateJs("my-js-bundle", "~/js/"): CreateJs metodu, my-js-bundle adýnda bir JavaScript paketi oluþturur. Bu paket, ~/js/ dizininde bulunan JavaScript dosyalarýný içerecek.

.WithEnvironmentOptions(...): WithEnvironmentOptions metodu, paketin derleme ortamýyla ilgili seçenekleri belirtmek için kullanýlýr. Devamýnda gelen kod bloðu, derleme ortamý seçeneklerini yapýlandýrýr.

BundleEnvironmentOptions.Create(): BundleEnvironmentOptions sýnýfýnýn Create statik metodu, bir derleme ortamý yapýlandýrmasý oluþturur.

.ForDebug(...): Bu yöntem, derleme ortamýný hata ayýklama (debug) modunda yapýlandýrmak için kullanýlýr. Ýçine gelen kod bloðu, hata ayýklama modu için özel seçenekleri yapýlandýrýr.

builder => builder.EnableCompositeProcessing().EnableFileWatcher().SetCacheBusterType<AppDomainLifetimeCacheBuster>().CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0): Bu kod bloðu, hata ayýklama modunda yapýlandýrma için kullanýlan seçenekleri belirtir.

EnableCompositeProcessing(): Bu seçenek, JavaScript dosyalarýný birleþtirme iþlemini etkinleþtirir. Yani, birden fazla dosyayý tek bir dosya haline getirir.
EnableFileWatcher(): Bu seçenek, dosya izleme özelliðini etkinleþtirir. Yani, kaynak dosyalarda yapýlan deðiþiklikleri algýlayarak otomatik olarak paketin güncellenmesini saðlar.
SetCacheBusterType<AppDomainLifetimeCacheBuster>(): Bu seçenek, önbelleði temizlemek için kullanýlan bir "cache buster" stratejisi belirtir. Burada AppDomainLifetimeCacheBuster kullanýlýyor, yani uygulama etki alaný ömrü boyunca önbelleði temizlemek için bir yöntem kullanýlýyor.
CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0): Bu seçenek, Cache-Control baþlýðýný yapýlandýrmak için kullanýlýr. enableEtag: false ile etag özelliðinin devre dýþý býrakýldýðýný, cacheControlMaxAge: 0 ile de önbellek süresinin sýfýr (anýnda süresi dolmuþ) olduðunu belirtir.
.Build(): Bu yöntem, yapýlandýrýlmýþ derleme ortamý seçeneklerini kullanarak bir derleme ortamý nesnesi oluþturur.*/
