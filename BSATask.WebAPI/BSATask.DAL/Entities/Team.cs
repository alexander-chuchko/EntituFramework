namespace BSATask.DAL.Entities;

using Newtonsoft.Json;

public class Team : EntityBase
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
}

