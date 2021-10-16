using Model.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class User : IEntity
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
