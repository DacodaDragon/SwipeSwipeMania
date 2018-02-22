using UnityEngine;

namespace SwipeSwipeMania
{
    // TODO Find a better way to handle this.. omfg x-x
    public class Hitcircle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_MilestoneFirst_1;
        [SerializeField] private ParticleSystem m_MilestoneFirst_2;
        [SerializeField] private ParticleSystem m_MilestoneSecond_1;
        [SerializeField] private ParticleSystem m_MilestoneSecond_2;
        [SerializeField] private ParticleSystem m_MilestoneThird_1;
        [SerializeField] private ParticleSystem m_MilestoneThird_2;
        [SerializeField] private ParticleSystem m_MilestoneFourth_1;
        [SerializeField] private ParticleSystem m_MilestoneFourth_2;

        private ParticleSystem m_currentPartsys_1;
        private ParticleSystem m_currentPartsys_2;

        private SpriteRenderer m_SpriteRenderer;
        private ScoreHandler m_ScoreHandler;
        private Animator m_Animator;
        private int m_currentMilestone;

        [SerializeField]
        private GameObject[] CircleAroundObjects;
        [SerializeField]

        private float CircleAroundDistance;
        float RotationOffset;
        float RotationSpeed = 360;

        private void Start()
        {
            m_ScoreHandler = ScoreHandler.Instance;
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Animator = GetComponent<Animator>();
            m_ScoreHandler.OnJudge += Hit;
            m_ScoreHandler.OnComboMilestoneReached += SetMilestonePartSys;
            m_ScoreHandler.OnComboLost += ResetMilestone;
            ResetMilestone(0);
            MusicPlayer.Instance.AddBeatListener(InvertSpeed, 0.25f);

        }

        private void InvertSpeed()
        {
            RotationSpeed *= -1;
        }

        private void Update()
        {
            RotationOffset += Time.deltaTime * RotationSpeed;
            float diff = 360 / CircleAroundObjects.Length;
            for (int i = 0; i < CircleAroundObjects.Length; i++)
            {
                float x = transform.position.x + (Mathf.Sin((RotationOffset + (i * diff)) * Mathf.Deg2Rad) * CircleAroundDistance);
                float y = transform.position.y + (Mathf.Cos((RotationOffset + (i * diff)) * Mathf.Deg2Rad) * CircleAroundDistance);
                CircleAroundObjects[i].transform.position = new Vector2(x, y);
                CircleAroundObjects[i].transform.rotation = Quaternion.Euler(0, 0, -RotationOffset + 180 - (i * diff));
            }
        }


        private void ResetMilestone(int a)
        {
            SetMilestonePartSys(0);
        }

        private void SetMilestonePartSys(int milestone)
        {
            switch (milestone)
            {
                case 0:
                    m_currentPartsys_1 = m_MilestoneFirst_1;
                    m_currentPartsys_2 = m_MilestoneFirst_2;
                    break;
                case 1:
                    m_currentPartsys_1 = m_MilestoneSecond_1;
                    m_currentPartsys_2 = m_MilestoneSecond_2;
                    break;
                case 2:
                    m_currentPartsys_1 = m_MilestoneThird_1;
                    m_currentPartsys_2 = m_MilestoneThird_2;
                    break;
                case 3:
                    m_currentPartsys_1 = m_MilestoneFourth_1;
                    m_currentPartsys_2 = m_MilestoneFourth_2;
                    break;
                default: break;
            }
            m_currentMilestone = milestone;
        }

        private void OnDestroy()
        {
            m_ScoreHandler.OnJudge -= Hit;
            m_ScoreHandler.OnComboMilestoneReached -= SetMilestonePartSys;
            m_ScoreHandler.OnComboLost -= ResetMilestone;
            MusicPlayer.Instance.RemoveBeatListener(InvertSpeed, 0.25f);
        }

        private void Hit(ArrowJudgement judgement)
        {
            if (judgement == ArrowJudgement.miss)
                return;
            m_Animator.SetTrigger("Show");
            m_SpriteRenderer.color = ColorPalettes.Instance.Judgements.JudgementToColor(judgement);
            m_currentPartsys_1.Emit(1);// circles
            m_currentPartsys_2.Emit((int)judgement);
            for (int i = 0; i < CircleAroundObjects.Length; i++)
            {
                CircleAroundObjects[i].GetComponent<Animator>().SetTrigger("Show");
                CircleAroundObjects[i].GetComponent<SpriteRenderer>().color = ColorPalettes.Instance.Judgements.JudgementToColor(judgement);
            }
        }
    }
}