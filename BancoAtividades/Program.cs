using BancoAtividades.Context;
using BancoAtividades.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

var connectionString = "mongodb+srv://spinheirolf:chg2UBq2y9AXHOzJ@bancomast.c4zvq1m.mongodb.net";
if (connectionString == null)
{
    Console.WriteLine("Ta sem senha?");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);

var collection = client.GetDatabase("MastAtividades").GetCollection<BsonDocument>("BaseAtividades");

var filter = Builders<BsonDocument>.Filter.Eq("id", 1);

var document = collection.Find(filter).First();

Console.Write(collection.ToString());

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAtividadesContext, AtividadesContext>();
builder.Services.AddScoped<IAtividadesRepository, AtividadesRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
