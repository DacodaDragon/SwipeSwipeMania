using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public static class SceneMenuItem
{
    [MenuItem("Scenes/Splash Screen")]
    public static void GoToSplashScreen()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/SplashScreens.unity");
    }

    [MenuItem("Scenes/Game Scene")]
    public static void GoToGameScene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");
    }

    [MenuItem("Scenes/Main Menu")]
    public static void GoToMainMenu()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
    }
    [MenuItem("Scenes/Credits")]
    public static void GoToCredits()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Credits.unity");
    }

    [MenuItem("Scenes/ScoreScreen")]
    public static void GoToScore()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/ScoreScreen.unity");
    }

    [MenuItem("Scenes/Song select")]
    public static void GoToSongSelect()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/SongSelect.unity");
    }

    [MenuItem("Scenes/Difficulty Select")]
    public static void GoToDiffSelect()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/DifficultySelect.unity");
    }
}
