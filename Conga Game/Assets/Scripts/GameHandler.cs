using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

   
    

    public GameObject Follower;
    public GameObject Leader;
    List<GameObject> Queue;

    float test = 0;

    int QueueCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Queue = new List<GameObject>();
        Leader = GameObject.FindGameObjectWithTag("Leader");
       
        SpawnFollower();
       
    }
    
    public void SpawnFollower()
	{
        if(QueueCount == 0)
        { 
            GameObject a = (Instantiate(Follower, new Vector3(Leader.transform.position.x, Leader.transform.position.y, 0), transform.rotation) as GameObject);
            a.GetComponent<Follow>().Target = Leader.transform;
            Queue.Add(a);
            QueueCount++;
        }
        else
		{

            GameObject a = (Instantiate(Follower, new Vector3(Queue[QueueCount-1].transform.position.x, Queue[QueueCount - 1].transform.position.y, 0), transform.rotation) as GameObject);
            a.GetComponent<Follow>().Target = Queue[QueueCount - 1].transform;
            Queue.Add(a);

            QueueCount++;
        }
        
	}
    // Update is called once per frame
    void Update()
    {
        test++; 
        if(test == 360)
		{
            //SpawnFollower();
            test = 0;
        }
        
    }
}
