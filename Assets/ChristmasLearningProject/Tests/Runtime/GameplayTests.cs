using System.Collections;
using System.Collections.Generic;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class GameplayTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
            yield return Do.ClickOn<ShieldBoatEditionButton>();
            yield return Do.ClickOn<ConfirmLevelEditionButton>();
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
            yield return SetDepartureIn(Vector2.one * 5);
            yield return SetDestinationIn(Vector2.zero);
            var destination = Input.mousePosition;

            yield return new WaitUntil(() => AreCloseEnough(CristalBoat, InWorld(destination)));

            Assert.IsTrue(AreCloseEnough(CristalBoat, InWorld(destination)));
        }

        [UnityTest]
        public IEnumerator Win_ByDockingCristal_InHarbour()
        {
            yield return SetDepartureIn(Vector2.one * 5);
            var harbourPosition = FindObjectOfType<Harbour>().transform.position;
            yield return SetDestinationIn(harbourPosition);

            yield return new WaitUntil(() => FindObjectOfType<WinScreen>() != null);

            Assert.IsNotNull(FindObjectOfType<WinScreen>());
        }

        [UnityTest]
        public IEnumerator CristalBoat_CanOnlyBeDeployed_Once()
        {
            yield return SetDepartureIn(Vector2.one * 2);
            yield return SetDestinationIn(Vector2.one);
            yield return SetDepartureIn(Vector2.one * 2);
            yield return SetDestinationIn(Vector2.one);
            
            Assert.AreEqual(1, FindObjectsOfType<CristalBoat>().Length);
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