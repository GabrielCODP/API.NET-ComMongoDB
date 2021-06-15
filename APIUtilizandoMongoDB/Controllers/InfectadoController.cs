using APIUtilizandoMongoDB.Data.Collections;
using APIUtilizandoMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUtilizandoMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        public IActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.InsertOne(infectado);

            return StatusCode(2001, "Infectado adicionado com sucesso");
        }

        [HttpGet]

        public IActionResult ObterInfectado()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        //[HttpPut]
        //public IActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        //{
        //    var infectados = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

        //    _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Infectado>.Update.Set("sexo",dto.Sexo));

        //    return Ok("Atualizado com sucesso");
        //}
    }
}
