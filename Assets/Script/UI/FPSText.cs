using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FPSText : MonoBehaviour {
    [SerializeField]
    Text m_text;
	void Update ()
    {
        m_text.text = (1.0f / Time.deltaTime).ToString("00.00");
    }
}
