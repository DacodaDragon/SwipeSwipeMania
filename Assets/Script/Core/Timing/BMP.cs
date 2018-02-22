using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeSwipeMania
{
    /// <summary>
    /// Static class containing handy dandy BMP time conversions
    /// </summary>
    public sealed class BPM
    {
        /// <summary>
        /// Converts the time in seconds into the current beat.
        /// </summary>
        /// <param name="time">Time in Seconds</param>
        /// <param name="bmp">Beats per Minute</param>
        /// <returns>current beat count</returns>
        public static float TimeToBeat(float time, float bmp)
        {
            return ((time / 120) * bmp) * 2;
        }

        /// <summary>
        /// Converts the current beat into a time in seconds.
        /// </summary>
        /// <param name="beat">Current Beat</param>
        /// <param name="bmp">Beats per minute</param>
        /// <returns>Current time</returns>
        public static float BeatToTime(float beat, float bmp)
        {
            return ((beat / 2) / bmp) * 120;
        }
    }
}