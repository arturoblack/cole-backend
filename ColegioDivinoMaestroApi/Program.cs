using ColegioDivinoMaestroApi.MyDb.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string conectionString = "Data Source=IHR80PBAH23\\MSSQLSERVER1;Initial Catalog=CLSAE9DB;Integrated Security=True";
// agerbar base de datos
builder.Services.AddDbContext<MyDbContext>(
    options => options.UseSqlServer(conectionString)
 );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
