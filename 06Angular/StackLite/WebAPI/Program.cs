using DL;
using DL.Entities;
using BL;
using Serilog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Host.UseSerilog(
    (ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("../logs/log.txt", rollingInterval: RollingInterval.Day)
);

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*")
                  .AllowAnyHeader();
        });
});


//Ensures that the JSON serialization uses PascalCasing in its keys
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding caching ability for endpoints
builder.Services.AddMemoryCache();

//Registering our dependencies in Services container to be dep injected
//3 different lifecylce/how often they get recreated
//Scoped, Transient, Singleton
//Singleton means that for the entire application's lifetime it shares the one instance
//Scoped is that for every http request, the new instance is spun up
//Transient is for everytime it calls for the class, it spins a new instance up

//If I were to use the DbContext created by ReverseEngineering(DB First approach), I'd set it up like this
// builder.Services.AddDbContext<StackLiteDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SLDB")));

//Code First approach
builder.Services.AddDbContext<SLDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SLDBPostgre")));
builder.Services.AddScoped<IRepository, EFRepo>();
// builder.Services.AddScoped<IRepository>(ctx => new DBRepository(builder.Configuration.GetConnectionString("SLDB")));
builder.Services.AddScoped<ISLBL, SLBL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
