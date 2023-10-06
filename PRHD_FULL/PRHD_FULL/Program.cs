using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRDH_FULL;
using PRHD_FULL;
using PRHD_FULL.Data;
using PRHD_FULL.Repository;
using PRHD_FULL.Repository.IRepository;
using PRHD_FULL.Servicio;
using PRHD_FULL.Servicio.IServicio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default30",
        new CacheProfile()
        {
            Duration = 30
        });

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(option => option.AddPolicy("AllowWebapp",
                                   builder => builder.AllowAnyOrigin()
                                                     .AllowAnyHeader()
                                                     .AllowAnyMethod()));



builder.Services.AddResponseCaching();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddHttpClient<IFiledataser, Filedataser>();
builder.Services.AddScoped<IFiledataser, Filedataser>();
///
builder.Services.AddHttpClient<ILaboratoryTestRepositorio, LaboratoryTestRepositorio>();
builder.Services.AddScoped<ILaboratoryTestRepositorio, LaboratoryTestRepositorio>();

builder.Services.AddHttpClient<ICaseRepositorio, CaseRepositorio>();
builder.Services.AddScoped<ICaseRepositorio, CaseRepositorio>();


builder.Services.AddHttpClient<IFiledata, Filedata>();
builder.Services.AddScoped<IFiledata, Filedata>();

builder.Services.AddHostedService<Worker>();
            //.AddSingleton<IFiledata, Filedata>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
