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
    public class ProductoCollection : IProducto
    {
        internal Mongod repo = new Mongod();
        private IMongoCollection<Producto> collection;

        public ProductoCollection()
        {
            collection = repo.db.GetCollection<Producto>("productos");
        }

        public async Task addProducto(Producto producto)
        {
            await collection.InsertOneAsync(producto);
        }

        public async Task deleteProducto(string id)
        {
            var filter = Builders<Producto>.Filter.Eq(x => x.id, id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<Producto> getProductoById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<Producto>> getProductos()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task updateProducto(Producto producto)
        {
            var filter = Builders<Producto>.Filter.Eq(k => k.id, producto.id);
            await collection.ReplaceOneAsync(filter, producto);
           /* var filter = Builders<Producto>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Producto>.Update
                .Set()

            */
        }
    }
}
