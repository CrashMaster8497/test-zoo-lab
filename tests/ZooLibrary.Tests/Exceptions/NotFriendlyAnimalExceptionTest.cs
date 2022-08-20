using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests.Exceptions
{
    public class NotFriendlyAnimalExceptionTest
    {
        [Fact]
        public void ShouldThrowNotFriendlyAnimalException()
        {
            Assert.ThrowsAsync<NotFriendlyAnimalException>(() => throw new NotFriendlyAnimalException());
        }

        [Fact]
        public async void ShouldThrowNotFriendlyAnimalExceptionWithMessage()
        {
            var exception = await Assert.ThrowsAsync<NotFriendlyAnimalException>(() => throw new NotFriendlyAnimalException("message"));
            Assert.Equal("message", exception.Message);
        }
    }
}
