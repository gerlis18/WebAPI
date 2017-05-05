using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SugerencesPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }

        [Key, Column(Order = 1)]
        public int CategoriaId { get; set; }

        [Key, Column(Order = 2)]
        public int SugerenceId { get; set; }

        [Key, Column(Order = 3)]
        public int UserId { get; set; }
    }
}