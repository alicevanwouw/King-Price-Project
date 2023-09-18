using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace King_Price_Assessment.Models
{
    public class Group:AbstractModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Permission>? Permissions { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
