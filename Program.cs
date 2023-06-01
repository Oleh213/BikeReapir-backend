using BikeRepair_backend.BusinessLogic;
using BikeRepair_backend.Db;
using BikeRepair_backend.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ReportContext>();
builder.Services.AddScoped<IBikeReportActionsBL, BikeReportActionsBL>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllCors", builder =>
    {
        builder

        .WithOrigins()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .SetIsOriginAllowed(delegate (string requestingOrigin)
        {
            return true;
        }).Build();
    });
});

var app = builder.Build();
app.UseCors("AllowAllCors");

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

