using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite Blue;
    public Sprite Yellow;
    public Sprite Red;
    public Sprite Green;

    public int Colour = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Colour = Random.Range(1, 5);
        switch (Colour)
        {
            case 1:
                //be a colour
                sr.sprite = Blue;
                break;
            case 2:
                sr.sprite = Yellow;
                break;
            case 3:
                sr.sprite = Red;
                break;
            case 4:
                sr.sprite = Green;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
