using UnityEngine;
using SwipeSwipeMania;

public class JudgementReader : MonoBehaviour
{
    private JudgementSprites sprites;
    private MusicPlayer m_musicPlayer;
    private Animator animator;
    [SerializeField]
    JudgementSprites m_sprites;

    void Start()
    {
        m_musicPlayer = MusicPlayer.Instance;
        m_musicPlayer.AddBeatListener(Bounce, 0.25f);
        ScoreHandler.Instance.OnJudge += RecieveJudgement;
    }

    public void OnDestroy()
    {
        m_musicPlayer.RemoveBeatListener(Bounce, 0.25f);
        ScoreHandler.Instance.OnJudge -= RecieveJudgement;
    }

    public void Bounce()
    {
        //GetComponent<Animator>().SetTrigger("Bounce");
    }

    public void RecieveJudgement(ArrowJudgement judgement)
    {
        GetComponent<SpriteRenderer>().sprite = m_sprites.GetSprite(judgement);
    }
}

[System.Serializable]
struct JudgementSprites
{
    [SerializeField] Sprite Miss;
    [SerializeField] Sprite Bad;
    [SerializeField] Sprite Ok;
    [SerializeField] Sprite Good;
    [SerializeField] Sprite Great;
    [SerializeField] Sprite Marvelous;

    public Sprite GetSprite(ArrowJudgement Judgement)
    {
        switch (Judgement)
        {
            case ArrowJudgement.miss: return Miss;
            case ArrowJudgement.bad: return Bad;
            case ArrowJudgement.ok: return Ok;
            case ArrowJudgement.good: return Good;
            case ArrowJudgement.great: return Great;
            case ArrowJudgement.marvelous: return Marvelous;
            default: return null;
        }
    }
}