using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCounter : MonoBehaviour
{
    Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
        counterText.text = PlayerHealth.healthString;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (counterText.text != PlayerHealth.healthString)
        {
            counterText.text = PlayerHealth.healthString;
        }
    }
}
