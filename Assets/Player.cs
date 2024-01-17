using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public void OtrzymajObrazeniaOdPrzeciwnika(int obrazenia)
    {
        hp -= obrazenia;
        Debug.Log("Gracz otrzyma³ obra¿enia od przeciwnika. Zdrowie: " + hp);

        if (hp <= 0)
        {
            Debug.Log("Gracz zosta³ pokonany!");
            // Tutaj mo¿esz dodaæ dodatkowe dzia³ania po pokonaniu gracza
        }
    }
}
