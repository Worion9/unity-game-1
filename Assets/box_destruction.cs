using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        //Make Collider2D as trigger 
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the box if it collides with an object tagged as "Ball"
        if (collision.collider.CompareTag("Ball"))
        {
            audioSource.clip = clip;
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}