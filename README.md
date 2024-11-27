# 2 DAYS OF DARKNESS
Jeu Projet de Session  
**TEAM MIDNIGHT STUDIO** | Étudiants DEC 3ième année  

---

## :label: Table des matières

- [Contexte du travail](#contexte-du-travail)
- [Équipe et rôles](#équipe-et-rôles)
- [Description générale du jeu](#description-générale-du-jeu)
- [Conception technique](#conception-technique)
- [Design des niveaux](#design-des-niveaux)
- [Tests et validation](#tests-et-validation)
- [Annexes](#annexes)

---

## :bookmark_tabs: Contexte du travail

Ce projet est réalisé dans le cadre du cours **Développement de jeu vidéo** supervisé par **Sofiane Faïdi**. L'objectif est de concevoir, développer, et livrer un jeu vidéo complet en appliquant des concepts de programmation orientée objet et données.

---

## :busts_in_silhouette: Équipe et rôles

| Nom                       | Rôles                                                                 |
|---------------------------|----------------------------------------------------------------------|
| **Cindy Bragdon**         | Scrum Master, développeur, testeuse, documentation technique         |
| **Jenna-Lee Lecavalier**  | Développeur, conceptrice de niveaux, scénariste                     |
| **Nissia Lesline Gansaore** | Développeur, artiste 2D, testeuse                                  |
| **Olivier Poirier**       | Développeur, sound designer, game designer                         |
| **Chadi El Chami**        | Développeur, artiste 2D, concepteur de niveaux                     |

---

## :video_game: Description générale du jeu

### Contexte narratif
Lewis, isolé dans une maison ancestrale après un événement mystérieux, doit survivre dans un environnement hostile où des créatures malveillantes l’assaillent.

### Genre du jeu
Horreur - Escape Room à la première personne mêlant :  
- Exploration  
- Combat  
- Résolution d’énigmes  
- Gestion du temps  

### Mécaniques principales
- **Exploration** : Fouille de l’environnement pour trouver des indices.  
- **Combat** : Affronter les créatures malveillantes.  
- **Résolution d’énigmes** : Déchiffrer des indices pour progresser.  
- **Gestion du temps** : Terminer les objectifs avant le temps imparti.

---

## :toolbox: Conception technique

### Outils et technologies utilisées
<table>
  <tr>
    <td><img src="https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white"></td>
    <td><img src="https://img.shields.io/badge/CSharp-239120?style=for-the-badge&logo=csharp&logoColor=white"></td>
  </tr>
  <tr>
    <td><img src="https://img.shields.io/badge/Mixamo-FF8135?style=for-the-badge&logo=adobe&logoColor=white"></td>
    <td><img src="https://img.shields.io/badge/AssetStore-000000?style=for-the-badge&logo=unity&logoColor=white"></td>
  </tr>
  <tr>
    <td><img src="https://img.shields.io/badge/NUnit-5F56B2?style=for-the-badge&logo=nunit&logoColor=white"></td>
    <td><img src="https://img.shields.io/badge/SonarQube-4E9BCD?style=for-the-badge&logo=sonarqube&logoColor=white"></td>
  </tr>
</table>

### Architecture des scripts
1. **Gestion du jeu** : Contrôle de l'interface utilisateur, des sons, et des transitions.  
2. **Player Controller** : Déplacements et interactions du joueur.  
3. **Enemy Controller** : Comportements des ennemis.  
4. **Énigmes** : Interaction avec les objets comme la clé.

### Organisation des assets
- **3D Models** : Modèles des personnages et objets.  
- **Textures** : Textures des modèles et de l’environnement.  
- **Audio** : Musique et effets sonores.  
- **UI** : Éléments graphiques pour les menus et indicateurs.  

---

## :world_map: Design des niveaux

### Cartographie des niveaux
- **Niveau 1** : Exploration et résolution d’énigmes dans le grenier.  
- **Niveau 2** : Une chambre principale mystérieuse et plus difficile.  

### Progression
Le joueur fait face à une difficulté croissante, introduisant de nouvelles mécaniques et ennemis.

---

## :white_check_mark: Tests et validation

### Stratégie de test
Tests réalisés avec **NUnit** et couverture analysée via **SonarQube** :  
1. Tests manuels par les membres de l’équipe.  
2. Validation des mécaniques principales (déplacement, combat, énigmes).  
3. Observation des comportements ennemis et transitions fluides entre les scènes.

### Corrections
- Ajustements des collisions.  
- Amélioration des scripts ennemis.  
- Correction des transitions entre scènes.  
- Rééquilibrage de la difficulté.

---

## :page_facing_up: Annexes

- Liens vers les ressources : musiques, textures, assets 3D.
- Schémas et captures d’écran des niveaux.  

"Initialement, le jeu s'appelait *7 Days of Darkness*. Aujourd'hui, c'est *15 Minutes of Mild Anxiety*. On s'adapte."
