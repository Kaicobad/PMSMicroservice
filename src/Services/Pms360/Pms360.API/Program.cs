var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var assembly = typeof(Program).Assembly;

//builder.Services.AddMediatR(config =>
//{
//    config.RegisterServicesFromAssembly(assembly);
//    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
//    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 //configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

