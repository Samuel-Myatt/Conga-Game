using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    CarController controller;
    public GameObject GameHandler;

    int colour;

    private void Awake()
    {
        controller = GetComponent<CarController>();
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 inputVec = Vector2.zero;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        controller.SetInputVec(inputVec);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pedestrian")
        {
            
            colour = other.GetComponent<Pedestrian>().Colour;
            Destroy(other.gameObject);

            GameHandler.GetComponent<GameHandler>().SpawnFollower(colour);

            Debug.Log("cum");
        }
        else if(other.tag == "Wall")
		{
            Debug.Log("lose");
        }
    }

 
}