using TestProject.AppServices;
using TestProject.AppServices.Infrastructure;
using TestProject.Database;
using TestProject.Database.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddPostgreSqlConnection();
builder.Services.AddAppServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(app.Configuration
    .GetSection("CorsSettings:PolicyName")
    .Get<string>());

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    Migrator.MigratePostgres(app.Configuration);
}

app.Run();