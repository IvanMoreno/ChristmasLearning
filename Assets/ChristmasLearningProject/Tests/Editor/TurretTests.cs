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
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(doc));
            
            Assert.IsFalse(doc.IsAlive);
        }

        [Test]
        public void Attack_OnlyNearestBoat()
        {
            var sut = Turret.Ensemble(zero, up);
            var nearestBoat = Boat.WithRoute(Between(up, zero)).WithLives(1);
            var furthestBoat = Boat.WithRoute(Between(up * 2, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(nearestBoat, furthestBoat));
            
            Assert.IsFalse(nearestBoat.IsAlive);
            Assert.IsTrue(furthestBoat.IsAlive);
        }
    }
}