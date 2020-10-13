using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.ViewModel.Admin
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} max. {1} Karakter olmalı")]
        public string Username { get; set; }

        [DisplayName("Email"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} max. {1} Karakter olmalı"),
         EmailAddress(ErrorMessage = "{0} alanı için geçerli bir E-Posta adresi giriniz")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} Karakter olmalı")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} Karakter olmalı"),
         Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor")]
        public string RePassword { get; set; }
    }
}