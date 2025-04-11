using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{


    public void Jump()
    {

        EventManager.instance.JumpEvent.Invoke();

    }

    public void Quit()
    {

        Application.Quit();

    }

    public void Retry()
    {

        GameManager.instance.ResetLevel();

    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void Settings()
    {

        SceneManager.LoadScene("Settings",LoadSceneMode.Additive);

    }

    public void Credits()
    {

        SceneManager.LoadScene("Credits");

    }

    public void Play()
    {

        GameManager.instance.Play();

    }

    public void CloseSettings()
    {

        SceneManager.UnloadSceneAsync("Settings");

    }

}