using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    CarController controller;

    private void Awake()
    {
        controller = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVec = Vector2.zero;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        controller.SetInputVec(inputVec);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pedestrian")
        {
            Debug.Log("cum");
        }
    }
}