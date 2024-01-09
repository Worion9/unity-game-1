using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public void GoToMainManu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
