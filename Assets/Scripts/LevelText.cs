using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Text))]
public class LevelText : MonoBehaviour
{
    public int levelNumber; // Le numéro du niveau à afficher

    [SerializeField] 
    private Text levelText; // Référence au composant Text

    void Awake()
    {
        // Obtenez le composant Text attaché à cet objet
        levelText = GetComponent<Text>();
    }

    void Update()
    {
        // Mettez à jour le texte pour afficher "Part {levelNumber}"
        levelText.text = $"Part {levelNumber}";
    }

    // Appeler cette méthode pour mettre à jour le numéro de niveau
    public void SetLevelNumber(int newLevel)
    {
        levelNumber = newLevel;
    }
}
