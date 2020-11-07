using System.Collections.Generic;

namespace GuitarApp.Models
{
    public class BrowseUsersViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
    }
}