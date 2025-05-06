using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SongManager : MonoBehaviour
{
    public Dropdown songDropdown;
    public List<StemMixer> stemMixers;
    public List<SongData> songs; // Now using ScriptableObject

    void Start()
    {
        songDropdown.ClearOptions();
        songDropdown.AddOptions(songs.ConvertAll(s => s.songName));
        songDropdown.onValueChanged.AddListener(OnSongSelected);

        OnSongSelected(0);
    }

    void OnSongSelected(int index)
    {
        var selected = songs[index];

        if (selected.stemClips.Count != stemMixers.Count)
        {
            Debug.LogWarning($"Song '{selected.songName}' has {selected.stemClips.Count} stems, but there are {stemMixers.Count} spheres.");
            return;
        }

        for (int i = 0; i < stemMixers.Count; i++)
        {
            stemMixers[i].audioSource.clip = selected.stemClips[i];
            stemMixers[i].audioSource.Stop();
        }
    }
}
