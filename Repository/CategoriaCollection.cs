using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository
{
   
    public class CategoriaCollection : ICategoria
    {
        internal Mongod repo = new Mongod();
        private IMongoCollection<Categoria> collection;
        public CategoriaCollection()
        {
            collection = repo.db.GetCollection<Categoria>("categoria");

        }

        public async Task addCategoria(Categoria categoria)
        {
            await collection.InsertOneAsync(categoria);
        }

        public async Task deleteCategoria(string id)
        {
            var filter = Builders<Categoria>
                .Filter
                .Eq(x => x.id, id);
            await collection.DeleteOneAsync(filter);

        }

        public async Task<List<Categoria>> getAll()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categoria> getOne(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task updateCategoria(Categoria categoria)
        {
            var filter = Builders<Categoria>.Filter.Eq(x => x.id, categoria.id);
            await collection.ReplaceOneAsync(filter, categoria);

        }
    }  
}
