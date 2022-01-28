using PlanB.Data;
using PlanB.Data.Common;
using PlanB.Data.Common.Repositories;
using PlanB.Data.Models;
using PlanB.Data.Repositories;
using PlanB.Data.Seeding;
using PlanB.Services.Data;
using PlanB.Services.Mapping;
using PlanB.Services.Messaging;
using PlanB.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PlanB.Services.Data.Contracts;
using PlanB.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }).AddRazorRuntimeCompilation();

builder.Services.AddRazorPages().AddRazorPagesOptions(option =>
{
    option.Conventions.AddAreaPageRoute("Identity","/Accaunt/Manage","Index/id?");
});
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddSignalR();

builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();

builder.Services.AddTransient<IEmailSender, NullMessageSender>();
builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IMassagesService, MassagesService>();
builder.Services.AddTransient<IRecipesService, RecipesService>();

var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //dbContext.Database.EnsureDeleted();
    //dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();

    var services = serviceScope.ServiceProvider;

    await new ApplicationDbContextSeeder().SeedAsync(services);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHub<ChatHub>("/chat");
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });

app.Run();
