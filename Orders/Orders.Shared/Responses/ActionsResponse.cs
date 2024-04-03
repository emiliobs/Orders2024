namespace Orders.Shared.Responses
{
    public class ActionsResponse<T>
    {
        public bool WasSuccess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }
    }
}
