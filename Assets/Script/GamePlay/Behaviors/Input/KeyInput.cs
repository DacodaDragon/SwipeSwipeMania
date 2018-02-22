using UnityEngine;

namespace SwipeSwipeMania
{
    public class KeyInput : MonoBehaviour
    {
        private OnDirectionalSwipe onDirectionalSwipe;
        public event OnDirectionalSwipe OnDirectionalSwipeEvent
        {
            add { onDirectionalSwipe += value; Debug.Log("Connect"); }
            remove { onDirectionalSwipe -= value; Debug.Log("Disconnect"); }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                onDirectionalSwipe?.Invoke(ArrowDirection.up);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                onDirectionalSwipe?.Invoke(ArrowDirection.down);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                onDirectionalSwipe?.Invoke(ArrowDirection.left);
            if (Input.GetKeyDown(KeyCode.RightArrow))
                onDirectionalSwipe?.Invoke(ArrowDirection.right);
        }
    }
}