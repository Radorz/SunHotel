using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]

        public string usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]

        public string Contraseña { get; set; }
    }
}
