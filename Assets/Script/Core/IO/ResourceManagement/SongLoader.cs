using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeSwipeMania
{
    public class SongLoader
    {
        SMStepfileReader SmStepfileReader = new SMStepfileReader();
        public SongAudioPair[] Load()
        {
            AudioClip[] audioclips = Resources.LoadAll<AudioClip>("Audio");
            TextAsset[] stepfiles = Resources.LoadAll<TextAsset>("StepFiles");
            Song[] songs = new Song[stepfiles.Length]; 

            for (int i = 0; i < stepfiles.Length; i++)
            {
                songs[i] = SmStepfileReader.GenerateFromString(stepfiles[i].text);
            }

            return Pair(audioclips,songs, stepfiles);
        }

        private SongAudioPair[] Pair(AudioClip[] audioclips,  Song[] songs, TextAsset[] Stepfiles)
        {
            List<SongAudioPair> songPairs = new List<SongAudioPair>();
            for (int i = 0; i < audioclips.Length; i++)
            {
                for (int j = 0; j < Stepfiles.Length; j++)
                {
                    if (audioclips[i].name == Stepfiles[j].name)
                    {
                        songPairs.Add(new SongAudioPair(songs[j], audioclips[i], Stepfiles[j].name));
                        break;
                    }
                }
            }
            return songPairs.ToArray();
        }
    }
}
