using System.Collections.Generic;
using UnityEngine;
using SwipeSwipeMania;

public class DifficultySelectMenu : MonoBehaviour
{
    [SerializeField]
    ChoiceScrollMenu m_Menu;
    private void Start()
    {
        SongAudioPair pair = SongData.Instance.GetSongByIndex(SongSelectionData.Instance.SelectedSongIndex);
        List<string> names = new List<string>();

        for (int i = 0; i < pair.song.datas.Length; i++)
        {
            names.Add(pair.song.datas[i].difficulty);
        }

        m_Menu.BuildMenu(names.ToArray());
        m_Menu.OnChoose += RecieveDifficulty;
    }

    private void RecieveDifficulty(int index)
    {
        SongSelectionData.Instance.SelectedDiffIndex = index;
        SceneManager.Instance.LoadScene(Levels.Game);
    }
}
