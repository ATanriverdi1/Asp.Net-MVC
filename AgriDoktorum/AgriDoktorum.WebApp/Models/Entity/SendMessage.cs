using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class SendMessage : IEnumerable
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir numara giriniz")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adres")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi")]
        public string Email { get; set; }

        [Display(Name = "Ad-Soyad")]
        [Required(ErrorMessage = "Bu alan boş geçilemez"), StringLength(25)]
        public string Name { get; set; }

        [Display(Name="Mesaj")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Text { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}