using BancoAtividades.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BancoAtividades.Context
{
    public class AtividadesContext : IAtividadesContext
    {
      public AtividadesContext(IConfiguration configuration)
        {
        var client = new MongoClient("mongodb+srv://spinheirolf:chg2UBq2y9AXHOzJ@bancomast.c4zvq1m.mongodb.net");

        var database = client.GetDatabase("MastAtividades");

        Atividades = database.GetCollection<IAtividadeReturn>("BaseAtividades");

      } 
       public IMongoCollection<IAtividadeReturn> Atividades { get; }
    }
}
