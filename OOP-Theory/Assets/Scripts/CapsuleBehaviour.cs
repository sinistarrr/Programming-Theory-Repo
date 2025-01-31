using UnityEngine;

public class CapsuleBehaviour : ShapeBehaviour // INHERITANCE
{
    protected override string Type // POLYMORPHISM
    {
        get
        {
            return "Capsule";
        }
    }
}
