using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeSwipeMania
{
    public class SwitchSceneTimed : MonoBehaviour
    {
        [SerializeField]
        Levels scene;
        [SerializeField]
        float time;
        void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
                SceneManager.Instance.LoadScene(scene);
        }
    }
}
