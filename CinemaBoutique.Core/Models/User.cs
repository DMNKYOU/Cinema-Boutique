using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CinemaBoutique.Core.Models
{
    public class User: IdentityUser
    {
        //[PersonalData]
        //public string FirstName { get; set; }

        //[PersonalData]
        //public string LastName { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
