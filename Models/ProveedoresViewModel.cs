using BackendB.Entities;
using System.ComponentModel.DataAnnotations;
namespace ClienteAPI.Models
{
    public class ProveedoresViewModel
    {

        public ProveedoresViewModel()
        {
           
        }

        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "Digite el Nombre")]
        public string NombreProveedor { set; get; } = null!;

        [Required(ErrorMessage = "Digite el Correo")]
        public string Correo { set; get; } = null!;
        [Required(ErrorMessage = "Digite el Numero")]
        public string Numero { set; get; } = null!;

       
    }
}




    

