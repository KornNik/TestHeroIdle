using UnityEngine;

namespace Helpers.Extensions
{
    public static class MathExtender
    {
        /// <summary>
        /// Is two numbers is approximately equal 
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static bool IsApproximatelyEqual(float firstValue, float secondValue)
        {
            if (Mathf.FloorToInt(firstValue) == Mathf.FloorToInt(secondValue))
            {
                return true;
            }
            return false;
        }
        public static Vector3 SetVectorCoordinates(Vector3 vector, float value)
        {
            vector.x = value;
            vector.y = value;
            vector.z = value;
            return vector;
        }
        public static bool IsVectorIsInfinit(Vector3 vector)
        {
            if (float.IsInfinity(vector.x) || float.IsInfinity(vector.y) || float.IsInfinity(vector.z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsInNeededDistance(Vector3 heading, float maxDistance)
        {
            if (heading.sqrMagnitude <= maxDistance * maxDistance)
            {
                return true;
            }
            else return false;
        }
        public static bool CalculateChances(float chances)
        {
            var random = Random.Range(1f, 100f);
            if (random <= chances)
            {
                return true;
            }
            return false;
        }
    }
}
