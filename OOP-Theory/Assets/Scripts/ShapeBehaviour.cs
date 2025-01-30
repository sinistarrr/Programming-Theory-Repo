using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class ShapeBehaviour : MonoBehaviour
{
    abstract protected string Type { get;}

    protected Outline OutlineScript { get; private set;}
    [field: SerializeField] public GameObject ShapeDescription {get; set;}
    [field: SerializeField] public string Name { get; set;}
    private TextMeshProUGUI SelectedText {get; set;}

    private bool textIsEnabled {get; set;}
    

    protected void Start()
    {
        OutlineScript = GetComponent<Outline>();
        SelectedText = GameObject.FindGameObjectWithTag("Selected").GetComponent<TextMeshProUGUI>();
    }

    protected void Update()
    {
        
    }

    protected void OnMouseOver()
    {
        OutlineScript.enabled = true;
    }

    protected void OnMouseExit()
    {
        OutlineScript.enabled = false;
    }

    protected void OnMouseDown()
    {
        // Debug.Log("I am a " + Type + " !");
        textIsEnabled = !textIsEnabled;
        SelectedText.text = "Selected shape : " + Name + " the " + Type + ".";
        DisplayText(textIsEnabled);
    }

    protected void DisplayText(bool enabled){
        ShapeDescription.SetActive(enabled);
    }
}
