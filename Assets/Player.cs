using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public void OtrzymajObrazeniaOdPrzeciwnika(int obrazenia)
    {
        hp -= obrazenia;
        Debug.Log("Gracz otrzyma� obra�enia od przeciwnika. Zdrowie: " + hp);

        if (hp <= 0)
        {
            Debug.Log("Gracz zosta� pokonany!");
            // Tutaj mo�esz doda� dodatkowe dzia�ania po pokonaniu gracza
        }
    }
}
