using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

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
    }
}