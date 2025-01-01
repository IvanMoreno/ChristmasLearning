using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Runtime.Domain.Route;
using static ChristmasLearningProject.Tests.Runtime.Do;
using static ChristmasLearningProject.Tests.Runtime.Fake;
using static ChristmasLearningProject.Tests.Runtime.Find;
using static ChristmasLearningProject.Tests.Runtime.LevelBuilder;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static ChristmasLearningProject.Tests.Runtime.Simulate;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class GameplayTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return FromLevelEditor().WithShieldBoatEnabled().Build();
        }
        
        [Test]
        public void Hide_WinScreen_OnStart()
        {
            Assert.IsNull(FindObjectOfType<WinScreen>());
        }

        [Test]
        public void CristalBoat_IsNotDeployed_OnStart()
        {
            Assert.IsNull(FindObjectOfType<CristalBoat>());
        }

        [UnityTest]
        public IEnumerator DeployCristalBoat_InDeparturePoint()
        {
            yield return SetDepartureIn(Vector2.one);
            var departurePoint = Input.mousePosition;
            yield return SetDestinationIn(Vector2.zero);

            Assert.AreEqual(InWorld(departurePoint), CristalBoat.position);
        }

        [UnityTest]
        public IEnumerator MoveCristalBoat_TowardsItsDestination()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 5, Vector2.zero));
            var destination = Input.mousePosition;

            yield return new WaitUntil(() => AreCloseEnough(CristalBoat, InWorld(destination)));

            Assert.IsTrue(AreCloseEnough(CristalBoat, InWorld(destination)));
        }
        
        [UnityTest]
        public IEnumerator FreezeCristalBoat_DuringPause()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 5, Vector2.zero));
            yield return ClickOn<PauseButton>();
            
            var cristalBoatPosition = PositionOf<CristalBoat>();
            yield return Tick();

            Assert.IsTrue(AreCloseEnough(CristalBoat, cristalBoatPosition));
        }

        [UnityTest]
        public IEnumerator ResumePause()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 5, Vector2.zero));
            yield return ClickOn<PauseButton>();
            
            var cristalBoatPosition = PositionOf<CristalBoat>();
            yield return ClickOn<PauseButton>();
            yield return Tick();

            Assert.IsFalse(AreCloseEnough(CristalBoat, cristalBoatPosition));
        }
        
        [UnityTest]
        public IEnumerator Win_ByDockingCristal_InHarbour()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 5, PositionOf<Harbour>()));

            yield return new WaitUntil(() => FindObjectOfType<WinScreen>() != null);

            Assert.IsNotNull(FindObjectOfType<WinScreen>());
        }

        [UnityTest]
        public IEnumerator CristalBoat_CanOnlyBeDeployed_Once()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 2, Vector2.one));
            yield return DeployCristalBoat(Between(Vector2.one * 2, Vector2.one));
            
            Assert.AreEqual(1, FindObjectsOfType<CristalBoat>().Length);
        }

        [UnityTest]
        public IEnumerator Deploy_ShieldBoat()
        {
            yield return DeployShieldBoat(Between(Vector2.down, Vector2.one));
            
            Assert.IsNull(FindObjectOfType<CristalBoat>());
            Assert.IsNotNull(FindObjectOfType<ShieldBoat>());
        }

        [UnityTest]
        public IEnumerator CanDeployTwoBoats()
        {
            yield return DeployCristalBoat(Between(Vector2.one * 2, Vector2.one));
            yield return DeployShieldBoat(Between(Vector2.down, Vector2.one));
            
            Assert.IsNotNull(FindObjectOfType<ShieldBoat>());
            Assert.IsNotNull(FindObjectOfType<CristalBoat>());
        }

        [UnityTest]
        public IEnumerator Rewind()
        {
            yield return SetDestinationIn(Vector2.one * 5);
            var departure = Input.mousePosition;
            yield return SetDestinationIn(Vector2.one);
            var destination = Input.mousePosition;
            
            yield return new WaitUntil(() => AreCloseEnough(CristalBoat, InWorld(destination)));
            yield return ClickOn<RewindButton>();
            yield return new WaitUntil(() => AreCloseEnough(CristalBoat, InWorld(departure)));
            
            Assert.IsTrue(AreCloseEnough(CristalBoat, InWorld(departure)));
        }

        static Transform CristalBoat => FindObjectOfType<CristalBoat>().transform;

        static bool AreCloseEnough(Transform theFirst, Vector2 destination, float distance = 0.05f) 
            => Vector2.Distance(theFirst.position, destination) < distance;
        
        static IEnumerator SetDepartureIn(Vector2 point)
        {
            yield return ClickInWorld(point);
        }

        static IEnumerator SetDestinationIn(Vector2 point)
        {
            yield return ClickInWorld(point);
        }
        
        static Vector3 InWorld(Vector2 screenPosition)
        {
            var toWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            toWorldPosition.z = 0;
            return toWorldPosition;
        }
    }
}