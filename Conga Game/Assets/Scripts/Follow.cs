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

    public float Colour = 0;

    public SpriteRenderer sr;

    public Sprite Blue;
    public Sprite Yellow;
    public Sprite Red;
    public Sprite Green;


    void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
       switch(Colour)
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

        /* Vector3 difference = target.position - transform.position;
         float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);*/
        //transform.localEulerAngles = new Vector3(0, 0, target.localEulerAngles.z);
        // transform.LookAt(target);
            

        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);

        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

    }


  

    protected void LateUpdate()
    {
        //transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
