using UnityEngine;
using System.Collections;
namespace SwipeSwipeMania.Debugging
{
    public class QuickLoader : MonoBehaviour
    {
        public void Start()
        {
            int songIndex = SongSelectionData.Instance.SelectedSongIndex;
            int diffIndex = SongSelectionData.Instance.SelectedDiffIndex;
            SongAudioPair pair = SongData.Instance.GetSongByIndex(songIndex);
            MusicPlayer.Instance.SetAudioClip(pair.audioclip);
            MusicPlayer.Instance.SetSongData(pair.song);
            MusicPlayer.Instance.ResetBeatListeners();

            FindObjectOfType<Player>().LoadNotes(pair.song.datas[diffIndex].noteList);
            StartCoroutine(StartNextFrame());
        }

        IEnumerator StartNextFrame()
        {
            yield return null;
            MusicPlayer.Instance.Play();
        }

    }
}