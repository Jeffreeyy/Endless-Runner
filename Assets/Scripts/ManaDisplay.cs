using UnityEngine;
using System.Collections;

public class ManaDisplay : MonoBehaviour {

    void OnGUI()
    {
        GUILayout.Label("Mana: " + Player.mana);
    }  
}
