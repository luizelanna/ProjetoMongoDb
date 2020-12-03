using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProjetoMongoDb.Models
{
    public class InfectadoDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}