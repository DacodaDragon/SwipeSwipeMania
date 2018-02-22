using UnityEngine;
using UnityEngine.UI;

namespace SwipeSwipeMania
{
    public class GotoSceneOnButton : MonoBehaviour
    {
        [SerializeField]
        Levels nextScene;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.Instance.LoadScene(nextScene);
            });
        }
    }
}

