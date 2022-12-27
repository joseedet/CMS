using CMS.UI.Data;
using CMS.UI.Models;
using Microsoft.AspNetCore.Identity;

namespace CMS.UI.Utilities
{
    public class DbInicializer:IIDbInicializer

    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly WebsiteRoles _websiteRoles=new WebsiteRoles();
       

        public DbInicializer(ApplicationDbContext context,
                UserManager<ApplicationUser>userManager,
                RoleManager<IdentityRole> roleManager)
        {
            _context=context;
            _userManager=userManager;
            _roleManager=roleManager;
            //_websiteRoles=_websiteRoles.Admin;
        }
        public void Inicialize()
        {
            if(!_roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAuthor)).GetAwaiter().GetResult();


                _userManager.CreateAsync(new ApplicationUser()               
                  {
                    FirstName="José",
                    LastName="Edet",
                    UserName="joseedet@gmail.com",
                    Email="joseedet@gmail.com",
                    
                
                 },"EdetYake68").Wait();   

                        /*   appu;pplicationUsers.FirstOrDefault(p=>p.Email=="joseedet@gmail.com");
                _userManager.UpdateSecurityStampAsync(usuario).Wait(); */
            } 

            var appUser = _context.ApplicationUsers.FirstOrDefault(x=>x.Email=="joseedet@gmail.com");
            
            if( appUser !=null)
            {
                _userManager.AddToRoleAsync(appUser, WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult();
            }

            //paginas
            
            var AboutPage=new Page()
            {
                Title="Acerca de",
                Slug="Acerca-de"
            };
            


            var ContactPage=new Page()
            {
                Title="Contacto",
                Slug="Contacto"
            };
            
            var PrivacityPolicyPage=new Page()
            {
                Title="Privacidad",
                Slug="Privacidad"
            };
            
            _context.Pages.Add(AboutPage);
            _context.Pages.Add(ContactPage);
            _context.Pages.Add(PrivacityPolicyPage);
            _context.SaveChanges();

        //Creamos lista de tipo Page

            var ListOfPages=new List<Page>()
            {
                new Page()
                {

                    Title="Acerca de",
                    Slug="Acerca-de"
                },
                new Page()
                {
                    Title="Contacto",
                    Slug="Contacto"
                },
                 new Page()
                {
                    Title="Privacidad",
                    Slug="Privacidad"
                } 
                
            } ;

            _context.AddRange(ListOfPages);
            _context.SaveChanges();
               
        }
    }
 }
  