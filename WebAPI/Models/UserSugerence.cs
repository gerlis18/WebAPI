using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserSugerence
    {
        [Key, Column(Order = 0)]
        public int UserSugerenceId { get; set; }

        [Key, Column(Order = 1)]
        public int UserEId { get; set; }

        [Key, Column(Order = 2)]
        public int UserRId { get; set; }
    }
}