using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBase.Models
{
    public partial class Reserva 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int? Adultos { get; set; }
        public int? Niños { get; set; }
        public int? IdTipoHabitacion { get; set; }
        public int? IdHabitacion { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? IdPago { get; set; }
    }
}
