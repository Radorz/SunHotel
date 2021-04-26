using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ViewModels
{
    public class ReservaAdminVM
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Fechaereserva { get; set; }
        public string Fechaepago { get; set; }


        public int? Huespedes { get; set; }
      
        public string TipoHabitacion { get; set; }

        public string pagototal { get; set; }




    }
}