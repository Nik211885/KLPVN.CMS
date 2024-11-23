using KLPVN.Core.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KLPVN.Core.Helper;

public static class HttpContextHelper
{
  /// <summary>
  ///     Get value from form data have key is key
  /// </summary>
  /// <param name="context"></param>
  /// <param name="key"></param>
  /// <typeparam name="TValue"></typeparam>
  /// <returns>
  ///     Return specific object you want to deserialize
  /// </returns>
  public static List<TValue> GetValueFromData<TValue>(this HttpContext context, string key)
  {
    var formValues = new List<TValue>();
    var formFieldValues = context.Request.Form
      .Where(x => x.Key.ToString().Equals(key))
      .Select(x=>x.Value).FirstOrDefault();
    if (formFieldValues.Count > 0)
    {
      formValues.AddRange(formFieldValues
        .Select(JsonConvert.DeserializeObject<TValue>).OfType<TValue>());
    };
    return formValues;
  }
  /// <summary>
  ///     Get key and value in query string 
  /// </summary>
  /// <param name="context"></param>
  /// <returns>
  ///     Return list fields includes key and value in query string
  /// </returns>
  public static Search GetSearchInQueryString(this HttpContext context)
  {
    var search = new Search()
    {
      Fields = []
    };
    search.Fields.AddRange(context.Request.Query
      .Select(x
        => new Field(x.Key, x.Value.ToString())));
    return search;
  }
}
