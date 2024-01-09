using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    //Keep track of total picked srolls (Since the value is static, it can be accessed at "ScrollScript.totalScrolls" from any script)
    public static int totalScrolls = 0;
    public static string displyedScrolls = totalScrolls.ToString() + " / 10";
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        //Make Collider2D as trigger 
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the scroll if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            audioSource.clip = clip;
            audioSource.Play();
            //Destroy scroll
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //Add scroll to counter
            totalScrolls++;
            displyedScrolls = totalScrolls.ToString() + " / 5";
            //Test: Print total number of scrolls
            Debug.Log("You currently have " + ScrollScript.totalScrolls + " Scrolls.");
        }
    }
}
