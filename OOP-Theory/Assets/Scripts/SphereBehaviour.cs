using UnityEngine;

public class SphereBehaviour : ShapeBehaviour // INHERITANCE
{
    protected override string Type // POLYMORPHISM
    {
        get
        {
            return "Sphere";
        }
    }

}
