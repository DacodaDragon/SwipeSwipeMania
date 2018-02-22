using UnityEngine;

namespace SwipeSwipeMania
{
    public delegate void OnDirectionalSwipe(ArrowDirection direction);

    [RequireComponent(typeof(TouchListener))]
    public class TouchSurface : MonoBehaviour
    {
        private OnDirectionalSwipe m_OnDirectionalSwipe;
        private TouchListener      m_listener;
        private Vector2            m_TouchBeginPos;
        private bool               m_tracking;

        [SerializeField] private float distance = 1f;

        public event OnDirectionalSwipe OnDirectionalSwipeEvent { add { m_OnDirectionalSwipe += value; } remove { m_OnDirectionalSwipe -= value; } }


        private void Awake()
        {
            m_listener = GetComponent<TouchListener>();
            m_listener.onTouchPress += TouchStart;
            m_listener.onTouchRelease += TouchEnd;
        }

        private void LateUpdate()
        {
            if (m_listener.Selected && m_tracking)
            {
                m_listener.GetTouch();
                Debug.DrawLine(m_TouchBeginPos, m_listener.GetPreviousTouchPosition(), Color.black, 3);
                if (Vector2.Distance(m_TouchBeginPos, m_listener.GetPreviousTouchPosition()) > distance)
                    TouchEnd();
            }
        }

        private void TouchStart()
        {
            m_TouchBeginPos = m_listener.GetTouchPosition();
            m_tracking = true;
        }

        private void TouchEnd()
        {
            if (!m_tracking)
                return;

            Vector2 touchEndPos = m_listener.GetPreviousTouchPosition();
            float angle = Vector2DMath.GetAngleBetween(m_TouchBeginPos, touchEndPos);
            m_OnDirectionalSwipe?.Invoke(AngleToDirection(angle));
            m_tracking = false;
        }

        private ArrowDirection AngleToDirection(float angle)
        {
            if (angle > 315 || angle < 45)
                return ArrowDirection.up;
            if (angle >= 45 && angle <= 135)
                return ArrowDirection.left;
            if (angle >= 135 && angle <= 225)
                return ArrowDirection.down;
            if (angle >= 225 && angle <= 315)
                return ArrowDirection.right;
            return ArrowDirection.none;
        }
    }
}