using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public SpriteRenderer sr;

    public Sprite tab1;
    public Sprite tab2;

    void Awake()
	{
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1, 3) == 1)
        {
            sr.sprite = tab1;
        }
        else
		{
            sr.sprite = tab2;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
