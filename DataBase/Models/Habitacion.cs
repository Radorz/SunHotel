﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBase.Models
{
    public partial class Habitacion
    {
        public int Id { get; set; }
        public int IdTipoHabitacion { get; set; }
        public int IdEdificio { get; set; }
        public int NoHabitacion { get; set; }
    }
}
