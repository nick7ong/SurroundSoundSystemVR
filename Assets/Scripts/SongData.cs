using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSong", menuName = "Audio/Song Data")]
public class SongData : ScriptableObject
{
    public string songName;
    public List<AudioClip> stemClips; // One for each stem (e.g., 5.1 = 6)
}
