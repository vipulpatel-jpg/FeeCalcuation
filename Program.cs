var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IFeeCalculator, FeeCalculator>();
var app = builder.Build();

// Force HTTPS redirection
app.UseHttpsRedirection();

// Add HSTS for production
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.MapControllers();
app.Run();
