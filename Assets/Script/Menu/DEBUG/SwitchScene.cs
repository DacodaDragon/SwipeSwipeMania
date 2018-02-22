using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SwipeSwipeMania
{
    public class SwitchScene : MonoBehaviour
    {
        [SerializeField]
        Levels scene;
        void Start()
        {
            FindObjectOfType<SceneManager>().LoadScene(scene);
        }
    }
}
