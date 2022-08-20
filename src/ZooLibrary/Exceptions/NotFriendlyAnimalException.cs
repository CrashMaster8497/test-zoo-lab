namespace ZooLibrary.Exceptions
{
    [Serializable]
    public class NotFriendlyAnimalException : Exception
    {
        public NotFriendlyAnimalException() { }
        public NotFriendlyAnimalException(string? message) : base(message) { }
    }
}
