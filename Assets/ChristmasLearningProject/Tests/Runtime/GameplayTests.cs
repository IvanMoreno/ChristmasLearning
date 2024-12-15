using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;
using static UnityEngine.Object;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class GameplayTests
    {
        [UnityTest]
        public IEnumerator Hide_WinScreen_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(FindObjectOfType<WinScreen>());
        }

        [UnityTest]
        public IEnumerator CristalBoat_IsNotDeployed_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(FindObjectOfType<CristalBoat>());
        }

        [UnityTest]
        public IEnumerator DeployCristalBoat_InDeparturePoint()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            yield return SetDepartureIn(Vector2.one);
            var departurePoint = Input.mousePosition;
            yield return SetDestinationIn(Vector2.zero);

            Assert.AreEqual(InWorld(departurePoint), CristalBoat.position);
        }

        [UnityTest]
        public IEnumerator MoveCristalBoat_TowardsItsDestination()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            yield return SetDepartureIn(Vector2.one);
            yield return SetDestinationIn(Vector2.zero);
            var destination = Input.mousePosition;

            yield return new WaitUntil(() => CristalBoat.position.Equals(InWorld(destination)));

            Assert.AreEqual(InWorld(destination), CristalBoat.position);
        }

        static Transform CristalBoat => FindObjectOfType<CristalBoat>().transform;

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