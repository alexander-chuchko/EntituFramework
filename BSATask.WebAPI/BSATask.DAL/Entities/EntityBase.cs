
using Newtonsoft.Json;

namespace BSATask.DAL
{
    public class EntityBase : IEntityBase
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
