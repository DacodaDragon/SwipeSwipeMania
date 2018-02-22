using UnityEngine;
using UnityEngine.UI;
using SwipeSwipeMania;

public class ScoreReader : MonoBehaviour
{
    MusicPlayer musicPLayer;
    void Start()
    {
        musicPLayer = MusicPlayer.Instance;
        musicPLayer.AddBeatListener(Bounce, 0.25f);
        ScoreHandler.Instance.OnAccuracyUpdate += UpdateScore;
    }

    private void UpdateScore(float score)
    {
        GetComponent<Text>().text = "%" + score.ToString("0.00");
    }
    
    private void OnDestroy()
    {
        musicPLayer?.RemoveBeatListener(Bounce, 0.25f);
        ScoreHandler.Instance.OnAccuracyUpdate -= UpdateScore;
    }

    private void Bounce()
    {
        GetComponent<Animator>().SetTrigger("Bounce");
    }
}
