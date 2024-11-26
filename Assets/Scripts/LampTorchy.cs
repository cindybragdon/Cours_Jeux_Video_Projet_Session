using UnityEngine;

public class LightToggleController : MonoBehaviour
{
    public Light lightSource;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
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
    }
    else
    {
        Debug.LogError("Light source is not assigned.");
    }
}

}
