# 2 DAYS OF DARKNESS
Jeu Projet de Session  
**TEAM MIDNIGHT STUDIO** | Étudiants DEC 3ième année  

![image](https://github.com/user-attachments/assets/57e20959-a622-41cc-a759-4c980038a3fe)
---
## Voir la vidéo sur Youtube! 
:movie_camera:  :arrow_down: <br>
[![Vidéo YouTube](https://img.youtube.com/vi/xcGxfcOstg8/0.jpg)](https://youtu.be/xcGxfcOstg8)
---

![image](https://github.com/user-attachments/assets/a4a097bf-512a-44d1-9a61-320b9f01fb45)


![image](https://github.com/user-attachments/assets/6e55471c-2757-4177-aa4f-c150c0a55f09)


![image](https://github.com/user-attachments/assets/9447accb-a244-47ee-aebd-0d0e43d2ca74)

![image](https://github.com/user-attachments/assets/6a23e455-2908-4884-83db-7c17049960e8)


![image](https://github.com/user-attachments/assets/552cd511-565e-4abd-8cf8-f442e9664467)


![image](https://github.com/user-attachments/assets/f0352b58-64d8-4103-94d1-f649255815aa)

![image](https://github.com/user-attachments/assets/40216425-917a-4dfb-9fef-3950124d9938)

![image](https://github.com/user-attachments/assets/ddc0e28a-c7b9-4a85-8a7e-8ca389a5dbea)


![image](https://github.com/user-attachments/assets/d9376ae1-18fa-4f1f-a494-20e7d4fb3c7c)


---

## :label: Table des matières

- [Contexte du travail](#contexte-du-travail)
- [Equipe et roles](#equipe-et-roles)
- [Description generale du jeu](#description-generale-du-jeu)
- [Conception technique](#conception-technique)
- [Design des niveaux](#design-des-niveaux)
- [Tests et validation](#tests-et-validation)
- [Annexes](#annexes)

---

## Contexte du travail
:bookmark_tabs:
Ce projet est réalisé dans le cadre du cours **Développement de jeu vidéo** supervisé par **Sofiane Faïdi**. L'objectif est de concevoir, développer, et livrer un jeu vidéo complet en appliquant des concepts de programmation orientée objet et données.

---

## Equipe et roles
:busts_in_silhouette:
| Nom                       | Rôles                                                                 |
|---------------------------|----------------------------------------------------------------------|
| **Cindy Bragdon**         | Scrum Master, développeur, testeuse, documentation technique         |
| **Jenna-Lee Lecavalier**  | Développeur, conceptrice de niveaux, scénariste                     |
| **Nissia Lesline Gansaore** | Développeur, artiste 2D, testeuse                                  |
| **Olivier Poirier**       | Développeur, sound designer, game designer                         |
| **Chadi El Chami**        | Développeur, artiste 2D, concepteur de niveaux                     |

---

<p align="center">
  <a href="https://github.com/cindybragdon">
    <img src="https://github.com/cindybragdon.png?size=64" width="64" height="64" alt="Cindy" style="border-radius: 50%; overflow: hidden;">
  </a>
  <a href="https://github.com/olivierpoirier">
    <img src="https://github.com/olivierpoirier.png?size=64" width="64" height="64" alt="Olivier" style="border-radius: 50%; overflow: hidden;">
  </a>
  <a href="https://github.com/JennaLeeL">
    <img src="https://github.com/JennaLeeL.png?size=64" width="64" height="64" alt="Jenna" style="border-radius: 50%; overflow: hidden;">
  </a>
  <a href="https://github.com/NotaroNissia">
    <img src="https://github.com/NotaroNissia.png?size=64" width="64" height="64" alt="Nissia" style="border-radius: 50%; overflow: hidden;">
  </a>
  <a href="https://github.com/ChadiEC">
    <img src="https://github.com/ChadiEC.png?size=64" width="64" height="64" alt="Chadi" style="border-radius: 50%; overflow: hidden;">
  </a>
</p>
---

## Description generale du jeu
:video_game:
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

## Conception technique
:toolbox:
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

## Design des niveaux
:world_map:
### Cartographie des niveaux
- **Niveau 1** : Exploration et résolution d’énigmes dans le grenier.  
- **Niveau 2** : Une chambre principale mystérieuse et plus difficile.  

### Progression
Le joueur fait face à une difficulté croissante, introduisant de nouvelles mécaniques et ennemis.

---

## Tests et validation
:white_check_mark:
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

## Annexes
:page_facing_up:
•	https://assetstore.unity.com/
•	https://www.mixamo.com/#/
•	https://uppbeat.io/browse/sfx/gaming


"Initialement, le jeu s'appelait *7 Days of Darkness*. Aujourd'hui, c'est *15 Minutes of Mild Anxiety*. On s'adapte."
