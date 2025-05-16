using Microsoft.Extensions.DependencyInjection.Extensions;
using ToDoList.Configuration;
using ToDoList.DatebaseAccess.DataProviders;
using ToDoList.DatebaseAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<IToDoItemDataProvider, ToDoItemDataProvider>();
builder.Services.AddSingleton<ICategory, CategoryDataProvider>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
