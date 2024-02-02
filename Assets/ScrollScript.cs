using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ScrollScript : MonoBehaviour
{
    public static ScrollScript Instance;
    //Keep track of total picked srolls (Since the value is static, it can be accessed at "ScrollScript.totalScrolls" from any script)
    public static int totalScrolls = 0;
    public static string displyedScrolls = totalScrolls.ToString() + " / 3";
    public AudioSource audioSource;
    public AudioSource letterSource;
    public AudioClip clip;
    public AudioClip letter1_m;
    public AudioClip letter2_m;
    public AudioClip letter3_m;
    public AudioClip letter1_f;
    public AudioClip letter2_f;
    public AudioClip letter3_f;
    public string itemDescription;
    public int SelectedNarrator;

    void Start()
    {
        //Make Collider2D as trigger 
        audioSource = GetComponent<AudioSource>();
        SelectedNarrator = PlayerPrefs.GetInt("Narrator");
        Debug.Log(SelectedNarrator);
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
            if (totalScrolls == 0)
            {
                itemDescription = "Golden keys open forbidden doors, and inside them is hidden the code of a forgotten civilization. The shadows of machines roam the ruins, and the last chance for salvation lies hidden in the heart of the foggy forest. The past awakens when a dormant race's energy source explodes with danger. Can you uncover the secrets before mechanical night covers the world?";
                if (SelectedNarrator == 0)
                    letterSource.clip = letter1_m;
                if (SelectedNarrator == 1)
                    letterSource.clip = letter1_f;
            }
            if (totalScrolls == 1)
            {
                itemDescription = "A powerful secret lurks in the nooks and crannies of old factories, and the boxes of watchmaking precision are the key to an inscrutable fate. Under the foggy sky there is a world where the dreams of cyborgs intertwine with the prophecies of machines. Embark on a journey before the last mode of life fades away on the universe's clock.";
                if (SelectedNarrator == 0)
                    letterSource.clip = letter2_m;
                if (SelectedNarrator == 1)
                    letterSource.clip = letter2_f;
            }
            if (totalScrolls == 2)
            {
                itemDescription = "Golden spirals protect forgotten secrets from being forgotten, and digital runes open the door to forbidden codes. At the heart of the mechanical labyrinth sleeps a creature whose awakening heralds twilight for humans and machines. Time flows like a stream of data, and the choice between the program and freedom becomes the final ritual.";
                if (SelectedNarrator == 0)
                    letterSource.clip = letter3_m;
                if (SelectedNarrator == 1)
                    letterSource.clip = letter3_f;
            }
            letterSource.Play();
            UIManager.Instance.ShowItemPopup(itemDescription);
            audioSource.clip = clip;
            audioSource.Play();
            //Destroy scroll
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //Add scroll to counter
            totalScrolls++;
            displyedScrolls = totalScrolls.ToString() + " / 3";
            //Test: Print total number of scrolls
            Debug.Log("You currently have " + ScrollScript.totalScrolls + " Scrolls.");
        }
    }
    public void Stop_letter()
    {
        letterSource.Stop();
    }
}
