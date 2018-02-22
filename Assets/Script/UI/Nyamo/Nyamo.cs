using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwipeSwipeMania;


// NYA!
public class Nyamo : MonoBehaviour {

    [SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField] NyamoSprites m_NyaSprites;
    [SerializeField] Animator m_Nyanimator;

    Judgement judgement;

	// Nya Nya Nya Initialization
	void Start () {
        ScoreHandler.Instance.OnDirection += Dance;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_Nyanimator = GetComponent<Animator>();
	}
    
    private void OnDestroy()
    {
        ScoreHandler.Instance.OnDirection -= Dance;
    }

    private void Dance(ArrowDirection nya)
    {
        m_spriteRenderer.sprite = m_NyaSprites.GetNya(nya);
        m_Nyanimator.SetTrigger("Bounce");
    }


    [System.Serializable]
    private struct NyamoSprites
    {
        [SerializeField] Sprite Up;
        [SerializeField] Sprite Down;
        [SerializeField] Sprite Left;
        [SerializeField] Sprite Right;
        [SerializeField] Sprite UpLeft;
        [SerializeField] Sprite UpRight;
        [SerializeField] Sprite DownLeft;
        [SerializeField] Sprite DownRight;
        [SerializeField] Sprite Horizontal;
        [SerializeField] Sprite Vertical;
        [SerializeField] Sprite Missed;
        [SerializeField] Sprite Idle;

        public Sprite GetNya(ArrowDirection direction)
        {
            switch (direction)
            {
                case ArrowDirection.left:       return Left;
                case ArrowDirection.right:      return Right;
                case ArrowDirection.up:         return Up;
                case ArrowDirection.down:       return Down;
                case ArrowDirection.horizontal: return Horizontal;
                case ArrowDirection.vertical:   return Vertical;
                case ArrowDirection.upleft:     return UpLeft;
                case ArrowDirection.upright:    return UpRight;
                case ArrowDirection.downleft:   return DownLeft;
                case ArrowDirection.downright:  return DownRight;
                case ArrowDirection.none:       return Missed;
                default: return Idle;
            }
        }

        public Sprite GetIdleNya()
        {
            return Idle;
        }
    }
}
