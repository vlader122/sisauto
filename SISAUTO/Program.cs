using DB;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.interfaces;
using Service;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<SisautoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SISAUTOConnection"));
});

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SisautoContext>();
//Repositorio
builder.Services.AddScoped<PaisesRepository>();
builder.Services.AddScoped<ClientesRepository>();
builder.Services.AddScoped<ServiciosRepository>();
builder.Services.AddScoped<OrdenesRepository>();
builder.Services.AddScoped<DetalleOrdenesRepository>();


//Servicio
builder.Services.AddScoped<PaisesService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<ServiciosService>();
builder.Services.AddScoped<OrdenesService>();
builder.Services.AddScoped<DetalleOrdenesService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http:://example.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SisautoContext>();
    context.Database.Migrate();
}

    // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapIdentityApi<IdentityUser>();

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
