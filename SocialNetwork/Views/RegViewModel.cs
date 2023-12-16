using System.ComponentModel.DataAnnotations;
using System;
using System.Xml.Linq;

namespace SocialNetwork.Views
{
    public class RegViewModel
    {
        [Required(ErrorMessage = "Поле Login обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Login", Prompt = "Введите Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 4)]
        public string PassReg { get; set; }

        [Required(ErrorMessage = "Обязательно подтвердите пароль")]
        [Compare("PassReg", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль", Prompt = "Введите пароль повторно")]
        public string PassConfirm { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "ФИО", Prompt = "Введите Ф.И.О.")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле Месяц обязательно для заполнения")]
        [Display(Name = "Дата рождения", Prompt = "Дата рождения")]
        public DateTime UserData { get; set; }

        [Required(ErrorMessage = "Поле URL обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Ссылка на фото", Prompt = "Ссылка на фото")]
        public string Image { get; set; }
    }
}
