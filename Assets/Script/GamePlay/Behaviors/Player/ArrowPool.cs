using UnityEngine;
using prototyping;
namespace SwipeSwipeMania
{
    public class ArrowPool : DDOLSingleton<ArrowPool>
    {
        [SerializeField]
        private int PoolCount = 1600;
        private Arrow[] m_arrows;

        public void Build()
        {
            m_arrows = new Arrow[PoolCount];
            for (int i = 0; i < PoolCount; i++)
            {
                GameObject arrow = new GameObject("Arrow");
                arrow.AddComponent<Arrow>();
                arrow.transform.SetParent(transform);
                arrow.gameObject.SetActive(false);
                m_arrows[i] = arrow.GetComponent<Arrow>();
            }
        }

        public Arrow[] GetArrows(int amount)
        {
            Arrow[] arrows = new Arrow[amount];
            ArrayUtil.CopyOver(m_arrows, arrows);

            Debug.Log(arrows);
            Debug.Log(arrows.Length);

            return arrows;
        }

        public void ReturnAll()
        {
            for (int i = 0; i < m_arrows.Length; i++)
            {
                m_arrows[i].transform.SetParent(transform);
                m_arrows[i].gameObject.SetActive(false);
                m_arrows[i].Reset();
            }
        }
    }
}