using ASP.Net_QuestRoom_App.AutoMapperProfiles;
using ASP.Net_QuestRoom_App.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(QuestRoomProfiles));
builder.Services.AddDbContext<QuestRoomContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("connStr")
    ?? throw new InvalidOperationException("Connection string not set!")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await SeedData.Initialize(serviceProvider, app.Environment);
}


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
    pattern: "{controller=QuestRooms}/{action=Index}/{id?}");

app.Run();
