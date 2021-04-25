using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ViewModels
{
    public  class HabitacionVM
    {
        [Required(ErrorMessage = "Estilo de habitacion es requerido")]

        public int IdTipoHabitacion { get; set; }
        [Required(ErrorMessage = "El edificio es requerido")]

        public int IdEdificio { get; set; }
        [Required(ErrorMessage = "El numero de habitacion es requerido")]

        public int? NoHabitacion { get; set; }
        public List<ListHabitacionVM> list { get; set; }

        public int? eliminar { get; set; }
        public int? editar { get; set; }

    }
}
