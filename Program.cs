var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IFeeCalculator, FeeCalculator>();
var app = builder.Build();
app.MapControllers();
app.Run();
