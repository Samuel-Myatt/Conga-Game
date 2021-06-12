using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;

    public Transform Target;

    public Camera cam;

    public Vector2 point;

    Rigidbody2D rb;

    public int Colour = 0;

    public SpriteRenderer sr;

    public Sprite Blue;
    public Sprite Yellow;
    public Sprite Red;
    public Sprite Green;
    public Sprite HighlightB;
    public Sprite HighlightR;
    public Sprite HighlightY;
    public Sprite HighlightG;

    public Animator anim;


    void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //sr.color = Color.black;
       // sr.sprite = Blue;

    }
    void Start()
    {
       switch(Colour)
		{
            case 1:
                //be a colour
                sr.sprite = Blue;
                anim.Play("Blue");
                break;  
            case 2:
                sr.sprite = Yellow;
                anim.Play("Yellow");
                break;
            case 3:
                sr.sprite = Red;
                anim.Play("Red");
                break;
            case 4:
                sr.sprite = Green;
                anim.Play("Green");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

      
            

        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);

        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

    }


    public void Selected()
	{
        
        switch (Colour)
        {
            case 1:
                //be a colour
                sr.sprite = HighlightB;
                anim.Play("BlueGlow");
                break;
            case 2:
                sr.sprite = HighlightY;
                anim.Play("YellowGlow");
                break;
            case 3:
                sr.sprite = HighlightR;
                anim.Play("RedGlow");
                break;
            case 4:
                sr.sprite = HighlightG;
                anim.Play("GreenGlow");
                break;
        }
    }
    public void UnSelected()
    {
        switch (Colour)
        {
            case 1:
                //be a colour
                sr.sprite = Blue;
                anim.Play("Blue");
                break;
            case 2:
                sr.sprite = Yellow;
                anim.Play("Yellow");
                break;
            case 3:
                sr.sprite = Red;
                anim.Play("Red");
                break;
            case 4:
                sr.sprite = Green;
                anim.Play("Green");
                break;
        }
    }
    
}
