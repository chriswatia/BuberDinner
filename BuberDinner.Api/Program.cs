using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //Register App dependency Injection
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
