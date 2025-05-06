using UnityEngine;
using UnityEngine.UI;

public class StemMixer : MonoBehaviour
{
    public string channelName = "Unnamed";
    public AudioSource audioSource;
    public Slider volumeSlider;

    private void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
            volumeSlider.value = audioSource.volume;
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    public float GetVolume() => audioSource.volume;
}
