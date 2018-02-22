using UnityEngine;

namespace SwipeSwipeMania
{
    public delegate void ArrowViewportDelegate(Arrow arrow);

    [SerializeField]
    public class ArrowViewWindow
    {
        private ArrowViewportDelegate m_OnArrowEnter;
        private ArrowViewportDelegate m_OnArrowLeave;
        private float m_minTime = 0.25f;
        private float m_maxTime = -1;
        private int m_start;
        private int m_end;

        public int ViewStart { get { return m_start; } }
        public int ViewEnd { get { return m_end; } }
        public event ArrowViewportDelegate OnArrowEnter { add { m_OnArrowEnter += value; } remove { m_OnArrowEnter -= value; } }
        public event ArrowViewportDelegate OnArrowLeave { add { m_OnArrowLeave += value; } remove { m_OnArrowLeave -= value; } }

        public void Update(Arrow[] arrows, float[] times, float timeInBeats)
        {
            UpdateStartWindow(arrows, times, timeInBeats);
            UpdateEndWindow(arrows, times, timeInBeats);
        }

        private void UpdateStartWindow(Arrow[] arrows, float[] times, float timeInBeats)
        {
            if (m_start < times.Length)
            {
                if (timeInBeats - times[m_start] > m_maxTime)
                {
                    m_OnArrowEnter?.Invoke(arrows[m_start]);
                    m_start++;
                }
            }
        }

        private void UpdateEndWindow(Arrow[] arrows, float[] times, float timeInBeats)
        {
            if (m_end < times.Length)
            {
                if (timeInBeats - times[m_end] > m_minTime)
                {
                    m_OnArrowLeave?.Invoke(arrows[m_end]);
                    m_end++;
                }
            }
        }

        public void Reset()
        {
            m_start = 0;
            m_end = 0;
        }
    }
}