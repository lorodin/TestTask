using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [Display(Name = "Ваше имя")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Длина имени должна быть больше 5 и меньше 13 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле обязательно к заполнению" )]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
         
    }
}