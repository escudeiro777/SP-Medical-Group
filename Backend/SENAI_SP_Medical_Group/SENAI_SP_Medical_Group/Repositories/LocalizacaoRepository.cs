using MongoDB.Driver;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacao;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("spmed");
            //var database = client.GetDatabase("spmedgroup");
            _localizacao = database.GetCollection<Localizacao>("mapas");
        }
        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacao.InsertOne(novaLocalizacao);
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacao.Find(localizacao => true).ToList();
        }
    }
}
