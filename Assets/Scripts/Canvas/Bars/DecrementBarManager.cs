using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecrementBarManager : MonoBehaviour
{
    public float valueToReduceBar = 1f;

    public float valueReduceBar = 1f;
    private float comptorCalculateTime = 0f;

    public Slider slider;

    public Text textBar;
    void Start()
    {
        slider.value = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            comptorCalculateTime += Time.deltaTime;
            Debug.Log("comptor food using:" + comptorCalculateTime);
        }

        if(comptorCalculateTime >= valueToReduceBar) {
            slider.value -= valueReduceBar;
            comptorCalculateTime = 0;
            textBar.text = slider.value.ToString() + "%";
        }
    }
}
