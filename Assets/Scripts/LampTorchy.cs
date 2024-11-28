using UnityEngine;

public class LightToggleController : MonoBehaviour
{
    public Light lightSource;
    public AudioSource audioSource;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.mute = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        if (lightSource != null)
        {
            lightSource.enabled = !lightSource.enabled;

            if (lightSource.enabled)
            {
                lightSource.intensity = 10.0f;
            }
            else
            {
                lightSource.intensity = 0f;
            }

            if (audioSource != null)
            {
                audioSource.mute = false;
                audioSource.Play();
            }

        }

    }
}
