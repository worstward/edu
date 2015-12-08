using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Edu.Models
{
    public class Enrollee
    {
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage="Некорректно введено имя")]   
        [Required(ErrorMessage="Введите имя")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage="Некорректно введена фамилия")]  
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Введите телефон")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage="Некорректно введен номер")]   
        public string Phone {get; set;}

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Некорректно введен адрес почты")]
        public string Email { get; set; }


    }
}