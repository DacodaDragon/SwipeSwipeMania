using UnityEngine.UI;
using UnityEngine;
namespace SwipeSwipeMania
{
    public class ScoreMenu : MonoBehaviour
    {
        [SerializeField] private Text Marvelous;
        [SerializeField] private Text Great;
        [SerializeField] private Text Good;
        [SerializeField] private Text Ok;
        [SerializeField] private Text Bad;
        [SerializeField] private Text Miss;
        [SerializeField] private Text Total;
        [SerializeField] private Text Percentage;

        [SerializeField] private Text SongName;
        [SerializeField] private Text Difficulty;
        [SerializeField] private Text Artist;

        [SerializeField] private Button m_Continue;
        [SerializeField] private Button m_replay;

        public void Start()
        {
            JudgementScores scores = Judgement.Instance.GetJudgementScores();
            SongSelectionData selection = SongSelectionData.Instance;
            SongData songData = SongData.Instance;


            Marvelous.text = $"Marvelous: {scores.Marvelous}";
            Great.text = $"Great: {scores.Great}";
            Good.text = $"Good: {scores.Good}";
            Ok.text = $"Ok: {scores.Ok}";
            Bad.text = $"bad: {scores.Bad}";
            Miss.text = $"Missed: {scores.Miss}";
            Total.text = $"Total: {scores.Total}";
            Percentage.text = $"Percentage: %{scores.Percentage.ToString("0.00")}";

            Song song = songData.GetSongByIndex(selection.SelectedSongIndex).song;
            SongName.text = song.title;
            Artist.text = song.artist;
            Difficulty.text = song.datas[selection.SelectedDiffIndex].difficulty;

            m_Continue.onClick.AddListener(() => { SceneManager.Instance.LoadScene(Levels.SongSelect); });
            m_replay.onClick.AddListener(() => { SceneManager.Instance.LoadScene(Levels.Game); });

        }
    }
}