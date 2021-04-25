using System;
using System.Collections.Generic;

#nullable disable

namespace ViewModels
{
    public  class EdificioVM
    {
   
        public int IdEdificio { get; set; }
        public string NumeroEdificio { get; set; }


        public List<EdificioVM> list { get; set; }

        public int? eliminar { get; set; }

        public int? editar { get; set; }


    }
}
