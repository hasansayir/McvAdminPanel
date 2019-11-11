using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Contact :BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage ="Bu Alanı Doldurmak Zorunludur")]
        [DisplayName("Ad")]
        public string FiratName { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunludur")]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [StringLength(200), DisplayName("E Posta")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.EmailAddress,ErrorMessage ="xxx@yyy.com formatında olmalıdır")]
        public string Email { get; set; }

        [StringLength(200), DisplayName("Telefon")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.PhoneNumber, ErrorMessage = "90+")]
        public string Phone { get; set; }

    }
}