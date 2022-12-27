using Microsoft.AspNetCore.Identity;

namespace CMS.UI.Models
{

    public class ApplicationUser:IdentityUser
     {
        public string FirstName {get;set;}
        public string LastName {get;set;} 
        public List<Post> Posts {get;set;}
    }


}