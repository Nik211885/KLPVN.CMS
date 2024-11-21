namespace KLPVN.Core.Models;

public record ApiTypes(List<ApiType> Types);

public record ApiType(string Key, string Uri);

