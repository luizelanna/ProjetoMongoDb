using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjetoMongoDb.Data.Collections;
using ProjetoMongoDb.Models;

namespace ProjetoMongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto._id, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarInfectados(string id)
        {
            _infectadosCollection.DeleteOne(a=>a.Id == id);

            return Ok("Excluido com sucesso");
        }
    }
}//{5fc946d1f780f871ada7c8a2}