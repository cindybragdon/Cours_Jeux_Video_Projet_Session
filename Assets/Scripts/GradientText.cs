using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Text))]
public class GradientText : BaseMeshEffect
{
    public Color topColor = Color.red;       // Couleur en haut (rouge)
    public Color bottomColor = Color.white;   // Couleur en bas (blanc)
    public Color borderColor = Color.black;   // Couleur de la bordure
    public float borderSize = 1.0f;           // Taille de la bordure

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive())
            return;

        // Obtenir le nombre actuel de sommets
        int count = vh.currentVertCount;

        // Créer un tableau pour stocker les sommets d'origine
        UIVertex vertex = new UIVertex();

        // Appliquer une bordure autour de chaque lettre
        for (int i = 0; i < count; i += 4)
        {
            // Appliquer la couleur de la bordure pour chaque sommet
            for (int j = 0; j < 4; j++)
            {
                vh.PopulateUIVertex(ref vertex, i + j);
                vertex.color = borderColor;

                // Déplacer chaque sommet pour créer la bordure
                Vector3 positionOffset = Vector3.zero;
                switch (j)
                {
                    case 0: positionOffset = new Vector3(-borderSize, borderSize, 0); break; // Haut gauche
                    case 1: positionOffset = new Vector3(borderSize, borderSize, 0); break;  // Haut droit
                    case 2: positionOffset = new Vector3(borderSize, -borderSize, 0); break; // Bas droit
                    case 3: positionOffset = new Vector3(-borderSize, -borderSize, 0); break; // Bas gauche
                }

                vertex.position += positionOffset; // Appliquer le décalage
                vh.SetUIVertex(vertex, i + j); // Définir le sommet avec la bordure
            }
        }

        // Appliquer le dégradé vertical pour chaque lettre
        for (int i = 0; i < count; i += 4)
        {
            vh.PopulateUIVertex(ref vertex, i);
            vertex.color = topColor; // Haut gauche
            vh.SetUIVertex(vertex, i);

            vh.PopulateUIVertex(ref vertex, i + 1);
            vertex.color = topColor; // Haut droit
            vh.SetUIVertex(vertex, i + 1);

            vh.PopulateUIVertex(ref vertex, i + 2);
            vertex.color = bottomColor; // Bas droit
            vh.SetUIVertex(vertex, i + 2);

            vh.PopulateUIVertex(ref vertex, i + 3);
            vertex.color = bottomColor; // Bas gauche
            vh.SetUIVertex(vertex, i + 3);
        }
    }
}
