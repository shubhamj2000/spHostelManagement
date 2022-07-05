using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace spHostelManagement.Models
{
    public class spStudentModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }


        [EmailAddress(ErrorMessage = "Email is required.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }

    }
}