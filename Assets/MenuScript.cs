using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI MaleText;
    public TextMeshProUGUI FemaleText;
    int SelectedNarrator;
    public AudioSource audioSource;
    public AudioClip MaleSound;
    public AudioClip FemaleSound;
    private void Start()
    {
        SelectedNarrator = PlayerPrefs.GetInt("Narrator");
        Debug.Log(SelectedNarrator);
        if (SelectedNarrator == 0) FemaleText.gameObject.SetActive(false);
        else MaleText.gameObject.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void GoToCredits()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void VoiceSelection()
    {
        if(SelectedNarrator == 0)
        {
            PlayerPrefs.SetInt("Narrator", 1);
            audioSource.PlayOneShot(FemaleSound);
        }
        else
        {
            PlayerPrefs.SetInt("Narrator", 0);
            audioSource.PlayOneShot(MaleSound);
        }
        PlayerPrefs.Save();
        SelectedNarrator = PlayerPrefs.GetInt("Narrator");
        Debug.Log(SelectedNarrator);
        MaleText.gameObject.SetActive(!MaleText.gameObject.activeSelf);
        FemaleText.gameObject.SetActive(!FemaleText.gameObject.activeSelf);
    }
}