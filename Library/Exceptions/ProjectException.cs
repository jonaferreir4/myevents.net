using System.Net;

namespace Library.Exceptions
{
    public abstract class ProjectException(HttpStatusCode statusCode, IList<string> errorMessages) : Exception(string.Join("; ", errorMessages))
{
        public int StatusCode { get; } = (int)statusCode;
        public IList<string> ErrorMessages { get; } = errorMessages;

        protected ProjectException(HttpStatusCode statusCode, string errorMessage)
        : this(statusCode, [errorMessage]) { }
}
}