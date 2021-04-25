using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ViewModels
{
    public  class PagoVM
    {

        [CreditCard(ErrorMessage ="No es una tarjeta valida")]
        public string numeracion { get; set; }
        [Required(ErrorMessage = "Titular es requerido")]
        public string titular { get; set; }
        [Required(ErrorMessage = "El mes es requerido")]
        public int fechavencimientoMes { get; set; }
        [Required(ErrorMessage = "El año es requerido")]

        public int fechavencimientoAño { get; set; }
        [Required(ErrorMessage = "CVV es requerido")]
        [MaxLength(3,ErrorMessage ="Ingresa los tres digitos de seguridad de la parte trasera")]
        [MinLength(3, ErrorMessage = "Ingresa los tres digitos de seguridad de la parte trasera")]

        public string CVV { get; set; }

        public decimal cantidadpagar { get; set; }




    }
}
