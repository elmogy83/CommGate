using CommGate.Data;
using CommGate.Web;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("ar-SA")
                    };
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

});
builder.Services.AddDbContextPool<ApplicationDBContext>(options =>
                           options.UseLazyLoadingProxies()
                           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddRazorPages()
    .AddViewLocalization();
builder.Services.AddMvc().AddDataAnnotationsLocalization(o =>
{
    o.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        return factory.Create(typeof(SharedResource));
    };
});


builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddSession();

builder.Services.AddElmah<SqlErrorLog>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
});
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseElmah();
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
