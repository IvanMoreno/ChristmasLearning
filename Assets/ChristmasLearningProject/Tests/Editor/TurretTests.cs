using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Tests.Editor
{
    public class TurretTests
    {
        [Test]
        public void KillInvaderInRange()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            
            Assert.IsFalse(doc.IsAlive);
        }

        [Test]
        public void Attack_OnlyNearestInvader()
        {
            var sut = Turret.Ensemble(zero, up);
            var nearestBoat = Boat.WithRoute(Between(up, zero)).WithLives(1);
            var furthestBoat = Boat.WithRoute(Between(up * 2, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(nearestBoat, furthestBoat), deltaTime: 1f);
            
            Assert.IsFalse(nearestBoat.IsAlive);
            Assert.IsTrue(furthestBoat.IsAlive);
        }

        [Test]
        public void IgnoreFarAwayInvader()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up * Turret.MaxDetectionDistance * 2, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            
            Assert.IsTrue(doc.IsAlive);
        }

        [Test]
        public void IgnoreInvader_OutsideOfVisionAngle()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(down, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            
            Assert.IsTrue(doc.IsAlive);
        }

        [Test]
        public void WaitUntilReload_ToAttackAgain()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(2);
            
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            
            Assert.IsTrue(doc.IsAlive);
        }

        [Test]
        public void AttackAgain_AfterReload()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(2);
            
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            sut.Attack(Fleet.FromBoats(doc), deltaTime: Turret.ReloadSeconds);
            
            Assert.IsFalse(doc.IsAlive);
        }

        [Test]
        public void OnlyReload_AfterAttack()
        {
            var sut = Turret.Ensemble(zero, up);
            var doc = Boat.WithRoute(Between(up, zero)).WithLives(1);
            
            sut.Attack(Fleet.Empty(), deltaTime: 1f);
            sut.Attack(Fleet.FromBoats(doc), deltaTime: 1f);
            
            Assert.IsFalse(doc.IsAlive);
        }
        
        [Test]
        public void IgnoreDeadInvaders()
        {
            var sut = Turret.Ensemble(zero, up);
            var nearestBoat = Boat.WithRoute(Between(up, zero)).WithLives(1);
            var furthestBoat = Boat.WithRoute(Between(up * 2, zero)).WithLives(1);
            
            sut.Attack(Fleet.FromBoats(nearestBoat, furthestBoat), deltaTime: Turret.ReloadSeconds);
            sut.Attack(Fleet.FromBoats(nearestBoat, furthestBoat), deltaTime: Turret.ReloadSeconds);
            
            Assert.IsFalse(nearestBoat.IsAlive);
            Assert.IsFalse(furthestBoat.IsAlive);
        }
    }
}