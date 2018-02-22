using UnityEngine;

namespace SwipeSwipeMania
{
    public class SongData : DDOLSingleton<SongData>
    {
        private SongAudioPair[] m_songs;

        /// <summary>
        /// Loads all song files, interprets them and saves them in memory
        /// </summary>
        public void LoadSongs()
        {
            try
            {
                m_songs = new SongLoader().Load();
            }
            catch (System.Exception)
            {
                Debug.Log("Error Parsing Songs");
            }
        }

        /// <summary>
        /// Finds and returns song by internal song name (stepfile asset name without extension)
        /// </summary>
        public SongAudioPair GetSongPairByInternalName(string internalName)
        {
            CheckIfReloadIsNecessary();

            for (int i = 0; i < m_songs.Length; i++)
            {
                if (internalName == m_songs[i].internalName)
                    return m_songs[i];
            }
            throw new System.ArgumentException($"Song with internalName {internalName} does not exist");
        }

        /// <summary>
        /// Finds and returns song by title within stepfile
        /// </summary>
        public SongAudioPair GetSongPairByTitle(string title)
        {
            CheckIfReloadIsNecessary();

            for (int i = 0; i < m_songs.Length; i++)
            {
                if (title == m_songs[i].song.title)
                    return m_songs[i];
            }
            throw new System.ArgumentException($"Song with title {title} does not exist");
        }

        /// <summary>
        /// Returns song by index
        /// </summary>
        public SongAudioPair GetSongByIndex(int index)
        {
            CheckIfReloadIsNecessary();
            return m_songs[index];
        }

        /// <summary>
        /// Returns a copy of all songrelated data
        /// </summary>
        public SongAudioPair[] GetAllSongs()
        {
            // Send a copy of instead of a reference
            // So others can't just change the internal
            // Data
            CheckIfReloadIsNecessary();
            return m_songs.Clone() as SongAudioPair[];
        }

        private void CheckIfReloadIsNecessary()
        {
            if (m_songs == null)
                LoadSongs();
        }
    }
}