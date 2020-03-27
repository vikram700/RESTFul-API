using System.ComponentModel.DataAnnotations;
namespace Supermarket.API.Resources
{
    public class SaveCategoryResource
    {
        [RequiredAttribute]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}