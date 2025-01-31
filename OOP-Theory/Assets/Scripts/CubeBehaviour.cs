using UnityEngine;

public class CubeBehaviour : ShapeBehaviour // INHERITANCE
{
    protected override string Type // POLYMORPHISM
    {
        get
        {
            return "Cube";
        }
    }
}
