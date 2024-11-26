using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string playScene; 
    [SerializeField] RectTransform fader;


    //https://stackoverflow.com/questions/39900445/unity3d-c-sharp-cursor-keeps-being-pulled-back-to-the-center-of-the-screen
    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
    //https://www.youtube.com/watch?v=JNjLCAheWSc
    public void Play()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(playScene);
        });

        
        
    }

    //https://stackoverflow.com/questions/70437401/cannot-finish-the-game-in-unity-using-application-quit
    public void Exit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
          }
    }

