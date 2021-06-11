using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car")]
    public float accFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.95f;
    public float maxSpeed = 20;
    public float speed;


    public float accInput = 0;
    float steerInput = 0;

    float rotAngle = 0;

    public float VelocityUp = 0;

    Rigidbody2D carRb;


    public float accFactorBoost = 100f;
    public float maxSpeedBoost = 40f;
    float accFactorStart;
    float maxSpeedStart;
    public bool currentlyplaying;






    private void Awake()
    {
        carRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        accFactorStart = accFactor;
        maxSpeedStart = maxSpeed;
    }
    private void Update()
    {

        accInput = 1f;
        accFactor = accFactorStart;
        maxSpeed = maxSpeedStart;




    }

    private void FixedUpdate()
    {
        EngineForce();
        DampenMovement();
        Steering();

    }

    void EngineForce()
    {

        VelocityUp = Vector2.Dot(transform.up, carRb.velocity);
        speed = VelocityUp;
        if (VelocityUp > maxSpeed && accInput > 0)
        {
            return;
        }
        if (VelocityUp < -maxSpeed * 0.5f && accInput < 0)
        {
            return;
        }

        if (carRb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accInput > 0)
        {
            return;
        }




        Vector2 forceVector = transform.up * accInput * accFactor;



        carRb.AddForce(forceVector, ForceMode2D.Force);
    }

    void Steering()
    {
        float minSpeedToTurn = (carRb.velocity.magnitude / 8);
        minSpeedToTurn = Mathf.Clamp01(minSpeedToTurn);

        rotAngle -= steerInput * turnFactor * minSpeedToTurn;

        carRb.MoveRotation(rotAngle);
    }

    public void SetInputVec(Vector2 inputVec)
    {
        steerInput = inputVec.x;
        
    }

    float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, carRb.velocity);
    }

    public bool isCarDrifting(out float lateralVelocity, out bool isBreaking)
    {
        lateralVelocity = GetLateralVelocity();
        isBreaking = false;

        if (accInput < 0 && VelocityUp > 0)
        {
            isBreaking = true;
            return true;
        }
        if (Mathf.Abs(GetLateralVelocity()) > 4.0f)
        {
            return true;
        }

        return false;
    }

    void DampenMovement()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRb.velocity, transform.right);

        carRb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

}
