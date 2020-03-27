using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Category
    {   
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product > Products { get; set; }
    }
}