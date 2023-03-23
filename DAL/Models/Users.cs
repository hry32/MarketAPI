using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Users
    {              
                [Key]
                // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public int Id { get; set; }
                //  [Display(Name = "UserName")]
                public string UserName { get; set; }
                // [Display(Name = "City")]
                public string City { get; set; }

     }
    

}
