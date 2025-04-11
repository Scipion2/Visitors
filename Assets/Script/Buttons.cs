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
        Time.timeScale=0.1f;

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
        Time.timeScale=1;

    }

    public void Unpause()
    {

        Time.timeScale=1;

    }

}