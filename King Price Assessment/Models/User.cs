using System.Text.Json;
using System.Text.RegularExpressions;

namespace King_Price_Assessment.Models
{
    public class User:AbstractModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string[]? Groups { get; set; }
        public string? Email { get;set; }
        public string? PhoneNumber { get;set; }
        public DateTime CreatedAt { get; set; }
    }
}
