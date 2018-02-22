using UnityEngine;
using SwipeSwipeMania.Touchmanager;
namespace SwipeSwipeMania
{
    public class NextSceneOnTouch : MonoBehaviour
    {

        [SerializeField]
        private Levels nextScene;

        void Start()
        {
            TouchManager.Instance.OnTouchInit += OnTouch;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                OnTouch(0);
                Debug.Log("Wot");
            }
        }

        public void OnTouch(int touchID)
        {
            TouchManager.Instance.OnTouchInit -= OnTouch;
            SceneManagerWrapper.Instance.Load((int)nextScene);
        }
    }

}
