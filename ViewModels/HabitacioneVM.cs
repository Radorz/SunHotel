using DataBase.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ViewModels
{
    public  class HabitacioneVM
    {

        public int idtipo { get; set; }

        public string Nombre { get; set; }
       
        public string Descripcion { get; set; }
        public int? CantCamas { get; set; }
        public decimal? PrecioNoche { get; set; }
        public int? MaxHuespedes { get; set; }
        public List<string> photo { get; set; }
        public List<string> fechasocupadas { get; set; }


    }
}
