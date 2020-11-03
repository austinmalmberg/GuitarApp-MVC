using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarApp.Models
{
    public class BrowseUsersViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
    }
}