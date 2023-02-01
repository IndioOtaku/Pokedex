using Application.ViewModels.Region;
using Application.ViewModels.TipoPrimario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class SavePokemonViewModel
    {
        public int idPokemon { get; set; }

        [Required(ErrorMessage = "Debe colocar la url de la imagen del Pokémon")]
        public string imgPokemon { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del Pokémon")]
        public string nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la región a la que pertenece el Pokemón")]
        public int RegionId { get; set; }
        public List<RegionViewModel> Regiones { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el tipo primario al que pertenece el Pokemón")]
        public int idTipoPrimario { get; set; }
        public List<TipoPrimarioViewModel> TipoPrimario { get; set; }
        public int idTipoSecundario { get; set; }
        public List<TipoSecundarioViewModel> TipoSecundario { get; set; }
    }
}
