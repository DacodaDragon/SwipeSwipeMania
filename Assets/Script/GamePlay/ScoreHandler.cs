using SwipeSwipeMania;
using UnityEngine;

public delegate void JudgeDelegate(ArrowJudgement judgement);
public delegate void DirectionDelegate(ArrowDirection judgement);
public delegate void ScoreDelegate(float score);
public delegate void AccuracyDelegate(float accuracy);
public delegate void ComboDelegate(int  combo);
public delegate void ComboMilestoneDelegate(int milestone);
public delegate void ComboLossDelegate(int  comboloss);

public class ScoreHandler : DDOLSingleton<ScoreHandler>
{
    private Judgement judgement;
    [SerializeField]
    private int m_ComboMilestoneValue;
    private int m_ComboMilestoneNext = 0;
    private int m_ComboMilestoneCount = 0;
    private int m_Score;
    private int m_Combo;
    private float m_Acurracy;
    private ArrowJudgement m_LastJudgement;
    private ArrowDirection m_LastDirection;

    // *Bark*
    private JudgeDelegate m_OnJudgeEvent;
    private DirectionDelegate m_OnDirectionEvent;
    private ScoreDelegate m_OnScoreUpdateEvent;
    private AccuracyDelegate m_OnAccuracyUpdateEvent;
    private ComboDelegate m_onComboUpdateEvent;
    private ComboLossDelegate m_onComboLostEvent;
    private ComboMilestoneDelegate m_onComboMilestoneReached;

    // *Barfs out events*
    public event JudgeDelegate OnJudge { add { m_OnJudgeEvent += value; } remove { m_OnJudgeEvent -= value; } }
    public event DirectionDelegate OnDirection { add { m_OnDirectionEvent += value; } remove { m_OnDirectionEvent -= value; } }
    public event ScoreDelegate OnScoreUpdate { add { m_OnScoreUpdateEvent += value; } remove { m_OnScoreUpdateEvent -= value; } }
    public event AccuracyDelegate OnAccuracyUpdate { add { m_OnAccuracyUpdateEvent += value; } remove { m_OnAccuracyUpdateEvent -= value; } }
    public event ComboDelegate OnComboUpdate { add { m_onComboUpdateEvent += value; } remove { m_onComboUpdateEvent -= value; } }
    public event ComboLossDelegate OnComboLost { add { m_onComboLostEvent += value; } remove { m_onComboLostEvent -= value; } }
    public event ComboMilestoneDelegate OnComboMilestoneReached { add { m_onComboMilestoneReached += value; } remove { m_onComboMilestoneReached -= value; } }

    public void Start()
    {
        judgement = Judgement.Instance;
        m_ComboMilestoneNext = m_ComboMilestoneValue;
        m_Score = 0;
    }

    public void Evaluate(float delta, ArrowDirection direction)
    {
        m_LastJudgement = judgement.Judge(delta);
        m_Acurracy = judgement.JudgeScore(delta);
        m_LastDirection = direction;

        HandleCombo();

        m_Score += ((int)m_LastJudgement * 100) * m_Combo;

        Notify();
    }

    private void HandleCombo()
    {
        // Bad or miss
        if ((int)m_LastJudgement <= 1)
        {
            // Don't fire combo loss if we have no combo..
            if (m_Combo > 0)
            {
                m_onComboLostEvent?.Invoke(m_Combo);
                ResetMilestones();
            }
                     
            
            if (m_Combo > 0)
                m_Combo = 0;
            else m_Combo--;
        }
        else
        {
            if (m_Combo < 1)
                m_Combo = 1;
            else m_Combo++;

            if (m_Combo >= m_ComboMilestoneNext)
                IncrementMilestone();
        }
    }

    private void ResetMilestones()
    {
        m_ComboMilestoneNext = m_ComboMilestoneValue;
        m_ComboMilestoneCount = 0;
    }

    private void IncrementMilestone()
    {
        m_ComboMilestoneNext += m_ComboMilestoneValue;
        m_ComboMilestoneCount++;
        m_onComboMilestoneReached?.Invoke(m_ComboMilestoneCount);
    }

    private void Notify()
    {
        m_OnJudgeEvent?.Invoke(m_LastJudgement);
        m_OnDirectionEvent?.Invoke(m_LastDirection);
        m_OnScoreUpdateEvent?.Invoke(0);
        m_OnAccuracyUpdateEvent?.Invoke(m_Acurracy);
        m_onComboUpdateEvent?.Invoke(m_Combo);
    }

    public void Reset()
    {
        m_Score = 0;
        m_Combo = 0;
        m_Acurracy = 100;
        m_LastJudgement = ArrowJudgement.marvelous;
        m_LastDirection = ArrowDirection.none;
        judgement.Reset();
        ResetMilestones();
    }
}
