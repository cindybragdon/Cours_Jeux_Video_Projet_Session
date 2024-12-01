// Ce script gère le menu principal d'un jeu. Il permet de lancer une scène de jeu ou de quitter l'application.
// Lors du démarrage, il déverrouille le curseur et le rend visible.
// La méthode Play gère une animation de fondu avant de charger la scène de jeu.
// La méthode Exit permet de quitter le jeu, que ce soit en mode autonome ou en mode éditeur.

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string playScene; 
    [SerializeField] RectTransform fader;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(playScene);
        });
    }

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
