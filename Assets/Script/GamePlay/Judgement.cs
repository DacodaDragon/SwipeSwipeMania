namespace SwipeSwipeMania
{

    public class Judgement : DDOLSingleton<Judgement>
    {
        [UnityEngine.SerializeField]
        private float m_Strictness = 0.75f;
        private int m_Marvelous = 0;
        private int m_Great = 0;
        private int m_Good = 0;
        private int m_Ok = 0;
        private int m_Bad = 0;
        private int m_Miss = 0;
        private int m_Total = 0;
        private float Percentage = 0;

        public float Strictness { get { return m_Strictness; } }

        public ArrowJudgement Judge(float deltaTime)
        {
            deltaTime = UnityEngine.Mathf.Abs(deltaTime);
            if (deltaTime < 0.1f  * m_Strictness) return ArrowJudgement.marvelous;
            if (deltaTime < 0.25f  * m_Strictness) return ArrowJudgement.great;
            if (deltaTime < 0.5f * m_Strictness) return ArrowJudgement.good;
            if (deltaTime < 0.75f  * m_Strictness) return ArrowJudgement.ok;
            if (deltaTime < 1f    * m_Strictness) return ArrowJudgement.bad;
            return ArrowJudgement.miss;
        }

        public float JudgeScore(float deltaTime)
        {
            ArrowJudgement judgement = Judge(deltaTime);
            switch (judgement)
            {
                case ArrowJudgement.miss: m_Miss++; break;
                case ArrowJudgement.bad: m_Bad++; break;
                case ArrowJudgement.ok: m_Ok++; break;
                case ArrowJudgement.good: m_Good++; break;
                case ArrowJudgement.great: m_Great++; break;
                case ArrowJudgement.marvelous: m_Marvelous++; break;
            }

            m_Total++;

            float newScoreValue = Percentage = ((((m_Marvelous * 5f) + (m_Great * 4f) + (m_Good * 3f) + (m_Ok * 2f) + (m_Bad)) / 5f) / m_Total) * 100f;

            return newScoreValue;
        }

        public JudgementScores GetJudgementScores()
        {
            return new JudgementScores(m_Marvelous, m_Great, m_Good, m_Ok, m_Bad, m_Miss, m_Total, Percentage);
        }

        public void Reset()
        {
            m_Marvelous = 0;
            m_Great = 0;
            m_Good = 0;
            m_Ok = 0;
            m_Bad = 0;
            m_Miss = 0;
            m_Total = 0;
        }
    }

    public struct JudgementScores
    {
        public readonly int Marvelous;
        public readonly int Great;
        public readonly int Good;
        public readonly int Ok;
        public readonly int Bad;
        public readonly int Miss;
        public readonly int Total;
        public readonly float Percentage;

        public JudgementScores(int Marvelous, int Great, int Good, int Ok, int Bad, int Miss, int Total, float Percentage)
        {
            this.Marvelous = Marvelous;
            this.Great = Great;
            this.Good = Good;
            this.Ok = Ok;
            this.Bad = Bad;
            this.Miss = Miss;
            this.Total = Total;
            this.Percentage = Percentage;
        }
    }
}