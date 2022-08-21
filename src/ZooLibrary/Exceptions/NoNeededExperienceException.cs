namespace ZooLibrary.Exceptions
{
    [Serializable]
    public class NoNeededExperienceException : Exception
    {
        public NoNeededExperienceException() { }
        public NoNeededExperienceException(string? message) : base(message) { }
    }
}
