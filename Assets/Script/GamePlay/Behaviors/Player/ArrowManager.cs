using System.Collections.Generic;
using UnityEngine;

namespace SwipeSwipeMania
{
    public delegate void AtEndOfStepfile();

    public class ArrowManager
    {
        private ArrowViewWindow m_window;
        private Arrow[] m_Arrows;
        private float[] m_Times;
        private int m_size;
        private bool m_EndOfStepfile;

        private ArrowViewportDelegate m_OnArrowEnter;
        private ArrowViewportDelegate m_OnArrowLeave;
        private AtEndOfStepfile m_onEndOfStepfile;

        public event ArrowViewportDelegate OnArrowEnter { add { m_OnArrowEnter += value; } remove { m_OnArrowEnter -= value; } }
        public event ArrowViewportDelegate OnArrowLeave { add { m_OnArrowLeave += value; } remove { m_OnArrowLeave -= value; } }
        public event AtEndOfStepfile OnEndOfStepfileReached { add { m_onEndOfStepfile += value; } remove { m_onEndOfStepfile -= value; } }

        public ArrowManager()
        {
            m_window = new ArrowViewWindow();
            m_window.OnArrowEnter += (Arrow arrow) => { arrow.gameObject.SetActive(true); m_OnArrowEnter?.Invoke(arrow); };
            m_window.OnArrowLeave += (Arrow arrow) => { arrow.gameObject.SetActive(false); m_OnArrowLeave?.Invoke(arrow); };
        }

        public void UpdateArrows(float timeInBeats, float speedMultiplier = 1)
        {
            m_window.Update(m_Arrows, m_Times, timeInBeats);
            int start = m_window.ViewStart;
            int end = m_window.ViewEnd;

            if (end == m_size && !m_EndOfStepfile)
            {
                m_onEndOfStepfile?.Invoke();
                m_EndOfStepfile = true;
            }

            for (int i = end; i < start; i++)
            {
                float DeltaFromHitcircle = (timeInBeats - m_Times[i]) * speedMultiplier;
                m_Arrows[i].UpdatePosition(DeltaFromHitcircle);
            }
        }

        private int GetClosestArrowIndex(float timeInBeats)
        {
            int index = -1;
            float highestDelta = float.PositiveInfinity;
            for (int i = 0; i < m_Arrows.Length; i++)
            {
                if (!m_Arrows[i].Hittable)
                    continue;

                float delta = Mathf.Abs(timeInBeats - m_Times[i]);
                if (delta < highestDelta)
                {
                    highestDelta = delta;
                    index = i;
                }
                else break;
            }
            return index;
        }

        public ArrowInfo GetClosestArrowInfo(float beatTime)
        {
            int index = GetClosestArrowIndex(beatTime);
            if (index == -1)
                return new ArrowInfo(float.NaN, null, ArrowDirection.none);
            float delta = beatTime - m_Times[index];
            ArrowDirection direction = m_Arrows[index].getArrowDirection();
            Arrow reference = m_Arrows[index];
            return new ArrowInfo(delta, reference, direction);
        }

        public void Load(ArrowInitialData[] notes, Transform transform, ArrowSprites arrowSprites)
        {
            m_size = notes.Length;
            Arrow[] arrows = ArrowPool.Instance.GetArrows(notes.Length);
            float[] times = new float[notes.Length];
            for (int i = 0; i < notes.Length; i++)
            {
                SpriteRenderer spriteRenderer = arrows[i].GetComponent<SpriteRenderer>();
                Arrow arrow = arrows[i].GetComponent<Arrow>();

                arrows[i].transform.SetParent(transform);
                spriteRenderer.sprite = arrowSprites.GetDirectionalSprite(notes[i].direction);
                spriteRenderer.color = ColorPalettes.Instance.Arrows.GetDirectionalColor(notes[i].direction);

                if (i % 2 == 0)
                {
                    arrow.SetDirection(new Vector2(0.5f, 0.5f));
                    arrow.SetEffectModifier(1);
                }

                if (i % 2 == 1)
                {
                    arrow.SetDirection(new Vector2(-0.5f, 0.5f));
                    arrow.SetEffectModifier(-1);
                }
                arrow.SetArrowDirection(notes[i].direction);
                arrows[i] = arrow;
                times[i] = notes[i].beatTime;
            }
            m_Arrows = arrows;
            m_Times = times;
        }
    }

    public struct ArrowInfo
    {
        public readonly float delta;
        public readonly ArrowDirection direction;
        public Arrow arrow;

        public ArrowInfo(float delta, Arrow arrow, ArrowDirection direction)
        {
            this.delta = delta;
            this.arrow = arrow;
            this.direction = direction;
        }
    }
}
