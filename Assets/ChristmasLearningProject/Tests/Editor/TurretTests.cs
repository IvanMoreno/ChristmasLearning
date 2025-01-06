using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Tests.Editor
{
    public class TurretTests
    {
        [Test]
        public void KillBoatInRange()
        {
            var sut = new Turret(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(doc));
            
            Assert.IsFalse(doc.IsAlive);
        }
    }
}