using UnityEngine;

namespace SwipeSwipeMania
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Arrow : MonoBehaviour
    {
        public static float rotationSpeed;

        private ArrowDirection arrowDirection;
        private Vector2 direction = new Vector2(0, 1);
        private bool hittable = true;
        private SpriteRenderer m_spriteRenderer;
        public bool Hittable { get { return hittable; } }

        public float EffectModifier = 1;

        public void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Reset()
        {
            if (m_spriteRenderer)
                m_spriteRenderer.enabled = true;
            hittable = true;
        }

        public void Hit()
        {
            hittable = false;
            m_spriteRenderer.enabled = false;
        }

        public void SetEffectModifier(float modifierValue)
        {
            EffectModifier = modifierValue;
        }

        public void SetArrowDirection(ArrowDirection direction)
        {
            arrowDirection = direction;
        }

        public ArrowDirection getArrowDirection()
        {
            return arrowDirection;
        }

        public void UpdatePosition(float deltaTime)
        {
            float a = Vector2DMath.GetAngle(direction);
            Vector2 f = Vector2DMath.AngleToVector(a +(ArrowBehaviorData.Instance.Rotation * EffectModifier)* Mathf.Abs(deltaTime));
            transform.localPosition = f * (deltaTime);
            //transform.rotation = Quaternion.Euler(0,0,0);
            //float x = Mathf.Clamp(4-Mathf.Abs(deltaTime*4),0f, 4f)/4;
            //transform.localScale = new Vector3(x, x, x);
        }

        public void SetDirection(Vector2 Direction)
        {
            direction = Direction;
        }
    }
}