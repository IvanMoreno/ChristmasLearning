using System.Collections;
using ChristmasLearningProject.Runtime.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace ChristmasLearningProject.Tests.Runtime
{
    public class LevelEditorTests
    {
        [UnityTest]
        public IEnumerator ShieldBoat_IsNotAvailable_ByDefault()
        {
            yield return SceneManager.LoadSceneAsync("LevelEditor");
            MouseOperations.ClickAt(Object.FindObjectOfType<ConfirmLevelEditionButton>().transform.position);
            yield return null;

            Assert.IsNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }
    }
}