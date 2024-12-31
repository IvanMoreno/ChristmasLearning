using UnityEngine;

namespace ChristmasLearningProject.Tests.Runtime
{
    public static class Find
    {
        public static Vector2 PositionOf<T>() where T : MonoBehaviour
        {
            return Object.FindObjectOfType<T>().transform.position;
        }
    }
}