namespace KLPVN.Core.Models;

/// <summary>
///    model save field in query string all any information for search
/// </summary>
public class Search
{
  public List<Field> Fields { get;init; }
}

public record Field(string Code, string Value);
