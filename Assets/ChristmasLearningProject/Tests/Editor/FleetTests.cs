using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Tests.Editor
{
    public class FleetTests
    {
        [Test]
        public void MoveAllBoatsOfFleet()
        {
            var firstBoat = Boat.WithRoute(Between(zero, one));
            var secondBoat = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(firstBoat, secondBoat);
            
            sut.Move(1);
            
            Assert.IsTrue(firstBoat.Position.IsGreaterThan(zero));
            Assert.IsTrue(secondBoat.Position.IsGreaterThan(zero));
        }

        [Test]
        public void RewindAFleet_AtStart_KeepsThemInDeparture()
        {
            var doc = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(doc);
            
            sut.Rewind(1);
            
            Assert.IsTrue(doc.Position.Equals(zero));
        }

        [Test]
        public void RewindFleet_RewindsAllItsMembers()
        {
            var doc = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(doc);
            
            sut.Move(1);
            sut.Rewind(.1f);
            
            Assert.IsTrue(doc.Position.IsLessThan(one));
        }
    }
}