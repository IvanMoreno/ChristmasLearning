using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public static class Compare
    {
        public static bool IsGreaterThan(this Vector2 theOne, Vector2 theOther)
        {
            return theOne.x > theOther.x || theOne.y > theOther.y;
        }
        
        public static bool IsLessThan(this Vector2 theOne, Vector2 theOther)
        {
            return theOne.x < theOther.x || theOne.y < theOther.y;
        }
    }
}