using ChristmasLearningProject.Runtime.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace ChristmasLearningProject.Tests.Editor
{
    public class BoatTests
    {
        Boat sut;

        [SetUp]
        public void SetUp()
        {
            sut = Boat.Cristal();
        }

        [Test]
        public void MoveBoatTowardsDestination()
        {
            sut.SetRoute(Vector2.zero, Vector2.one);

            sut.Move(1);

            Assert.IsTrue(sut.Position.IsGreaterThan(Vector2.zero));
        }

        [Test]
        public void MoveBoatTowardsNegativeDirection()
        {
            sut.SetRoute(Vector2.zero, Vector2.one * -1);

            sut.Move(1);

            Assert.IsTrue(sut.Position.IsLessThan(Vector2.zero));
        }

        [Test]
        public void StopAfterReachingDestination()
        {
            sut.SetRoute(Vector2.zero, Vector2.one);

            sut.Move(10);

            Assert.AreEqual(Vector2.one, sut.Position);
        }

        [Test]
        public void MoveEvenly()
        {
            sut.SetRoute(Vector2.zero, Vector2.one);

            sut.Move(0.01f);
            var firstStepDistance = sut.Position;
            sut.Move(0.01f);
            var secondStepDistance = sut.Position;

            Assert.AreEqual(firstStepDistance - Vector2.zero, secondStepDistance - firstStepDistance);
        }

        [Test]
        public void RewindMovement()
        {
            sut.SetRoute(Vector2.zero, Vector2.one);

            sut.Move(0.01f);
            sut.Rewind(0.01f);

            Assert.AreEqual(Vector2.zero, sut.Position);
        }

        [Test]
        public void Position_IsNotClamped_DuringRewind()
        {
            sut.SetRoute(Vector2.zero, Vector2.one);

            sut.Rewind(1);

            Assert.IsTrue(sut.Position.IsLessThan(Vector2.zero));
        }

        [Test]
        public void PositionClamping_TakesIntoAccount_MovementDirection()
        {
            sut.SetRoute(Vector2.one, Vector2.zero);

            sut.Move(0.01f);

            Assert.IsTrue(sut.Position.IsGreaterThan(Vector2.zero));
        }

        [Test]
        public void ClampPosition_AfterReaching_Destination_InNegativeDirection()
        {
            sut.SetRoute(Vector2.one, Vector2.zero);

            sut.Move(10);

            Assert.AreEqual(Vector2.zero, sut.Position);
        }
    }
}