using UnityEngine;
using UnityEngine.Audio;
using SwipeSwipeMania.TimeManagement;

namespace SwipeSwipeMania
{
    public delegate void OnBeatDelegate();
    public delegate void SongEvent();

    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : DDOLSingleton<MusicPlayer>
    {
        private AudioSource m_AudioSource;
        private AudioMixer  m_AudioMixer;
        BeatObserverManager m_BeatManager = 
            new BeatObserverManager();


        [SerializeField] private float m_time;
        [SerializeField] private float m_timeInBeats;
        [SerializeField] private float m_deltaTime;
        [SerializeField] private float m_bpm;
        [SerializeField] private float m_timeOffset;
        [SerializeField] private float m_globalOffset;
        [SerializeField] private bool  m_playing;

        public float Time        { get { return m_time; } }
        public float TimeInBeats { get { return BPM.TimeToBeat(m_time + m_timeOffset,m_bpm)/4; } }
        public float SongSpeed   { get { return m_AudioSource.pitch * GetMixerPitch(); } }
        public float MixerSpeed  { get { return GetMixerPitch(); } }
        public float Bpm         { get { return m_bpm; } }
        public float DeltaTime   { get { return m_deltaTime; } }
        public bool  IsPlaying   { get { return m_playing; } }

        private bool SpeedChanged { get { return m_previousSpeed != SongSpeed; } }

        private float m_previousSpeed;


        public override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            m_AudioSource = GetComponent<AudioSource>();
            m_AudioMixer = m_AudioSource.outputAudioMixerGroup?.audioMixer ?? null;
            m_previousSpeed = SongSpeed;
            m_BeatManager.SubScribe(Syncronize, 1);
        }

        public void Update()
        {
            if (m_playing)
            {
                UpdateTime();
                m_BeatManager.Update(TimeInBeats);
            }
            m_previousSpeed = SongSpeed;
        }

        private void UpdateTime()
        {
            float newTime = m_time + (UnityEngine.Time.deltaTime * SongSpeed);
            m_deltaTime = newTime - m_time;
            m_time = newTime;
        }

        public void Play()
        {
            m_AudioSource.Play();
            m_time = m_AudioSource.time;
            m_BeatManager.ResetAllListeners();
            m_playing = true;
        }

        public void Pause()
        {
            m_AudioSource.Pause();
            m_playing = false;
        }

        public void UnPause()
        {
            m_AudioSource.UnPause();
            m_playing = true;
            Syncronize();
        }

        public void Stop()
        {
            m_playing = false;
            m_AudioSource.Stop();
        }

        public void Syncronize()
        {
            m_time = m_AudioSource.time;
        }

        private float GetMixerPitch()
        {
            float pitch = 1;
            if (m_AudioMixer)
            {
                if (m_AudioMixer.GetFloat("Pitch", out pitch))
                {
                    return pitch;
                }
                else
                {
                    return 1;
                }
            }
            return 1;
        }

        public void AddBeatListener(OnBeatDelegate function, float measure)
        {
            m_BeatManager.SubScribe(function, measure);
        }

        public void RemoveBeatListener(OnBeatDelegate function, float measure)
        {
            m_BeatManager.UnSubscribe(function, measure);
        }

        public void ResetBeatListeners()
        {
            m_BeatManager.ResetAllListeners();
        }

        public void SetAudioClip(AudioClip clip)
        {
            m_AudioSource.clip = clip;
            m_AudioSource.timeSamples = 0;
        }

        public void SetSongData(Song song)
        {
            m_bpm = song.bpm;
            m_timeOffset = song.offset + m_globalOffset;
        }
    }
}