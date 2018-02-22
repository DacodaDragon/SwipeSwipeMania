using UnityEngine;


namespace SwipeSwipeMania
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private ArrowSprites m_ArrowSprites;
        [SerializeField] private float m_SpeedMultiplier;
        [SerializeField] private bool m_AutoPlay;
        [SerializeField] private ArrowDirection m_TemporaryArrowDirection;

        private MusicPlayer m_MusicPlayer;

        private ArrowManager m_ArrowManager = new ArrowManager();

        private void Awake()
        {
            m_MusicPlayer = MusicPlayer.Instance;
            ScoreHandler.Instance.Reset();
            TouchSurface[] surfaces = FindObjectsOfType<TouchSurface>();
            for (int i = 0; i < surfaces.Length; i++)
            {
                surfaces[i].OnDirectionalSwipeEvent += ReceiveDirection;
            }
        }

        private void Start()
        {
            KeyInput keyInput = FindObjectOfType<KeyInput>();
            if (keyInput)
                keyInput.OnDirectionalSwipeEvent += ReceiveDirection;
            m_ArrowManager.OnEndOfStepfileReached += () =>
            {
                ArrowPool.Instance.ReturnAll();
                SceneManager.Instance.LoadScene(Levels.Score);
            };
            m_ArrowManager.OnArrowLeave += (Arrow arrow) =>
            {
                if (arrow.Hittable)
                {
                    ScoreHandler.Instance.Evaluate(float.MaxValue, ArrowDirection.none);
                }
            };
        }

        private void OnDestroy()
        {
            if (m_MusicPlayer)
                m_MusicPlayer.Stop();
        }

        private void Update()
        {
            if (m_MusicPlayer.IsPlaying)
                m_ArrowManager.UpdateArrows(m_MusicPlayer.TimeInBeats, m_SpeedMultiplier);

            if (m_AutoPlay)
            {
                ArrowInfo info = m_ArrowManager.GetClosestArrowInfo(m_MusicPlayer.TimeInBeats);
                if (info.delta > 0 && info.arrow.Hittable)
                    HitNote(info, 0);
            }
        }

        private void ReceiveDirection(ArrowDirection direction)
        {
            ArrowInfo arrowInfo = m_ArrowManager.GetClosestArrowInfo(m_MusicPlayer.TimeInBeats);

            if (Mathf.Abs(arrowInfo.delta) > Judgement.Instance.Strictness)
                return;

            if (arrowInfo.direction == direction)
            {
                HandleSingleNote(arrowInfo);
            }
            else if (ArrowDirectionUtility.IsCombination(arrowInfo.direction))
            {
                HandleMultiDirection(arrowInfo, direction);
            }
        }

        private void HitNote(ArrowInfo arrowInfo)
        {
            HitNote(arrowInfo, arrowInfo.delta);
        }

        private void HitNote(ArrowInfo arrowInfo, float delta)
        {
            ScoreHandler.Instance.Evaluate(delta, arrowInfo.direction);
            arrowInfo.arrow.Hit();
        }

        private void HandleSingleNote(ArrowInfo arrowInfo)
        {
            HitNote(arrowInfo);
            m_TemporaryArrowDirection = ArrowDirection.none;
        }

        private void HandleMultiDirection(ArrowInfo arrowInfo, ArrowDirection recievedDirection)
        {
            if (ArrowDirectionUtility.IsInCombinationFor(recievedDirection, arrowInfo.direction))
            {
                ArrowDirection combination = ArrowDirectionUtility.Combine(recievedDirection, m_TemporaryArrowDirection);

                if (combination == arrowInfo.direction)
                {
                    HitNote(arrowInfo);
                    m_TemporaryArrowDirection = ArrowDirection.none;
                }
                else
                {
                    m_TemporaryArrowDirection = recievedDirection;
                }
            }
        }

        public void UpdateArrows()
        {
            m_ArrowManager.UpdateArrows(m_MusicPlayer.TimeInBeats);
        }

        public void LoadNotes(ArrowInitialData[] arrowData)
        {
            Judgement.Instance.Reset();
            m_ArrowManager.Load(arrowData, transform, m_ArrowSprites);
        }
    }

    [System.Serializable]
    public struct ArrowSprites
    {
        [SerializeField] private Sprite Up;
        [SerializeField] private Sprite Down;
        [SerializeField] private Sprite Left;
        [SerializeField] private Sprite Right;

        [SerializeField] private Sprite UpLeft;
        [SerializeField] private Sprite UpRight;
        [SerializeField] private Sprite DownLeft;
        [SerializeField] private Sprite DownRight;

        [SerializeField] private Sprite Horizontal;
        [SerializeField] private Sprite Vertical;

        public Sprite GetDirectionalSprite(ArrowDirection direction)
        {
            switch (direction)
            {
                case ArrowDirection.left: return Left;
                case ArrowDirection.right: return Right;
                case ArrowDirection.up: return Up;
                case ArrowDirection.down: return Down;
                case ArrowDirection.horizontal: return Horizontal;
                case ArrowDirection.vertical: return Vertical;
                case ArrowDirection.upleft: return UpLeft;
                case ArrowDirection.upright: return UpRight;
                case ArrowDirection.downleft: return DownLeft;
                case ArrowDirection.downright: return DownRight;
                default: return null; // None shouldn't be rendered anyway
            }
        }
    }
}