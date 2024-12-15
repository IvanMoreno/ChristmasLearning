using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class GameplayTests
    {
        [UnityTest]
        public IEnumerator Hide_WinScreen_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(Object.FindObjectOfType<WinScreen>());
        }

        [UnityTest]
        public IEnumerator CristalBoat_IsNotDeployed_OnStart()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            Assert.IsNull(Object.FindObjectOfType<CristalBoat>());
        }
        
        [UnityTest]
        public IEnumerator DeployCristalBoat_InDeparturePoint()
        {
            yield return SceneManager.LoadSceneAsync("Level_0");

            yield return ClickInWorld(Vector2.one);
            var departurePoint = Input.mousePosition;
            yield return ClickInWorld(Vector2.zero);

            Assert.AreEqual(InWorld(departurePoint), Object.FindObjectOfType<CristalBoat>().transform.position);
        }

        static Vector3 InWorld(Vector2 screenPosition)
        {
            var toWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            toWorldPosition.z = 0;
            return toWorldPosition;
        }
    }
}