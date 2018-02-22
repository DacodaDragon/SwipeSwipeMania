using UnityEngine;
using System.Collections;
using SwipeSwipeMania.Touchmanager;
using TMPro;

namespace SwipeSwipeMania
{
    // This is mainly to save time during runtime
    public class PreloadSingletons : MonoBehaviour
    {
        [SerializeField]
        TextMeshPro LoadText;

        void Start()
        {
            DontDestroyOnLoad(this);
            StartCoroutine("Load");
        }

        private void SetText(string text)
        {
            if (LoadText)
                LoadText.text = text;
        }

        public IEnumerator Load()
        {
            SetText("Setting Default FPS to 60..");
            yield return null;
            Application.targetFrameRate = 60;

            object a;
            SetText("Loading TouchManager");
            yield return null;
            a = TouchManager.Instance;

            SetText("Loading TouchManager");
            yield return null;
            a = MusicPlayer.Instance;

            SetText("Loading Selection Data");
            yield return null;
            a = SongSelectionData.Instance;

            SetText("Loading Judgement Data");
            yield return null;
            a = Judgement.Instance;

            SetText("Loading and Interpreting SongData");
            yield return null;
            SongData.Instance.LoadSongs();

            SetText("Loading ColorPalette");
            yield return null;
            a = ColorPalettes.Instance;

            SetText("Loading ArrowPool");
            yield return null;
            ArrowPool.Instance.Build();
            SetText("Done!");

            yield return new WaitForSeconds(3f);
            Destroy(LoadText);
            Destroy(this);
        }
    }
}