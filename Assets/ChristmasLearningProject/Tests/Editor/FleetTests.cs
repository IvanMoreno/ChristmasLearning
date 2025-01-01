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
            var doc = Boat.WithRoute(Route.Between(Vector2.zero, Vector2.one));
            var sut = new Fleet();
            sut.Join(doc);
            
            sut.Move(1);
            
            Assert.IsTrue(doc.Position.IsGreaterThan(Vector2.zero));
        }
    }
}