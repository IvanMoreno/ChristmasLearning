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
            yield return Do.ClickOn<ConfirmLevelEditionButton>();

            Assert.IsNull(Object.FindObjectOfType<ShieldBoatSelectionButton>());
        }
    }
}