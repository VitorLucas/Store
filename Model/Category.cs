using Model.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Category: IEntity
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }
        
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
