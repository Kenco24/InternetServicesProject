using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetServicesProj.Data.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Category")]
        public List<int> CategoryIds { get; set; }

        public List<Category> Categories { get; set; }

        public decimal Price {  get; set; }

        public int Quantity { get; set; }
    }
}
