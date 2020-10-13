using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.ViewModel.Admin
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} max. {1} Karakter olmalı")]
        public string Username { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} Alanı boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} max. {1} Karakter olmalı"),
         DataType(DataType.Password)]
        public string Password { get; set; }
    }
}