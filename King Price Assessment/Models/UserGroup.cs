using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace King_Price_Assessment.Models
{
    public class UserGroup:AbstractModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        
    }
}
