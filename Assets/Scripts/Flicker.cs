using System.Collections;
using UnityEngine;

// https://assetstore.unity.com/packages/3d/props/interior/old-torch-203664#content

public class Flickert : MonoBehaviour
{
    Vector3 _startPosLight;
    [Tooltip("The light attached to this script")]
    public Light lig;
    [Tooltip("The light color")]
    public Color colorLight = Color.white;
    [Space]
    [Tooltip("The minimum Intensity Light")]
    public float min = 0.0f;
    [Tooltip("The maximum Intensity Light")]
    public float max = 2.0f;
    [Space(20)]
    private float _flickIntensity;
    [Tooltip("The timing of the speed for flick Intensity of the light")]
    public float timer = 1.0f;
    [Tooltip("The waiting time for the light to flicker")]
    public float smooth = 0.1f;
    [Space(10)]
    [Header("Set a false movement of the shadow")]
    [Space(10)]
    public bool moveShadow = false;
    [Tooltip("The speed of the movement of light")]
    public float speedMoveShadow = 1f;
    [Tooltip("The speed smooth of the movement of light")]
    public float speedSmoothShadow = 50f;
    
    [Header("Stop Flickering After Time")]
    [Tooltip("Time in seconds after which the light stops flickering")]
    public float stopAfterTime = 10.0f; 
    private float _flickerTimer;
    private bool _isFlickering = true;  

    AudioSource audioSource ;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (lig == null)
        {
            lig = GetComponent<Light>();
            _startPosLight = lig.transform.position;
        }

        _flickerTimer = stopAfterTime; 
        StartCoroutine(SmoothFLick());
    }

    // Update is called once per frame
    void Update()
    {
        if (lig == null)
            return;

        if (_isFlickering)
        {
            StartCoroutine(SmoothFLick());
        }
        
        MoveShadowLight();

        // Countdown the flickering timer
        _flickerTimer -= Time.deltaTime;

        if (_flickerTimer <= 0 && _isFlickering)
        {
            StopFlickering();
        }
    }

    private IEnumerator SmoothFLick()
    {
        if (_isFlickering)
        {
            _flickIntensity = Mathf.Lerp(_flickIntensity, (Random.Range(min, max)), timer * Time.smoothDeltaTime);
            lig.intensity = _flickIntensity;
            lig.color = colorLight;
            yield return new WaitForSeconds(smooth);
        }
    }

    void MoveShadowLight()
    {
        if (moveShadow)
        {
            lig.transform.position = _startPosLight + (Random.insideUnitSphere * speedMoveShadow / speedSmoothShadow);
        }
        else
        {
            moveShadow = false;
            lig.transform.position = _startPosLight;
        }
    }

    // Jenna
    void StopFlickering()
    {
        _isFlickering = false;
        lig.intensity = min;  
        audioSource.mute = true;

        
    }
}
