using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

   
    

    public GameObject Follower;
    public GameObject Leader;
    public List<GameObject> Queue;

    float test = 0;

    int QueueCount = 0;

    int selected = 0;

    int chosen;

    bool beenChosen = false;
    // Start is called before the first frame update
    void Start()
    {
        Queue = new List<GameObject>();
        Leader = GameObject.FindGameObjectWithTag("Leader");
       
        SpawnFollower(1);
       
    }
    
    public void SpawnFollower(int Col)
	{
        if(QueueCount == 0)
        { 
            GameObject a = (Instantiate(Follower, new Vector3(Leader.transform.position.x, Leader.transform.position.y, 0), transform.rotation) as GameObject);
            a.GetComponent<Follow>().Target = Leader.transform;
            a.GetComponent<Follow>().Colour = Col;
            Queue.Add(a);
            QueueCount++;
        }
        else
		{

            GameObject a = (Instantiate(Follower, new Vector3(Queue[QueueCount-1].transform.position.x, Queue[QueueCount - 1].transform.position.y, 0), transform.rotation) as GameObject);
            a.GetComponent<Follow>().Target = Queue[QueueCount - 1].transform;
            a.GetComponent<Follow>().Colour = Col;
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


        if (Input.GetMouseButtonDown(0))
		{
            if(selected == QueueCount-1)
			{
                Queue[selected].GetComponent<Follow>().UnSelected();
                selected = 0;
			}
            else
			{
                Queue[selected].GetComponent<Follow>().UnSelected();
                selected++;
            }
            
		}
        if (Input.GetMouseButtonDown(1))
        {
            if (selected == 0)
            {
                Queue[selected].GetComponent<Follow>().UnSelected();
                selected = QueueCount-1;
            }
            else
			{
                Queue[selected].GetComponent<Follow>().UnSelected();
                selected--;
            }
        }

        if (Input.GetKeyDown("space"))
		{
            if(beenChosen)
			{
                //selected colour to become chosens colour
                //then the next in the line to become selecteds old colour
                //then just continue till the end
                if(chosen < selected)
				{
                    //selected decrease
                    int temp = Queue[selected].GetComponent<Follow>().Colour;
                    Queue[selected].GetComponent<Follow>().Colour = Queue[chosen].GetComponent<Follow>().Colour;
                    for (int i = 1; i < (selected - chosen); i++)
                    {
                        int temp2 = Queue[selected - i].GetComponent<Follow>().Colour;
                        Queue[selected - i].GetComponent<Follow>().Colour = temp;
                        temp = temp2;
                    }
                    //chosen = null;
                    Queue[chosen].GetComponent<Follow>().UnSelected();
                    beenChosen = false;
                }
				else if(chosen > selected)
				{
                    //selected increase
                    int temp = Queue[selected].GetComponent<Follow>().Colour;
                    Queue[selected].GetComponent<Follow>().Colour = Queue[chosen].GetComponent<Follow>().Colour;
                    for (int i = 1; i < (chosen - selected); i++)
					{
                        int temp2 = Queue[selected + i].GetComponent<Follow>().Colour;
                        Queue[selected + i].GetComponent<Follow>().Colour = temp;
                        temp = temp2;
                    }
                    //chosen = null;
                    Queue[chosen].GetComponent<Follow>().UnSelected();
                    beenChosen = false;
                }
                else
				{
                    //deselect
                    //chosen = null;
                    Queue[chosen].GetComponent<Follow>().UnSelected();
                    beenChosen = false;
                }
                
            }
			else 
            {
                chosen = selected;
                beenChosen = true;
            }
            
		}
        if(beenChosen)
		{
            Queue[chosen].GetComponent<Follow>().Selected();
        }
        Queue[selected].GetComponent<Follow>().Selected();
    }
}
