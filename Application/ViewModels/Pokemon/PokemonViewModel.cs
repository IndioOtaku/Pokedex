using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class PokemonViewModel
    {
        public int idPokemon { get; set; }
        public string imgPokemon { get; set; }
        public string nombre { get; set; }
        public string RegionName { get; set; }
        public int RegionId { get; set; }
        public string TipoPrimarioName { get; set; }
        public int TipoPrimarioId { get; set; }
        public string TipoSecundarioName { get; set; }
        public int TipoSecundarioId { get; set; }
    }
}
