using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CurrencyConverter;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.Add(new PageRouteTransformerConvention(new KebabCaseParameterTransformer()));
        });

        builder.Services.Configure<RouteOptions>(options =>
        {
            options.AppendTrailingSlash = true;
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

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

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
