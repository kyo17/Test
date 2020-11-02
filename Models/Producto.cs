using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Producto
    {

        public Producto()
        {
            codigo = Guid.NewGuid();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonRequired]
        public string nombre { get; set; }

        public List<Categoria> categoria { get; set; } = new List<Categoria>();

        public Guid codigo { get; set; }
        [BsonRequired]
        public decimal precio { get; set; }
        [BsonRequired]
        public Boolean onStock { get; set; }
    }

}
