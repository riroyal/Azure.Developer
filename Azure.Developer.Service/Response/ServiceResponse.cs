namespace CDW.Developer.Service.Response
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T result)
        {
            Result = result;
        }

        public ServiceResponse(Exception exception)
        {
            ErrorMessages = new[] { exception.Message };
            Exception = exception;
        }

        public ServiceResponse(string errorMessage)
        {
            ErrorMessages = new[] { errorMessage };
        }

        public ServiceResponse(string[] errorMessage)
        {
            ErrorMessages = errorMessage;
        }

        public T Result { get; private set; }
        public IEnumerable<string> ErrorMessages { get; private set; }
        public bool HasError => ErrorMessages?.Any() ?? false;
        public string AggregatedErrorMessages => ErrorMessages
            ?.Aggregate((i, j) => i + Environment.NewLine + j);
        public Exception @Exception { get; private set; }

        public static implicit operator ServiceResponse<T>(T value) => new(value);
        public static implicit operator ServiceResponse<T>(Exception exception) => new(exception);
    }
}
