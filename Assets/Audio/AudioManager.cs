using System;
using System.Collections;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else Instance = this;
            
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                
                s.source.Stop();
            }
        }

        public void MuteMusic(bool state)
        {
            foreach (Sound s in sounds)
                s.source.mute = state;
        }
        public  void StopAll()
        {
            foreach (Sound s in sounds)
                s.source.Stop();
        }

        public void Play(string n, bool looping)
        {
            Sound s = Array.Find(sounds, sound => sound.name == n);
            s.source.Play();
            s.source.loop = looping;
        }
        
        public void Stop(string n)
        {
            Sound s = Array.Find(sounds, sound => sound.name == n);
            s?.source?.Stop();
        }

        public void Pause(string n)
        {
            Sound s = Array.Find(sounds, sound => sound.name == n);
            s.source.Pause();
        }

        public void ButtonClick()
        {
            Play("ButtonClick", false);
        }

        public void ButtonHover()
        {
            Play("ButtonHover", false);
        }
    }
}
