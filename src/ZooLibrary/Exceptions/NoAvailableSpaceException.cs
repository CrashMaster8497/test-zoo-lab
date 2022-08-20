namespace ZooLibrary.Exceptions
{
    [Serializable]
    public class NoAvailableSpaceException : Exception
    {
        public NoAvailableSpaceException() { }
        public NoAvailableSpaceException(string? message) : base(message) { }
    }
}
