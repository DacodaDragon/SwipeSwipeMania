using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwipeSwipeMania;

namespace SwipeSwipeMania
{
    [RequireComponent(typeof(SceneManagerWrapper))]
    public class SceneManager : DDOLSingleton<SceneManager>
    {
        SceneManagerWrapper wrapper;
        public override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            wrapper = GetComponent<SceneManagerWrapper>();
        }

        public void LoadScene(Levels scene)
        {
            wrapper.Load((int)scene);
        }
    }


    public enum Levels
    {
        SplashScreens = 0,
        MainMenu = 1,
        Game = 3,
        SongSelect = 2,
        Score = 4,
        Credits = 5,
        DifficultySelect = 6
    }
}