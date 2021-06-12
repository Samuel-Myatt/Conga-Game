using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    CarController controller;
    public GameObject GameHandler;

    float timer = 0;

    private void Awake()
    {
        controller = GetComponent<CarController>();
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        Vector2 inputVec = Vector2.zero;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        controller.SetInputVec(inputVec);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pedestrian")
        {
            if(timer > 360)
			{
                Destroy(other.gameObject);
                timer = 0;
                GameHandler.GetComponent<GameHandler>().SpawnFollower();
            }
            Debug.Log("cum");
        }
    }
}