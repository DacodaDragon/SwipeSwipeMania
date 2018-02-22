using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SwipeSwipeMania
{
    public class ColorPalettes : DDOLSingleton<ColorPalettes>
    {
        [SerializeField] private ArrowColors m_arrows;
        [SerializeField] private JudgementColors m_judgement;
        public ArrowColors Arrows { get { return m_arrows; } }
        public JudgementColors Judgements { get { return m_judgement; } }
    }

    [System.Serializable]
    public struct ArrowColors
    {
        [SerializeField] private Color Up;
        [SerializeField] private Color Down;
        [SerializeField] private Color Left;
        [SerializeField] private Color Right;

        [SerializeField] private Color UpLeft;
        [SerializeField] private Color UpRight;
        [SerializeField] private Color DownLeft;
        [SerializeField] private Color DownRight;

        [SerializeField] private Color Horizontal;
        [SerializeField] private Color Vertical;

        public Color GetDirectionalColor(ArrowDirection direction)
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
                default: return new Color(1, 1, 1);
            }
        }
    }


    [System.Serializable]
    public struct JudgementColors
    {
        [SerializeField] private Color Marvelous;
        [SerializeField] private Color Great;
        [SerializeField] private Color Good;
        [SerializeField] private Color Ok;
        [SerializeField] private Color Bad;
        [SerializeField] private Color Miss;

        public Color JudgementToColor(ArrowJudgement judgement)
        {
            switch (judgement)
            {
                case ArrowJudgement.miss: return Miss;
                case ArrowJudgement.bad: return Bad;
                case ArrowJudgement.ok: return Ok;
                case ArrowJudgement.good: return Good;
                case ArrowJudgement.great: return Great;
                case ArrowJudgement.marvelous: return Marvelous;
                default: return Color.black;
            }
        }
    }
}