using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{

    [field: SerializeField] public bool IsAnimated { get; set; } = false;

    [field: SerializeField] public bool IsRotating { get; set; } = false;
    [field: SerializeField] public bool IsFloating { get; set; } = false;
    [field: SerializeField] public bool IsScaling { get; set; } = false;

    [field: SerializeField] public Vector3 rotationAngle { get; set; }
    [field: SerializeField] public float RotationSpeed { get; set; }

    [field: SerializeField] public float FloatSpeed { get; set; }
    [field: SerializeField] public float FloatRate { get; set; }

    [field: SerializeField] public Vector3 StartScale { get; set; }
    [field: SerializeField] public Vector3 EndScale { get; set; }
    [field: SerializeField] public float ScaleSpeed { get; set; }
    [field: SerializeField] public float ScaleRate { get; set; }

    private bool GoingUp { get; set; } = true;
    private float FloatTimer { get; set; }
    private bool ScalingUp { get; set; } = true;
    private float ScaleTimer { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (IsAnimated)
        {
            RotationHandler();
            FloatingHandler();
            ScalingHandler();
        }
    }

    private void RotationHandler()
    {
        if (IsRotating)
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * rotationAngle);
        }
    }
    private void FloatingHandler()
    {
        if (IsFloating)
        {
            FloatTimer += Time.deltaTime;
            Vector3 moveDir = new Vector3(0.0f, FloatSpeed, 0.0f);
            transform.Translate(moveDir);

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

    private void ScalingHandler()
    {
        if (IsScaling)
        {
            ScaleTimer += Time.deltaTime;

            if (ScalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, EndScale, ScaleSpeed * Time.deltaTime);
            }
            else if (!ScalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, StartScale, ScaleSpeed * Time.deltaTime);
            }

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

    }
}
