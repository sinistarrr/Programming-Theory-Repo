using System;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public string PlayerName { get; set; }
    public TMP_Text PlayerNameText { get; private set; }

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

    public void VariablesInit(){
        PlayerNameText = GameObject.FindWithTag("Player Name").GetComponent<TMP_Text>();
        PlayerNameText.text = "Player : " + PlayerName + ".";
    }
}
