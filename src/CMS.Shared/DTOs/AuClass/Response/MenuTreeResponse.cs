using Newtonsoft.Json;

namespace CMS.Shared.DTOs.AuClass.Response;

public class MenuTreeResponse
{
  public List<MenuResponse> Menu { get; set; } = [];
}

public class MenuResponse
{
  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public string? NameAction { get; set; }

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public string? Path { get; set; }

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public string? MenuName { get; set; }
  
  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public string? MenuCode { get; set; }

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public List<MenuResponse> MenuChild { get; set; } = [];
}
