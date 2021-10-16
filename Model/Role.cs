using Model.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Role: IEntity
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
