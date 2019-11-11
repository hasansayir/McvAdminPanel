using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Side:BaseEntity
    {
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunludur")]
        [DisplayName("Taraf Adı")]
        public string Name { get; set; }
    }
}