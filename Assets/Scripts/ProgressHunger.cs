using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressHunger : MonoBehaviour
{

    Image bar;
    Text txt;

    public Color AlertColor = Color.red;
    Color startColor;

    public float alert = 25f;
    private float val;

    public float Val {
        get {
            return val;
        }
        set {
            val = value;
            val = Mathf.Clamp(val, 0, 100); // Clamping the value directly
            UpdateValue();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        txt = bar.transform.Find("Text").GetComponent<Text>();
        startColor = bar.color;
        Val = 100;
    }
    
        void UpdateValue() {
        txt.text = Math.Round(val) + "%"; // Changed from txt.Text to txt.text
        bar.fillAmount = val / 100;
        if(val<=alert){
            bar.color = AlertColor;
        }
        else{
            bar.color = startColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Math.Round(Val -= 0.01f);
        
    }
}
