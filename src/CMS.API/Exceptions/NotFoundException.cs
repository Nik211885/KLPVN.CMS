namespace CMS.API.Exceptions;

public class NotFoundException(string entity) : Exception($"Không tìm thấy {entity}");
