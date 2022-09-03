using Microsoft.EntityFrameworkCore;
using LoginDetailManagement.Data;
using LoginDetailManagement.Data.Repository;
using LoginDetailManagement.Entities;
using LoginDetailManagement.MappingProfile;
using LoginDetailManagement.Services;
using LoginDetailManagement.Services.interfaces;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
        .WriteTo.File(@"C:\logs\log.txt")
        .MinimumLevel.Error()
        .CreateLogger();

    Log.Information("Starting up");

    Serilog.Log.Information("Starting application");

    // Add services to the container.

    // For entity Framework
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Configuration.GetSection("EncripyStrings").Get<EncripyStrings>();

    builder.Services.AddAutoMapper(config =>
    {
        config.AddProfile(new MappingProfile());
    });

    builder.Services.AddHttpClient();
    builder.Services.AddScoped<HttpClient>();

    builder.Services.AddTransient<ILoginDetailRepository, LoginDetailRepository>();
    builder.Services.AddTransient<ILoginDetailService, LoginDetailService>();


    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.LoginDetailouting();

//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();
