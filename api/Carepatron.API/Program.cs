using Carepatron.ConfigServices;

var builder = WebApplication.CreateBuilder(args);

#region Services

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.RegisterCors();
services.RegisterMvc();
services.RegisterDatabaseContext();
services.RegisterMapper();
services.RegisterDInjection();
services.AddMemoryCache();

#endregion

#region Application

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.SeedDatabase();
app.UseStatusCodePages();
app.RegisterSslRequired();
app.RegisterMvcRouting();
app.Run();

#endregion