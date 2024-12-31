using System.Collections;
using UnityEngine;
using static ChristmasLearningProject.Tests.Runtime.Find;
using static ChristmasLearningProject.Tests.Runtime.MouseOperations;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Do
    {
        public static IEnumerator ClickOn<T>() where T : MonoBehaviour
        {
            ClickAt(PositionOf<T>());
            yield return null;
        }
    }
}