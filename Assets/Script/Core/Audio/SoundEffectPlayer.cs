using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] int m_AudioSourcecount;
    AudioSource[] m_AudioSources;

	void Start ()
    {
        for (int i = 0; i < m_AudioSourcecount; i++)
        {

        }
	}
	
	void Update () {
		
	}
}
