using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Category
    {
        public int Id {get;set;}
        public string? Title{get;set;}

        [DataType(DataType.Date)]
        public DateTime CreatedDate{get;set;}








    }
}

