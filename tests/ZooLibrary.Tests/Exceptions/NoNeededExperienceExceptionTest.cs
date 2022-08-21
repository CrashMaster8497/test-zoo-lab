using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests.Exceptions
{
    public class NoNeededExperienceExceptionTest
    {
        [Fact]
        public void ShouldThrowNoNeededExperienceException()
        {
            Assert.ThrowsAsync<NoNeededExperienceException>(() => throw new NoNeededExperienceException());
        }

        [Fact]
        public async void ShouldThrowNoNeededExperienceExceptionWithMessage()
        {
            var exception = await Assert.ThrowsAsync<NoNeededExperienceException>(() => throw new NoNeededExperienceException("message"));
            Assert.Equal("message", exception?.Message);
        }
    }
}
