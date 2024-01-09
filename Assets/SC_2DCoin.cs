using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_2DCoin : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "SC_2DCoin.totalCoins" from any script)
    public static int totalCoins = 0;
    public static string displyedCoins = totalCoins.ToString() + " / 10";
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
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            audioSource.clip = clip;
            audioSource.Play();
            //Destroy coin
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //Add coin to counter
            totalCoins++;
            displyedCoins = totalCoins.ToString() + " / 10";
            //Test: Print total number of coins
            Debug.Log("You currently have " + SC_2DCoin.totalCoins + " Coins.");
        }
    }
}