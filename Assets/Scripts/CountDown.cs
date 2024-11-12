using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class CountDown : MonoBehaviour
{
    [SerializeField]  // Attribut correctement écrit
    private int startCountDown = 10;
 
    [SerializeField]  // Attribut correctement écrit
    private Text TxtCountDown;
 
    // Start is called before the first frame update
    void Start()
    {
        TxtCountDown.text = "TimeLeft : " + startCountDown;
        StartCoroutine(Pause());
    }
 
    IEnumerator Pause()
    {
        while (startCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            startCountDown--;
            TxtCountDown.text = "TimeLeft : " + startCountDown;
        }
         SceneManager.LoadScene ("Menu");
        Debug.Log("Game over");
    }
}