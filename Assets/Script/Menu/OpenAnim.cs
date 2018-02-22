using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is to make opening animations
/// start one frame AFTER loading the
/// scene. This to avoid opening anims
/// not playing propperly
/// </summary>
public class OpenAnim : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        StartCoroutine(OpenNextFrame());
	}

    IEnumerator OpenNextFrame()
    {
        yield return null;
        yield return null;
        yield return null;
        GetComponent<Animator>().SetTrigger("Open");
    }
}
