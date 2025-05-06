using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    public Renderer targetRenderer; // assign in Inspector
    public Color baseColor = Color.cyan;
    public float intensityMultiplier = 100f;
    public float smoothSpeed = 10f;

    private AudioSource audioSource;
    private float[] samples = new float[256];
    private Material sphereMaterial;
    private float currentIntensity;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sphereMaterial = targetRenderer.material;
    }

    void Update()
    {
        if (!audioSource.isPlaying || !audioSource.clip) return;

        audioSource.GetOutputData(samples, 0);

        float amplitude = 0f;
        for (int i = 0; i < samples.Length; i++)
            amplitude += Mathf.Abs(samples[i]);

        amplitude /= samples.Length;

        float targetIntensity = Mathf.Clamp01(amplitude * intensityMultiplier);
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * smoothSpeed);

        sphereMaterial.SetColor("_EmissionColor", baseColor * currentIntensity);
    }
}
