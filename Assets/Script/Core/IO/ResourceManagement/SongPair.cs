using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeSwipeMania
{
    public struct SongAudioPair
    {
        readonly public Song song;
        readonly public AudioClip audioclip;
        readonly public string internalName;

        public SongAudioPair(Song song, AudioClip audioclip, string internalName)
        {
            this.song = song;
            this.audioclip = audioclip;
            this.internalName = internalName;
        }
    }
}
