using BancoAtividades.Entities;
using MongoDB.Driver;

namespace BancoAtividades.Context
{
    public interface IAtividadesContext
    {
        IMongoCollection<IAtividadeReturn> Atividades { get; }
    }
}
