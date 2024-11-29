namespace CMS.API.Exceptions;

public class BadRequestException(List<string> errors) : Exception(string.Join("\r\n", errors));
