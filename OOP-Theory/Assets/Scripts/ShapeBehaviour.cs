using System;
using UnityEngine;

public abstract class ShapeBehaviour : MonoBehaviour
{
    abstract protected string Type { get;}

    protected Outline OutlineScript { get; private set;}
    public Color ShapeColor { get; private set; }
    public string Name { get; set;}
    

    protected void Start()
    {
        OutlineScript = GetComponent<Outline>();
        ShapeColor = gameObject.GetComponent<MeshRenderer>().material.color;
        Debug.Log(OutlineScript == null);
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
        DisplayText();
    }

    protected abstract void DisplayText();
}
