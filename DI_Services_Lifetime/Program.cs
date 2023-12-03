using DI_Services_Lifetime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.

//3 types of services lifetime in Dependency Injection
// 1. Transient
// In this lifetime a new service will be created for every request
// 2. Scoped
// In this lifetime a service will be created once per request
// 3. Singleton
// In this lifetime a service will be created once per application. (another will be created when the application is restarted)
builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();

builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();

builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
