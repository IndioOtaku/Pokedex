using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Region
{
    public class SaveRegionViewModel
    {
        public int idRegion { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la región")]
        public string Nombre { get; set; }
    }
}
