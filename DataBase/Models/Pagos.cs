using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBase.Models
{
    public partial class Pagos
    {
        public int IdPago { get; set; }
        public string Numero { get; set; }
        public string Titular { get; set; }
        public decimal? Cantidadpagar { get; set; }
    }
}
