using System.Text.Json;
using System.Text.RegularExpressions;

namespace King_Price_Assessment.Models
{
    public class User:AbstractModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public List<UserGroup> Groups { get; set; }
        public string? Image { get;set; }
        

    }
}
