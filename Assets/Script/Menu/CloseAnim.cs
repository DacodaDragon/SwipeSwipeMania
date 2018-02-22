using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManagerWrapper.Instance.OnSceneLeaveEvent += OnSceneSwitch;
	}

    public void OnSceneSwitch(float duraction)
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    public void OnDestroy()
    {
        SceneManagerWrapper.Instance.OnSceneLeaveEvent -= OnSceneSwitch;
    }
}
