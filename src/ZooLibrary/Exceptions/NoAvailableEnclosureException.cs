namespace ZooLibrary.Exceptions
{
    [Serializable]
    public class NoAvailableEnclosureException : Exception
    {
        public NoAvailableEnclosureException() { }
        public NoAvailableEnclosureException(string? message) : base(message) { }
    }
}
