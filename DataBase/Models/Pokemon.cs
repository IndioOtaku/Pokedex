using DataBase.Models;
using System;
using System.Collections.Generic;

namespace DataBase
{
    public class Pokemon
    {
        public int idPokemon { get; set; }
        public string imgPokemon { get; set; }
        public string nombre { get; set; }
        public int RegionId { get; set; }
        //Navigation Property
        public Region Region { get; set; }
        public int TipoPrimarioId { get; set; }
        //Navigation Property
        public TipoPrimario TipoPrimario { get; set; }
        public int TipoSecundarioId { get; set; }
        //Navigation Property
        public TipoSecundario TipoSecundario { get; set; }
    }
}
