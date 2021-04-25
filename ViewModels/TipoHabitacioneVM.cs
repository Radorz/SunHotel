using DataBase.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ViewModels
{
    public  class TipoHabitacioneVM
    {

        public List<TipoHabitaciones> List{ get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La cantidad de camas es requerido")]
        public int? CantCamas { get; set; }
        [Required(ErrorMessage = "El Precio por Noche es requerido")]
        public decimal? PrecioNoche { get; set; }
        [Required(ErrorMessage = "La cantidad maxima de huespedes es requerido")]
        public int? MaxHuespedes { get; set; }
        [Required(ErrorMessage = "Las fotos del tipo de habitacion es requerido es requerido")]
        public List<IFormFile> photo { get; set; }

        public int? eliminar { get; set; }
        public int? editar { get; set; }

    }
}
