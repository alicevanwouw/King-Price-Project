using System.Text.Json;

namespace King_Price_Assessment.Models
{
    public class Group:AbstractModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[]? Permissions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
