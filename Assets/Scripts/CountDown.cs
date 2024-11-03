using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class CountDown : MonoBehaviour
{
    [SerializeField]  // Attribut correctement écrit
    private int startCountDown = 60;
 
    [SerializeField]  // Attribut correctement écrit
    private Text TextCountDown;
 
    // Start is called before the first frame update
    void Start()
    {
        TextCountDown.text = "TimeLeft : " + startCountDown;
        StartCoroutine(Pause());
    }
 
    IEnumerator Pause()
    {
        while (startCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            startCountDown--;
            TextCountDown.text = "Time before you die : " + startCountDown;
        }
         SceneManager.LoadScene ("CanvasStartEntree");
        Debug.Log("Game over");
        Application.Quit();
        
    }
}