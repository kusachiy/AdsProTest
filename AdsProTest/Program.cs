using AdsProTest;
using AdsProTest.Data;
using AdsProTest.Services;

var builder = WebApplication.CreateBuilder(args);

var apiConfig = builder.Configuration.GetSection("ApiConfiguration").Get<ApiConfiguration>();
var ipServiceConfig = builder.Configuration.GetSection("IpServiceConfiguration").Get<IpServiceConfiguration>();


// Add services to the container.
builder.Services.AddSingleton<ApiConfiguration>(apiConfig);
builder.Services.AddSingleton<IpServiceConfiguration>(ipServiceConfig);
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<TrackedRequestService>();
builder.Services.AddScoped<IpService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
