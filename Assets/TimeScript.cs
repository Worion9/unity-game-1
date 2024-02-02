using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript Instance;

    public Text czasText;
    public float czasDoUkonczenia = 300.0f; // Czas w sekundach (np. 300 sekund = 5 minut)
    private float aktualnyCzas;
    private bool czasZatrzymany = false;

    void Start()
    {
        aktualnyCzas = czasDoUkonczenia;
    }

    void Update()
    {
        // Sprawd�, czy czas powinien by� odmierzany
        if (!czasZatrzymany)
        {
            // Odmierzaj czas tylko je�li czas nie jest zatrzymany
            aktualnyCzas -= Time.deltaTime;
        }

        // Formatuj czas na minuty i sekundy
        int minuty = Mathf.FloorToInt(aktualnyCzas / 60);
        int sekundy = Mathf.FloorToInt(aktualnyCzas % 60);

        // Aktualizuj tekst na HUDzie
        czasText.text = string.Format("{0}:{1}", minuty, sekundy.ToString("00"));

        // Sprawd�, czy czas dobieg� ko�ca
        if (aktualnyCzas <= 0)
        {
            czasText.text = "Czas min��!";
            // Tutaj mo�esz doda� kod obs�uguj�cy koniec czasu, np. koniec poziomu.
        }
    }

    public void ZatrzymajWznowCzas()
    {
        czasZatrzymany = !czasZatrzymany;
        Debug.Log("Zmiana czasu!");
        if (czasZatrzymany)
        {
            czasText.text = "Czas zatrzymany";
        }
    }
}