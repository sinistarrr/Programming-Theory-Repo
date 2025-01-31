using System;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public string PlayerName { get; set; } // ENCAPSULATION
    public TMP_Text PlayerNameText { get; private set; } // ENCAPSULATION

    public static MainManager Instance;

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

    }

    public void VariablesInit(){ // ENCAPSULATION
        PlayerNameText = GameObject.FindWithTag("Player Name").GetComponent<TMP_Text>();
        PlayerNameText.text = "Player : " + PlayerName + "."; 
    }
}
