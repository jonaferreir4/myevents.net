using System.Net;
namespace Library.Exceptions;
public class NotFoundException : ProjectException
{
    public NotFoundException(string entityName, object key)
        : base(HttpStatusCode.NotFound, $"Entity \"{entityName}\" ({key}) was not found.") { }
}
