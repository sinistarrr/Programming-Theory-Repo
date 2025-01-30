using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class ShapeBehaviour : MonoBehaviour
{
    abstract protected string Type { get;}

    protected Outline OutlineScript { get; private set;}
    public GameObject ShapeDescription;
    [field: SerializeField] public string Name { get; set;}

    private bool textIsEnabled {get; set;}
    

    protected void Start()
    {
        OutlineScript = GetComponent<Outline>();
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
        Debug.Log("I am a " + Type + " !");
        textIsEnabled = !textIsEnabled;
        DisplayText(textIsEnabled);
    }

    protected void DisplayText(bool enabled){
        ShapeDescription.SetActive(enabled);
    }
}
