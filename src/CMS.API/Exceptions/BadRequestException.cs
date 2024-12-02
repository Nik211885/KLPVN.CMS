namespace CMS.API.Exceptions;

public class BadRequestException(string error) : Exception(error);
