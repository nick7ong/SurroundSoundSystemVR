using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources;

    private bool isPlaying = false;
    private bool wasPaused = false;
    private double scheduledStartTime = 0;

    public void Start()
    {
       StopAll();
    }

    public void PlayAll()
    {
        if (isPlaying) return;

        if (wasPaused)
        {
            // Resume from paused
            foreach (AudioSource source in audioSources)
                source.UnPause();

            wasPaused = false;
        }
        else
        {
            // Start fresh with tight sync
            scheduledStartTime = AudioSettings.dspTime + 0.5f;

            foreach (AudioSource source in audioSources)
            {
                source.Stop(); // Ensure it's rewound
                source.PlayScheduled(scheduledStartTime);
            }
        }

        isPlaying = true;
    }

    public void PauseAll()
    {
        foreach (AudioSource source in audioSources)
            source.Pause();

        isPlaying = false;
        wasPaused = true;
    }

    public void StopAll()
    {
        foreach (AudioSource source in audioSources)
            source.Stop();

        isPlaying = false;
        wasPaused = false;
    }
}
