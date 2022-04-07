using DL;
using BL;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering our dependencies in Services container to be dep injected
//3 different lifecylce/how often they get recreated
//Scoped, Transient, Singleton
//Singleton means that for the entire application's lifetime it shares the one instance
//Scoped is that for every http request, the new instance is spun up
//Transient is for everytime it calls for the class, it spins a new instance up
builder.Services.AddScoped<IRepository>(ctx => new DBRepository(builder.Configuration.GetConnectionString("SLDB")));
builder.Services.AddScoped<ISLBL, SLBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
