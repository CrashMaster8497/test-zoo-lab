using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests.Exceptions
{
    public class NoAvailableSpaceExceptionTest
    {
        [Fact]
        public void ShouldThrowNoAvailableSpaceException()
        {
            Assert.ThrowsAsync<NoAvailableSpaceException>(() => throw new NoAvailableSpaceException());
        }

        [Fact]
        public async void ShouldThrowNoAvailableSpaceExceptionWithMessage()
        {
            var exception = await Assert.ThrowsAsync<NoAvailableSpaceException>(() => throw new NoAvailableSpaceException("message"));
            Assert.Equal("message", exception?.Message);
        }
    }
}
