using UnityEngine;
using UnityEngine.UI;
using SwipeSwipeMania;

public class ComboReader : MonoBehaviour
{
    private MusicPlayer musicPLayer;
    private Text scoreText;

    [SerializeField] Color ColorCombo;
    [SerializeField] Color ColorMiss;

    void Start()
    {
        musicPLayer = MusicPlayer.Instance;
        ScoreHandler.Instance.OnComboUpdate += UpdateScore;
        scoreText = GetComponent<Text>();
    }

    private void UpdateScore(int score)
    {
        if (score >= 1)
        {
            scoreText.color = ColorCombo;
            scoreText.text = "x"+score.ToString();
        }

        if (score <= 0)
        {
            scoreText.color = ColorMiss;
            scoreText.text = "MISS";
        }

        Bounce();
    }

    private void OnDestroy()
    {
        ScoreHandler.Instance.OnComboUpdate -= UpdateScore;
    }

    private void Bounce()
    {
        GetComponent<Animator>().SetTrigger("Bounce");
    }
}
