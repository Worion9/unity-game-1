using UnityEngine;

public class PomiarCzasu : MonoBehaviour
{
    bool flag = true;
    float czasRozpoczecia;

    void Start()
    {
        czasRozpoczecia = Time.time;
    }
    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player") && flag)
        {
            flag = false;
            float czasTrwania = Time.time - czasRozpoczecia;
            Debug.Log("Ukoñczy³eœ poziom w " + czasTrwania.ToString("F2") + " sekund(y)!");
        }
    }
}
