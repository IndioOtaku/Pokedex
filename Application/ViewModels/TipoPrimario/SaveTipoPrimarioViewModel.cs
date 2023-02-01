using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TipoPrimario
{
    public class SaveTipoPrimarioViewModel
    {
        public int idTipoPrimario { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del tipo")]
        public string Nombre { get; set; }
    }
}
