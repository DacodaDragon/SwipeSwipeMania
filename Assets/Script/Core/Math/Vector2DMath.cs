using UnityEngine;

namespace SwipeSwipeMania
{
    public static class Vector2DMath
    {
        public static float GetAngleBetween(Vector2 from, Vector2 to)
        {
            Vector2 AngleVector = from - to;
            float angle = Mathf.Atan2(AngleVector.y, AngleVector.x) * Mathf.Rad2Deg;
            angle += 90;
            if (angle < 0) angle += 360;
            return angle;
        }

        public static float GetAngle(Vector2 angleVector)
        {
            float angle = Mathf.Atan2(angleVector.y, angleVector.x) * Mathf.Rad2Deg;
            angle += 90;
            if (angle < 0) angle += 360;
            return angle;
        }

        public static Vector2 AngleToVector(float angle)
        {
            angle -= 90;
            return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
    }
}