using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using UnityEngine;

namespace ChristmasLearningProject.Tests.Editor
{
    public class FleetTests
    {
        [Test]
        public void MoveAllBoatsOfFleet()
        {
            var firstBoat = Boat.WithRoute(Route.Between(Vector2.zero, Vector2.one));
            var secondBoat = Boat.WithRoute(Route.Between(Vector2.zero, Vector2.one));
            var sut = new Fleet();
            sut.Join(firstBoat);
            sut.Join(secondBoat);
            
            sut.Move(1);
            
            Assert.IsTrue(firstBoat.Position.IsGreaterThan(Vector2.zero));
            Assert.IsTrue(secondBoat.Position.IsGreaterThan(Vector2.zero));
        }
    }
}