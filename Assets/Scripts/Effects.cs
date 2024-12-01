// Ce script gère les effets visuels des boutons, comme le changement de couleur lors de l'interaction avec l'utilisateur.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=O5st1akja5o&t=72s
public class Effects : MonoBehaviour
{
    public void ChangeBtnColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.red;
        cb.pressedColor = Color.black;
        button.colors = cb;
    }

    public void ResetBtnColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.gray;
        cb.pressedColor = Color.gray;
        button.colors = cb;
    }
}
