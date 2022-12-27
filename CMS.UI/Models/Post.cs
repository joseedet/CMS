namespace CMS.UI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title {get;set;}
        
        public string ApplicationUserId {get;set;}
         public string Description {get;set;}
        public string Slug {get;set;}   
        public string ShortDescription{get;set;}
        public ApplicationUser Application{get;set;}
        public DateTime CreatedDate {get;set;}=DateTime.Now;
       
        


    }
    
}