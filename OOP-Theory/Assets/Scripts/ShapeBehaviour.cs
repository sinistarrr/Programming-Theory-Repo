using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class ShapeBehaviour : MonoBehaviour
{
    abstract protected string Type { get;} // POLYMORPHISM // ENCAPSULATION

    protected Outline OutlineScript { get; private set;} // ENCAPSULATION
    [field: SerializeField] public GameObject ShapeDescription {get; set;} // ENCAPSULATION
    [field: SerializeField] public string Name { get; set;} // ENCAPSULATION
    private TextMeshProUGUI SelectedText {get; set;} // ENCAPSULATION

    private bool textIsEnabled {get; set;} // ENCAPSULATION
    

    protected void Start() // ENCAPSULATION
    {
        OutlineScript = GetComponent<Outline>();
        SelectedText = GameObject.FindGameObjectWithTag("Selected").GetComponent<TextMeshProUGUI>();
    }

    protected void Update() // ENCAPSULATION
    {
        
    }

    protected void OnMouseOver() // ENCAPSULATION
    {
        OutlineScript.enabled = true;
    }

    protected void OnMouseExit() // ENCAPSULATION
    {
        OutlineScript.enabled = false;
    }

    protected void OnMouseDown() // ENCAPSULATION
    {
        // Debug.Log("I am a " + Type + " !");
        textIsEnabled = !textIsEnabled;
        SelectedText.text = "Selected shape : " + Name + " the " + Type + "."; // POLYMORPHISM
        DisplayText(textIsEnabled); // ABSTRACTION
    }

    protected void DisplayText(bool enabled){ // ENCAPSULATION
        ShapeDescription.SetActive(enabled);
    }
}
