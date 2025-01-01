using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;

namespace ChristmasLearningProject.Tests.Editor
{
    public class GameTests
    {
        [Test]
        public void DisablePauseDuringRewind()
        {
            var sut = new Game();
            
            sut.Pause();
            sut.Rewind();
            
            Assert.IsFalse(sut.IsPaused);
        }
    }
}