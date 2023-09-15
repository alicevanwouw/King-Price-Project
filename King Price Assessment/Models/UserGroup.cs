using System.Text.Json;

namespace King_Price_Assessment.Models
{
    public class UserGroup:AbstractModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<GroupPermission> Permissions { get; set; }

    }
}
