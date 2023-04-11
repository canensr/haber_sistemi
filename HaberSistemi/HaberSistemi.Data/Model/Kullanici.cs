using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.DataContext.Model
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key] 
        public int ID { get; set; }
        [MaxLength(100,ErrorMessage ="Lütfen 100 karakterden fazla değer girmeyiniz.")]
        [Display(Name ="Ad Soyad")]
        public string AdSoyad { get; set; }
        [Display(Name = "E-mail")]
        [Required]
        [RegularExpression("", ErrorMessage = "Geçerli bir mail Adresi Giriniz!")]
        public string Email { get; set; }
        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(16, ErrorMessage = "Lütfen 16 karakterden fazla değer girmeyiniz.")]
        public string Sifre { get; set; }
        

        public DateTime KayitTarihi { get; set; }
        [Display(Name = "Aktif")]
        public bool Aktif { get; set; }
        public virtual Rol Rol { get; set; }
}
}
