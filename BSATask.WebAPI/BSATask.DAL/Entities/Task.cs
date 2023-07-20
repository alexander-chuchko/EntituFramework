namespace BSATask.DAL.Entities;

using Newtonsoft.Json;

public class Task : DAL.EntityBase
{
    [JsonProperty("projectId")] 
    public int ProjectId { get; set; }
    [JsonProperty("performerId")]
    public int PerformerId { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("state")]
    public TaskState State { get; set; }
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonProperty("finishedAt")]
    public DateTime? FinishedAt { get; set; }
}
