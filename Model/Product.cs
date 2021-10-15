using Model.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Product: IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public string Dimension { get; set; }
        
        [Required]
        public string Code { get; set; }
        public string Reference { get; set; }

        [Required]
        public int StockBalance { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}