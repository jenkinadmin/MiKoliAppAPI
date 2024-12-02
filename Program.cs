//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//        builder => builder.WithOrigins("http://localhost:3000")
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



//var app = builder.Build();
//app.UseCors("AllowReactApp");
// Configure the HTTP request pipeline.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("http://localhost:3000") // React app's URL
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors("AllowReactApp"); // Enable the CORS policy
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowReactApp");
app.MapControllers();
app.Run();



//app.MapControllers();

//app.Run();
