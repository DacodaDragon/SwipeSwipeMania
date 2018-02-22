using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwipeSwipeMania;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    Button m_PauseButton;
    [SerializeField]
    Button m_UnPauseButton;
    [SerializeField]
    Button m_MainMenuButton;
    [SerializeField]
    Button m_Retry;


    [SerializeField]
    GameObject m_PauseMenu;
    MusicPlayer m_musicPlayer;

	// Use this for initialization
	void Start () {
        m_PauseMenu.SetActive(false);
        m_PauseButton.onClick.AddListener(Pause);
        m_UnPauseButton.onClick.AddListener(Unpause);
        m_MainMenuButton.onClick.AddListener(ToMainMenu);
        m_Retry.onClick.AddListener(ReTry);
        m_musicPlayer = MusicPlayer.Instance;
    }

    public void ToMainMenu()
    {
        ArrowPool.Instance.ReturnAll();
        SceneManager.Instance.LoadScene(Levels.MainMenu);
    }

    public void ReTry()
    {
        ArrowPool.Instance.ReturnAll();
        SceneManager.Instance.LoadScene(Levels.Game);
    }

    public void Pause()
    {
        m_PauseButton.interactable = false;
        m_PauseMenu.SetActive(true);
        m_musicPlayer.Pause();
    }

    public void Unpause()
    {
        m_PauseButton.interactable = true;
        m_PauseMenu.SetActive(false);
        m_musicPlayer.UnPause();
    }
}
