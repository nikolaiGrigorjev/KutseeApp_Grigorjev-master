using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KutseeApp_Grigorjev.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Oma nimi palun!!!...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Palun oma krutoi e-mail ")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Sa oled pozer kus on email... -_-")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Palun oma krutoi tel.number")]
        [RegularExpression(@"\+372.+", ErrorMessage = "Sa oled pozer kus on number... -_-")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tee oma vastus")]
        public bool? WillAttend { get; set; }

    }
}