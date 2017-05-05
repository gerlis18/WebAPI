using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Sugerence
    {
        public int SugerenceId { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public DateTime creacion { get; set; }
    }
}