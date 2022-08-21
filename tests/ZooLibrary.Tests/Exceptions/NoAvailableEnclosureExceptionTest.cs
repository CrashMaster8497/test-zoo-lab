using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests.Exceptions
{
    public class NoAvailableEnclosureExceptionTest
    {
        [Fact]
        public void ShouldThrowNoAvailableEnclosureException()
        {
            Assert.ThrowsAsync<NoAvailableEnclosureException>(() => throw new NoAvailableEnclosureException());
        }

        [Fact]
        public async void ShouldThrowNoAvailableEnclosureExceptionWithMessage()
        {
            var exception = await Assert.ThrowsAsync<NoAvailableEnclosureException>(() => throw new NoAvailableEnclosureException("message"));
            Assert.Equal("message", exception?.Message);
        }
    }
}
