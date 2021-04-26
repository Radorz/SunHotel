using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace ViewModels
{
    public class ReservaVM
    {
        [Required(ErrorMessage = "El Nombre es requerido")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]

        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Email  es requerido")]
        [EmailAddress(ErrorMessage = "Ingresa un Email valido")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Email",ErrorMessage =" Los Emails no coinciden")]
        [Required(ErrorMessage = "El Confirmar Email  es requerido")]

        public string RepeatEmail { get; set; }

        [Required(ErrorMessage = "La Cedula es requerida")]
        [StringLength(11,ErrorMessage ="La Cedula debe contener 11 digitos", MinimumLength = 10)]
        public string Cedula { get; set; }
        
        [Required(ErrorMessage = "El Telefono es requerido")]
        [StringLength(15, ErrorMessage = "El telefono debe contener 10 digitos", MinimumLength = 10)]
        //[Phone(ErrorMessage ="Debe ser un telefono valido")]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Solo se acepta numeros")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La fecha de llegada es requerida")]

        public DateTime? FechaLlegada { get; set; }
        [Required(ErrorMessage = "La fecha de salida es requerido")]

        public DateTime? FechaSalida { get; set; }
        [Required(ErrorMessage = "La cantidad de Adultos es requerido")]

        [Remote(action: "validatehuespedes", controller:"Home",AdditionalFields =("Niños,TipoHabitacion"))]
        public int? Adultos { get; set; }
        [Required(ErrorMessage = "La cantidad de Niños es requerido")]
        public int? Niños { get; set; }
        [Required(ErrorMessage = "Estilo de habitacion es requerido")]

        public string TipoHabitacion { get; set; }

  
    }
}