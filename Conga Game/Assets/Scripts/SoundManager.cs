using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Woo1,Woo2,Woo3,SelectSound,Points,PartyPopper,PartyHorn,ObtainPerson,ChooseSound,Aww1,Aww2,Aww3,Record;
    static AudioSource audioSrc;
    static int Colour;
    // Start is called before the first frame update
    void Start()
    {
        Woo1 = Resources.Load<AudioClip>("Woo1");
        Woo2 = Resources.Load<AudioClip>("Woo2");
        Woo3 = Resources.Load<AudioClip>("Woo3");
        Aww1 = Resources.Load<AudioClip>("Aww1");
        Aww2 = Resources.Load<AudioClip>("Aww2");
        Aww3 = Resources.Load<AudioClip>("Aww3");
        SelectSound = Resources.Load<AudioClip>("Select sound");
        Points = Resources.Load<AudioClip>("Points");
        PartyPopper = Resources.Load<AudioClip>("Party Popper");
        PartyHorn = Resources.Load<AudioClip>("Party Horn Sound Effect");
        ObtainPerson = Resources.Load<AudioClip>("Obtain Person");
        ChooseSound = Resources.Load<AudioClip>("Chose sound");
        Record = Resources.Load<AudioClip>("Record");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Woo":
                //random woo
                Colour = Random.Range(1, 4);
                switch (Colour)
                {
                    case 1:
                        audioSrc.PlayOneShot(Woo1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(Woo2);
                        break;
                    case 3:
                        audioSrc.PlayOneShot(Woo2);
                        break;
                }
                break;
            case "Aww":
                //random aww
                Colour = Random.Range(1, 4);
                switch (Colour)
                {
                    case 1:
                        audioSrc.PlayOneShot(Aww1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(Aww2);
                        break;
                    case 3:
                        audioSrc.PlayOneShot(Aww3);
                        break;
                }
                break;
            case "Select":
                audioSrc.PlayOneShot(SelectSound);
                break;
            case "Points":
                audioSrc.PlayOneShot(Points);
                break;
            case "PartyPopper":
                audioSrc.PlayOneShot(PartyPopper);
                break;
            case "PartyHorn":
                audioSrc.PlayOneShot(PartyHorn);
                break;
            case "ObtainPerson":
                audioSrc.PlayOneShot(ObtainPerson);
                break;
            case "Choose":
                audioSrc.PlayOneShot(ChooseSound);
                break;
            case "Record":
                audioSrc.PlayOneShot(Record);
                break;
        }
    }
}
