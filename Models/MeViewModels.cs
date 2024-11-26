using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    // Modelos devueltos por las acciones MeController.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}