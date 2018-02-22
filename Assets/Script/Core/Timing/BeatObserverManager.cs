using System.Collections.Generic;

namespace SwipeSwipeMania.TimeManagement
{
    public class BeatObserverManager
    {
        private List<BeatObserver> m_Observers = new List<BeatObserver>();

        public void SubScribe(OnBeatDelegate function, float beatMeasure)
        {
            // Search for active BeatObserver
            for (int i = 0; i < m_Observers.Count; i++)
            {
                if (m_Observers[i].Measure == beatMeasure)
                {
                    m_Observers[i].OnTrigger += function;
                    return; 
                }
            }

            // Add new BeatObserver if there is none for the measure yet. 
            BeatObserver observer = CreateNewBeatObserver(beatMeasure);
            observer.OnTrigger += function;
        }

        private BeatObserver CreateNewBeatObserver(float beatMeasure)
        {
            BeatObserver observer = new BeatObserver(beatMeasure);
            m_Observers.Add(observer);
            return observer;
        }

        public void UnSubscribe(OnBeatDelegate function, float beatMeasure)
        {
            for (int i = 0; i < m_Observers.Count; i++)
            {
                if (m_Observers[i].Measure == beatMeasure)
                {
                    m_Observers[i].OnTrigger -= function;
                    return;
                }
            }
        }

        public void ResetAllListeners()
        {
            for (int i = 0; i < m_Observers.Count; i++)
            {
                m_Observers[i].Reset();
            }
        }

        public void Update(float timeInBeats)
        {
            for (int i = 0; i < m_Observers.Count; i++)
            {
                m_Observers[i].Update(timeInBeats);
            }
        }

        public void RemoveAllObservers()
        {
            m_Observers.Clear();
        }
    }
}