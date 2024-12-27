using EncryptedChat.Bll.Interfaces;
using EncryptedChat.Bll.Services;
using EncryptedChat.Bll.Services.Repositories;
using EncryptedChat.Data;
using EncryptedChat.Data.Entities;
using EncryptedChat.Server.Hubs;
using EncrytedChat.Bll.Services.Repositories;
using JsonFlatFileDataStore;

var path = $"..\\{Directory.GetCurrentDirectory()}\\DbJson\\";
var jsonFileCreated = false;

if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}

path += "eventDb.json";

if (!File.Exists(path))
{
    File.Create(path).Close();
    File.WriteAllText(path, "{}");
    jsonFileCreated = true;
}

path = $"..\\{Directory.GetCurrentDirectory()}\\Cache\\message_cache.txt";

if (!File.Exists(path))
{
    File.Create(path).Close();
}

// Configure the HTTP request pipeline.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
//builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddScoped<CryptoService>();

if (builder.Environment.IsProduction())
{
    builder.Services.AddScoped(serviceProvider => new DataStore(path, useLowerCamelCase: false));
    builder.Services.AddScoped<IRepository<User>, UserJsonRepository>();
}
else
{
    builder.Services.AddDbContext<EncryptedChatDbContext>();
    builder.Services.AddScoped<IRepository<User>, UserSqlRepository>();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.MapHub<ChatHub>("/chatHub");

app.Run();
