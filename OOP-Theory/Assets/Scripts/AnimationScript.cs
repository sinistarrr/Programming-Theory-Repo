using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{
    [field: SerializeField] public bool IsAnimated { get; set; } = false; // ENCAPSULATION

    [field: SerializeField] public bool IsRotating { get; set; } = false; // ENCAPSULATION
    [field: SerializeField] public bool IsFloating { get; set; } = false; // ENCAPSULATION
    [field: SerializeField] public bool IsScaling { get; set; } = false; // ENCAPSULATION

    [field: SerializeField] public Vector3 rotationAngle { get; set; } // ENCAPSULATION
    [field: SerializeField] public float RotationSpeed { get; set; } // ENCAPSULATION

    [field: SerializeField] public float FloatSpeed { get; set; } // ENCAPSULATION
    [field: SerializeField] public float FloatRate { get; set; } // ENCAPSULATION

    [field: SerializeField] public Vector3 StartScale { get; set; } // ENCAPSULATION
    [field: SerializeField] public Vector3 EndScale { get; set; } // ENCAPSULATION
    [field: SerializeField] public float ScaleSpeed { get; set; } // ENCAPSULATION
    [field: SerializeField] public float ScaleRate { get; set; } // ENCAPSULATION
    
    private bool GoingUp { get; set; } = true; // ENCAPSULATION
    private float FloatTimer { get; set; } // ENCAPSULATION
    private bool ScalingUp { get; set; } = true; // ENCAPSULATION
    private float ScaleTimer { get; set; } // ENCAPSULATION

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (IsAnimated)
        {
            RotationHandler(); // ABSTRACTION
            FloatingHandler(); // ABSTRACTION 
            ScalingHandler(); // ABSTRACTION
        }
    }

    private void RotationHandler() // ENCAPSULATION
    {
        if (IsRotating)
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * rotationAngle);
        }
    }
    private void FloatingHandler() // ENCAPSULATION
    {
        if (IsFloating)
        {
            MoveFloatingObject(); // ABSTRACTION
            ManageFloatingDirection(); // ABSTRACTION
        }
    }

    private void ScalingHandler() // ENCAPSULATION
    {
        if (IsScaling)
        {
            ScaleObject(); // ABSTRACTION
            ManageScalingDirection(); // ABSTRACTION
        }

    }

    private void ScaleObject() // ENCAPSULATION
    {
        if (ScalingUp)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, EndScale, ScaleSpeed * Time.deltaTime);
        }
        else if (!ScalingUp)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, StartScale, ScaleSpeed * Time.deltaTime);
        }
    }

    private void ManageScalingDirection() // ENCAPSULATION
    {
        ScaleTimer += Time.deltaTime;

        if (ScaleTimer >= ScaleRate)
        {
            if (ScalingUp)
            {
                ScalingUp = false;
            }
            else if (!ScalingUp)
            {
                ScalingUp = true;
            }
            ScaleTimer = 0;
        }
    }

    private void MoveFloatingObject() // ENCAPSULATION
    {
        FloatTimer += Time.deltaTime;
        Vector3 moveDir = new Vector3(0.0f, FloatSpeed, 0.0f);
        transform.Translate(moveDir);
    }

    private void ManageFloatingDirection() // ENCAPSULATION
    {
        if (GoingUp && FloatTimer >= FloatRate)
        {
            GoingUp = false;
            FloatTimer = 0;
            FloatSpeed = -FloatSpeed;
        }

        else if (!GoingUp && FloatTimer >= FloatRate)
        {
            GoingUp = true;
            FloatTimer = 0;
            FloatSpeed = +FloatSpeed;
        }
    }
}
