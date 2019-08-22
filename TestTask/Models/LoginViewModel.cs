using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Вы не указали логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Вы не указали пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}