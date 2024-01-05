using System.Collections;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private Transform destination;
    public bool is_tp1;
    public float distance = 0.2f;
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (is_tp1 == false)
        {
            destination = GameObject.FindGameObjectWithTag("Portal 1").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Portal 2").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player") && Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            Teleport(other.transform);
        }
    }

    void Teleport(Transform objectToTeleport)
    {
        if (destination != null)
        {
            objectToTeleport.position = new Vector2(destination.position.x, destination.position.y);
            Debug.Log("Player teleported to destination portal.");
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Destination portal is null. Teleportation failed.");
        }
    }
}
