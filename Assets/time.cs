using UnityEngine;

public class PomiarCzasu : MonoBehaviour
{
    bool flag = true;
    float czasRozpoczecia;

    // Dodaj referencjê do TimerScript
    public TimerScript timerScript;

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

            // Zatrzymaj czas wywo³uj¹c metodê z drugiego skryptu
            if (timerScript != null)
            {
                timerScript.ZatrzymajWznowCzas();
            }
        }
    }
}
