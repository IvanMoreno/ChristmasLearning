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

        [Test]
        public void FastForwardDisablesRewind()
        {
            var sut = new Game();
            
            sut.Rewind();
            sut.FastForward();
            
            Assert.IsFalse(sut.IsRewind);
        }
    }
}