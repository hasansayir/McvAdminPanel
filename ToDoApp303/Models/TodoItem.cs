using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class TodoItem :BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunludur")]
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }

        [DisplayName("Kategori Adı")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } //Tabllo bağlantılarını yapıyoruz

        [StringLength(200)]
        [DisplayName("Dosya Eki")]
        public string Attachment { get; set; }

        [DisplayName("Departman Adı")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } //Tabllo bağlantılarını yapıyoruz

        [DisplayName("Taraf Adı")]
        public int? SideId { get; set; }
        //[ForeignKey("SideId")]
        public virtual Side Side { get; set; } //Tabllo bağlantılarını yapıyoruz

        [DisplayName("Müşteri Adı")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; } //Tabllo bağlantılarını yapıyoruz

        [DisplayName("Yönetici Adı")]
        public int? ManagerId { get; set; }
        public virtual Contact Manager { get; set; } //Tabloların bağlantılarını yapıyoruz


        [DisplayName("Organizatör Adı")]
        public int OrganizatorId { get; set; }
        public virtual Contact Organizator { get; set; } //Tabllo bağlantılarını yapıyoruz

        [DisplayName("Toplantı Tarihi")]
        [Required(ErrorMessage ="Tarih bilgisi zorunludur")]
        [DataType("datetime-local")]
        public DateTime MeetingDate { get; set; }

        [DisplayName("Planlanan Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur")]
        [DataType("datetime-local")]
        public DateTime PlannedDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur")]
        [DataType("datetime-local")]
        public DateTime FinishDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur")]
        [DataType("datetime-local")]
        public DateTime ReviseDate { get; set; }

        [DisplayName("Dönüşme Konusu")]
        public string ConversationSubject { get; set; }

        [DisplayName("Destekleyen Firma")]
        public string SupporterCompany { get; set; }


        [DisplayName("Destekleyen Doktor")]
        public string SupporterDoctor { get; set; }


        [DisplayName("Görüşme Katılımcı Sayısı")]
        public int ConversationAttendeeCount { get; set; }


        [DisplayName("Planlanan Organizasyon Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur")]
        [DataType("datetime-local")]
        public DateTime ScheduledOrganizationDate { get; set; }

        [DisplayName("Birleşme Konuları")]
        public string MaillingSubjects { get; set; }

        [DisplayName("Afiş Konuları")]
        public string PosterSubject { get; set; }

        [DisplayName("Afiş Sayısı")]
        public int PosterCount { get; set; }

        [DisplayName("Uzaktan Eğitim")]
        public string Elearning { get; set; }

        [DisplayName("Tarama Türleri")]
        public string TypeOfScans { get; set; }

        [DisplayName("Taramlardaki Aso Sayısı")] //Aso kandaki bir değerdir
        public string AsoCountInScans { get; set; }

        [DisplayName("Organizasyon Türleri")]
        public string TypesOfOrganization { get; set; }

        [DisplayName("Organizasyondaki Aso Sayısı")]
        public string AsoCountInOrganizations { get; set; }

        [DisplayName("Aşı Organizasyonları Türleri")]
        public string TypeOfVaccinationOrganizaition { get; set; }

        [DisplayName("Aşı Organizsayondaki Aso Sayısı")]
        public string AsoCountInVaccinationOrganization { get; set; }

        [DisplayName("Aşı İçin Tazminat Miktarı")]
        public string AmountOfCompansationForPoster { get; set; }

        [DisplayName("Kurumsal Verimlilik Raporu")]
        public string CorporateProductivityReport { get; set; }




    }
}