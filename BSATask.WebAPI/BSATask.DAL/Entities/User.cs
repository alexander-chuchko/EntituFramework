namespace BSATask.DAL.Entities;

using Newtonsoft.Json;
public class User : EntityBase
{
    [JsonProperty("teamId")] 
    public int? TeamId { get; set; }
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    [JsonProperty("lastName")] 
    public string? LastName { get; set; }
    [JsonProperty("email")]
    public string? Email { get; set; }
    [JsonProperty("registeredAt")]
    public DateTime RegisteredAt { get; set; }
    [JsonProperty("birthDay")] 
    public DateTime BirthDay { get; set; }
}