//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Midproject.Models.En
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AgencyLogin
    {
        public AgencyLogin()
        {
            this.VolunteerFroms = new HashSet<VolunteerFrom>();
        }
    
        public int Serial { get; set; }
        [Required(ErrorMessage = "Agent Name is required!")]

        [MinLength(3)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill up the Agency name")]
        
        [MinLength(3)]
        [Display(Name = "Agency_name")]
        public string Agency_name { get; set; }
        [Required(ErrorMessage = "please fill up the  Username")]
        
        [MinLength(3)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]

        [MinLength(3)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        
        [MinLength(3)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public int Type { get; set; }
    
        public virtual ICollection<VolunteerFrom> VolunteerFroms { get; set; }
    }
}
