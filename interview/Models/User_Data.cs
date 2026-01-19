using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace interview.Models
{
    public class User_Data
    {
        [Key]
        public int User_Id { get; set; }

        [DisplayNameAttribute("User Name")]
        [Required]
        public string User_Name { get; set; }
        [DisplayNameAttribute("Password")]
        [Required]
        public string User_password { get; set; }
        [DisplayNameAttribute("First Name")]
        [Required]
        public string User_First_Name { get; set; }
        [DisplayNameAttribute("Middle Name")]
        [Required]
        public string User_Middle_Name { get; set; }
        [DisplayNameAttribute("Last Name")]
        [Required]
        public string User_Last_Name { get; set; }
        [DisplayNameAttribute("Mobile No")]
        [Required]
        public int User_Mobile_No { get; set; }

    }
}
