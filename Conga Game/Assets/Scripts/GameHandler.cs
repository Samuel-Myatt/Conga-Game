using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

   
    

    public GameObject Follower;
    public GameObject Leader;
    public List<GameObject> Queue;

    public GameOverMenu GameOverMenu;

    float test = 0;

    int QueueCount = 0;

    int selected = 0;

    int chosen;

    bool beenChosen = false;

    bool foundone = false;

    public int score = 0;

    public bool gameover = false;

    public ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        Queue = new List<GameObject>();
        Leader = GameObject.FindGameObjectWithTag("Leader");
        

        SpawnFollower(1);
        gameover = false;
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
        if(gameover)
		{
            GameOverMenu.GetComponent<GameOverMenu>().setup(score);

        }
        else
		{
            test++;
            if (test == 360)
            {
                //SpawnFollower();
                test = 0;
            }


            if (Input.GetMouseButtonDown(0))
            {
                if (selected == QueueCount - 1)
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
                    selected = QueueCount - 1;
                }
                else
                {
                    Queue[selected].GetComponent<Follow>().UnSelected();
                    selected--;
                }
            }

            if (Input.GetKeyDown("space"))
            {
                if (beenChosen)
                {
                    //selected colour to become chosens colour
                    //then the next in the line to become selecteds old colour
                    ///then just continue till the end
                    /*if(chosen < selected)
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

                }*/
                    int temp = Queue[selected].GetComponent<Follow>().Colour;
                    int temp2 = Queue[chosen].GetComponent<Follow>().Colour;
                    Queue[chosen].GetComponent<Follow>().Colour = temp;
                    Queue[selected].GetComponent<Follow>().Colour = temp2;
                    Queue[chosen].GetComponent<Follow>().UnSelected();
                    //Queue[selected].GetComponent<Follow>().UnSelected();
                    beenChosen = false;
                }

                else
                {
                    chosen = selected;
                    beenChosen = true;
                }

            }
            if (beenChosen)
            {
                Queue[chosen].GetComponent<Follow>().Selected();
            }
            Queue[selected].GetComponent<Follow>().Selected();
            Check3();
        }
        
    }

    void Check3()
	{
        if(QueueCount > 3)
		{
            for(int i = 0; i < QueueCount-2; i++)
			{
                if(!foundone)
				{
                    int tempcol = Queue[i].GetComponent<Follow>().Colour;
                    if (tempcol == Queue[i + 1].GetComponent<Follow>().Colour)
                    {
                        if (tempcol == Queue[i + 2].GetComponent<Follow>().Colour)
                        {
                            foundone = true;
                            Debug.Log("Found 3");
                            //we have a match
                            //remove the 3
                            //move everyone past them up by 36
                            if (i == 0)
                            {
                                Debug.Log("Hit the win");
                                if ((QueueCount - i) < 3)
                                {
                                    Debug.Log("Yeet");
                                }
                                else
                                {
                                    Debug.Log("Space");
                                    Queue[i + 3].GetComponent<Follow>().Target = Leader.transform;
                                    
                                }

                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                QueueCount -= 3;
                                score += 100;
                                ParticleSystem.Play();
                            }
                            else
                            {
                                Debug.Log("Hit the win");
                                if ((QueueCount - i) <= 3)
                                {
                                    Debug.Log("Yeet");
                                }
                                else
                                {
                                    Debug.Log("Space");
                                    Queue[i + 3].GetComponent<Follow>().Target = Queue[i - 1].transform;
                                    
                                }
                                
                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                Destroy(Queue[i].gameObject);
                                Queue.RemoveAt(i);
                                QueueCount -= 3;
                                score += 100;
                                ParticleSystem.Play();
                            }

                            /*for(int j = 0; j < QueueCount - i; j++)
                            {
                                if(QueueCount - (i+j) >= 3)
                                {
                                    Queue[i + j].GetComponent<Follow>().Colour = Queue[i + j + 3].GetComponent<Follow>().Colour;
                                    Debug.Log("changin colours");
                                }
                                else
                                {
                                    // remove the queue[i+j]
                                    Destroy(Queue[i + j].gameObject);
                                    Queue.RemoveAt(i + j);
                                    Debug.Log("Deletin");

                                }

                            }*/
                        }

                    }
                }
                

            }
            foundone = false;
		}
	}
    public void Restart()
	{
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
	{
        Application.Quit();
    }
}
