using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class TipoPrimario
    {
        public int idTipoPrimario { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
