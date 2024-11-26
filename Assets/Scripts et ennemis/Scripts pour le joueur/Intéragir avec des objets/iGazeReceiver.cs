using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.immersivelimit.com/detect-when-looking-at-object

//Ceci est une inteface.

//Elle sert uniquement à obliger les objets qui ont des intéractions d'avoir des fonctions
// Nommées "GazingUpon" et "NotGazingUpon" pour que le script GazeManager
// et seenObjectBehav fonctionnent ensemble. 
//Ça oblige les programmeurs à écrire les fonctions de la bonne façon.
public interface iGazeReceiver
{
/// <summary>
/// Should be called when the object is being looked at
/// </summary>
void GazingUpon();

/// <summary>
/// Should be called when the object is no longer being looked at
/// </summary>
void NotGazingUpon();

}
