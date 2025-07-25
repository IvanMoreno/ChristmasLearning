using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Tests.Editor
{
    public class FleetTests
    {
        const float DeltaTime = 0.1f;
        
        [Test]
        public void MoveAllBoatsOfFleet()
        {
            var firstBoat = Boat.WithRoute(Between(zero, one));
            var secondBoat = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(firstBoat, secondBoat);
            
            sut.Move(DeltaTime);
            
            Assert.IsTrue(firstBoat.Position.IsGreaterThan(zero));
            Assert.IsTrue(secondBoat.Position.IsGreaterThan(zero));
        }

        [Test]
        public void RewindAFleet_AtStart_KeepsThemInDeparture()
        {
            var doc = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(doc);
            
            sut.Rewind(DeltaTime);
            
            Assert.IsTrue(doc.Position.Equals(zero));
        }

        [Test]
        public void RewindFleet_RewindsAllItsMembers()
        {
            var doc = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(doc);
            
            sut.Move(DeltaTime * 10);
            sut.Rewind(DeltaTime);
            
            Assert.IsTrue(doc.Position.IsLessThan(one));
        }

        [Test]
        public void RewindAllBoats_UntilAllOfThemReachedDeparture()
        {
            var firstBoat = Boat.WithRoute(Between(zero, one));
            var latterJoinedBoat = Boat.WithRoute(Between(zero, one));
            var sut = Fleet.FromBoats(firstBoat);
            
            sut.Move(DeltaTime);
            sut.Join(latterJoinedBoat);
            sut.Rewind(DeltaTime);
            
            Assert.IsTrue(latterJoinedBoat.Position.IsLessThan(zero));
            Assert.AreEqual(zero, firstBoat.Position);
        }
    }
}