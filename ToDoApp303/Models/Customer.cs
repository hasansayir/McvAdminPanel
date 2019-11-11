using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Customer :BaseEntity
    {
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunludur")]
        [DisplayName("Müşteri Adı")]
        public string Name { get; set; }

        [StringLength(50), DisplayName("E Posta")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.EmailAddress, ErrorMessage = "xxx@yyy.com formatında olmalıdır")]
        public string Email { get; set; }

        [StringLength(50), DisplayName("Telefon")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.PhoneNumber, ErrorMessage = "90+")]
        public string Phone { get; set; }

        [StringLength(50), DisplayName("Fax")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.PhoneNumber, ErrorMessage = "90+")]
        public string Fax { get; set; }

        [StringLength(100), DisplayName("Web Sayfası")] //Bu şekilde yan yana da yazabiliriz
        [DataType(DataType.Url, ErrorMessage = "Geçerli bir url Giriniz")]
        public string WebPage { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }
    }
}