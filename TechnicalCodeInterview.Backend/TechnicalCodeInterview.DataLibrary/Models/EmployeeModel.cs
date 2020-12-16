using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechnicalCodeInterview.DataLibrary.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 character for the first name")]
        [MaxLength(50, ErrorMessage = "The max character that is allowed is only 50")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 character for the first name")]
        [MaxLength(50, ErrorMessage = "The max character that is allowed is only 50")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You need to enter at least 1 character for the first name")]
        [MaxLength(50, ErrorMessage = "The max character that is allowed is only 50")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
