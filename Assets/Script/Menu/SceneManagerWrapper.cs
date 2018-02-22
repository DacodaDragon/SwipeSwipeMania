using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using InternalSceneManager = UnityEngine.SceneManagement.SceneManager;

public delegate void OnSceneLoaded();
public delegate void SceneClosingDelegate(float timeleft);

public class SceneManagerWrapper : DDOLSingleton<SceneManagerWrapper>
{
    private OnSceneLoaded onSceneLoaded;
    private SceneClosingDelegate onSceneLeave;

    public event OnSceneLoaded OnSceneLoadedEvent { add { onSceneLoaded += value; } remove { onSceneLoaded -= value; } }
    public event SceneClosingDelegate OnSceneLeaveEvent { add { onSceneLeave += value; } remove { onSceneLeave -= value; } }

    Coroutine routine;

    public override void Awake()
    {
        base.Awake();
        InternalSceneManager.sceneLoaded += (Scene scene, LoadSceneMode loadSceneMode) => { onSceneLoaded?.Invoke(); };
    }

    public void Load(int sceneNumber)
    {
        if (routine == null)
        routine = StartCoroutine(LoodSceneByNumberRoutine(sceneNumber, 0.3f));
    }

    public void Load(string sceneName)
    {
        if (routine == null)
        routine = StartCoroutine(LoodSceneByNameRoutine(sceneName, 0.3f));
    }

    public void LoadAddative(int sceneNumber)
    {
        InternalSceneManager.LoadScene(sceneNumber);
    }

    public void LoadAddative(string sceneName)
    {
        InternalSceneManager.LoadScene(sceneName);
    }

    IEnumerator LoodSceneByNumberRoutine(int level, float duraction)
    {
        onSceneLeave?.Invoke(duraction);
        yield return new WaitForSeconds(duraction);
        InternalSceneManager.LoadScene(level);
        routine = null;
    }

    IEnumerator LoodSceneByNameRoutine(string level, float duraction)
    {
        onSceneLeave?.Invoke(duraction);
        yield return new WaitForSeconds(duraction);
        InternalSceneManager.LoadScene(level);
        routine = null;
    }
}
