using API.Extensions;
using FluentMigrator.Runner;
using IoC;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication();


// Configura a persistência
builder.Services.ConfigurePercisteceApp(builder.Configuration);

// Configuração explícita do HTTPS Redirection
builder.Services.AddHttpsRedirection(options => 
{
    options.HttpsPort = 7272; // Deve corresponder à porta HTTPS no launchSettings.json
});

// builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Migrações
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

// Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// Middlewares
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();