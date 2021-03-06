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

    public partial class VolunteerLogin
    {
        public VolunteerLogin()
        {
            this.UserFroms = new HashSet<UserFrom>();
        }
    
        public int Serial { get; set; }
        [Required(ErrorMessage = "please fill up the  name")]
        
        [MinLength(3)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please fill up the  nid number")]
        
        [Display(Name = "Nid_number")]
        public int Nid_number { get; set; }
        [Required(ErrorMessage = "please fill up the mobile number")]
        
        [Display(Name = "Mobile_number")]
        public int Mobile_number { get; set; }
        [Required(ErrorMessage = "please fill up the  username")]
        
        [MinLength(3)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "please fill up the  password")]
        
        [MinLength(3)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "please fill up the  Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        
        public string Date { get; set; }
        public int Type { get; set; }
    
        public virtual ICollection<UserFrom> UserFroms { get; set; }
    }
}
