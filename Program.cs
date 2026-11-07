// File: Program.cs  (opravené DI – žádný lifetime konflikt)
using HomeControlBlazor.Authentication;
using HomeControlBlazor.Models;
using HomeControlBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWasmOrigin",
        p => p.WithOrigins("https://localhost:7169")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Blazor & Radzen
builder.Services.AddAuthenticationCore();
builder.Services.AddAuthorizationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// === EF Core ===
// a) klasický DbContext (Scoped) – pro služby, které ho píchají pøímo
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")));

// b) DbContextFactory – MUSÍ mít stejnou životnost (Scoped), jinak vznikne chyba
builder.Services.AddDbContextFactory<AppDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")),
    ServiceLifetime.Scoped // <<< klíèová zmìna
);

// Služby
builder.Services.AddScoped<IOTEService, OTEService>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IImageRespository, ImageRepository>();
builder.Services.AddScoped<IElectricityService, ElectricityService>();
builder.Services.AddScoped<IFVEService, FVEService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<IChatGPTService, ChatGPTService>();
//builder.Services.AddScoped(IToDoService, _ => new ToDoService()); // pøíklad
builder.Services.AddSingleton<GlobalStateService>();
builder.Services.AddScoped<IJSONService, JSONService>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddSingleton<StudentInfo>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowWasmOrigin");

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();





//using HomeControlBlazor.Authentication;
//using HomeControlBlazor.Models;
//using HomeControlBlazor.Services;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.Server;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.EntityFrameworkCore;
//using Radzen;
////using static HomeControlBlazor.Services.OTEService;

//var builder = WebApplication.CreateBuilder(args);

//// Add CORS services and define a policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowWasmOrigin",
//        policyBuilder => policyBuilder.WithOrigins("https://localhost:7169") // Specify the client app's origin
//                                      .AllowAnyMethod()
//                                      .AllowAnyHeader());
//});

//// Add services to the container.
//builder.Services.AddAuthenticationCore();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
//builder.Services.AddRadzenComponents();
//builder.Services.AddScoped<DialogService>();
//builder.Services.AddScoped<NotificationService>();
//builder.Services.AddScoped<TooltipService>();
//builder.Services.AddScoped<ContextMenuService>();
//builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")));
//builder.Services.AddScoped<IOTEService, OTEService>();
//builder.Services.AddScoped<IImageRespository, ImageRepository>();
//builder.Services.AddScoped<IElectricityService, ElectricityService>();
//builder.Services.AddScoped<IFVEService, FVEService>();
//builder.Services.AddScoped<IWeatherService, WeatherService>();
//builder.Services.AddScoped<ITemperatureService, TemperatureService>();
//builder.Services.AddScoped<IChatGPTService, ChatGPTService>();
//builder.Services.AddScoped<IToDoService, ToDoService>();
//builder.Services.AddSingleton<GlobalStateService>();
//builder.Services.AddScoped<IJSONService, JSONService>();

//builder.Services.AddScoped<ProtectedSessionStorage>();
//builder.Services.AddSingleton<UserAccountService>();
//builder.Services.AddSingleton<StudentInfo>();

////builder.Services.AddScoped<ProtectedSessionStorage>();
////builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
////builder.Services.AddScoped<CustomAuthenticationStateProvider > ();
////builder.Services.AddSingleton<UserAccountService>();
////builder.Services.AddScoped<AuthenticationStateProvider>(      p => p.GetService<CustomAuthenticationStateProvider>());
////builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
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

//app.UseRouting();

//app.UseCors("AllowWasmOrigin");

//app.MapControllers();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();
