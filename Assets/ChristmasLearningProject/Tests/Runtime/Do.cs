using System.Collections;
using UnityEngine;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Do
    {
        public static IEnumerator ClickOn<T>() where T : MonoBehaviour
        {
            MouseOperations.ClickAt(Object.FindObjectOfType<T>().transform.position);
            yield return null;
        }
    }
}