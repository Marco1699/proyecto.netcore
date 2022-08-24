using BackendB.Entities;
using System.ComponentModel.DataAnnotations;
namespace ClienteAPI.Models

{
    public partial class ClienteViewModel
    {
        public ClienteViewModel()
        {
           
        }
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del cliente")]
        public string Cliente1 { get; set; } = null!;

        [Required(ErrorMessage = "Digite el Correo")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "Digite el Numero de contacto")]
        public string Numero { get; set; } = null!;

        
    }
}
