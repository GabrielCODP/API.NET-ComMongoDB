using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIUtilizandoMongoDB.Models
{
    public class InfectadoDto
    {

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public InfectadoDto(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
