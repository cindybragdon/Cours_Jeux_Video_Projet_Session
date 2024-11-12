using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;  // The light source to flicker
    public float minIntensity = 0.5f;  // Minimum light intensity
    public float maxIntensity = 1.5f;  // Maximum light intensity
    public float flickerSpeed = 0.1f;  // Speed of flickering effect

    private float timer = 0f;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();  // Try to get the Light component if not set
        }
    }

    void Update()
    {
        // Update the timer based on the flicker speed
        timer += Time.deltaTime * flickerSpeed;

        // Create a random flicker effect by modifying the intensity
        lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(timer, 0f));

        // You can also adjust the flicker more sharply if you want a more random effect
        // lightSource.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
