namespace SwipeSwipeMania
{
    public class BeatObserver
    {
        private OnBeatDelegate m_OnTrigger;
        private float m_nextMeasure;
        private float m_previousMeasure;
        private float m_measure;

        public event OnBeatDelegate OnTrigger { add { m_OnTrigger += value; } remove { m_OnTrigger -= value; }}

        public float Measure { get { return m_measure; } }

        public BeatObserver(float beatMeasure, float currentTime = 0)
        {
            m_measure         = beatMeasure;
            m_nextMeasure     = currentTime + beatMeasure;
            m_previousMeasure = currentTime;
        }

        public void Reset(float currentTime = 0)
        {
            m_nextMeasure = currentTime + m_measure;
            m_previousMeasure = currentTime;
        }

        public void Update(float timeInBeats)
        {
            CheckTimeForward(timeInBeats);
            CheckTimeBackward(timeInBeats);
        }

        private void CheckTimeForward(float timeInBeats)
        {
            if (timeInBeats > m_nextMeasure)
            {
                m_nextMeasure += m_measure;
                m_previousMeasure += m_measure;
                Trigger();
            }
        }

        private void CheckTimeBackward(float timeInBeats)
        {
            if (timeInBeats < m_previousMeasure)
            {
                m_nextMeasure -= m_measure;
                m_previousMeasure -= m_measure;
                Trigger();
            }
        }

        private void Trigger()
        {
            m_OnTrigger?.Invoke();
        }
    }
}