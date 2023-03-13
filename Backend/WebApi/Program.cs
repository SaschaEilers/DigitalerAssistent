using Neo4j.Driver;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables(source =>
{
    source.Prefix = "NEO4J";
});
UriBuilder uriBuilder = new();
builder.Configuration.Bind("NEO4J", uriBuilder);
builder.Services.AddNeo4j(CreateNeoUri(uriBuilder));

Console.WriteLine(uriBuilder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

static NeoSettings CreateNeoUri(UriBuilder builder)
{
    var user = builder.UserName;
    var password = builder.Password;
    builder.Password = string.Empty;
    builder.UserName = string.Empty;
    return new NeoSettings
    {
        Connection = builder.Uri,
        AuthToken = AuthTokens.Basic(user, password)
    };
}

