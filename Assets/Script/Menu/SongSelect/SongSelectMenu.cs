using System.Collections.Generic;
using UnityEngine;
using SwipeSwipeMania;

public class SongSelectMenu : MonoBehaviour {

    [SerializeField]
    ChoiceScrollMenu m_menu;
    SongAudioPair[] songs;

    public void Start()
    {
        songs = SongData.Instance.GetAllSongs();
        List<string> strings = new List<string>();

        for (int i = 0; i < songs.Length; i++)
        {
            strings.Add(songs[i].song.title);
        }

        m_menu.BuildMenu(strings.ToArray());
        m_menu.OnChoose += RecieveChoice;
    }

    public void RecieveChoice(int choice)
    {
        SongSelectionData.Instance.SelectedSongIndex = choice;
        SceneManager.Instance.LoadScene(Levels.DifficultySelect);
    }
}
