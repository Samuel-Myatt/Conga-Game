using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip GetPerson;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        GetPerson = Resources.Load<AudioClip>("GetPerson");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
	{
        switch(clip)
		{
            case "GetPerson":
                break;
		}
	}
}
