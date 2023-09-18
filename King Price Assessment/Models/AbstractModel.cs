using System.Text.Json;

namespace King_Price_Assessment.Models
{
    public abstract class AbstractModel
    {
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
