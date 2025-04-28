using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Android;

public class Buttons : Button, IPointerUpHandler, IPointerDownHandler
{


    public override void OnPointerDown(PointerEventData eventData)
    {

        AudioManager.instance.PlayAudio(AudioManager.AudioName.ButtonDown);

    }

    public override void OnPointerUp(PointerEventData eventData)
    {

        AudioManager.instance.PlayAudio(AudioManager.AudioName.ButtonUp);

    }


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

        if(CheckPerm())
            GameManager.instance.Play();
        else
            Debug.Log("Pas de perm, pas de chocolat");

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

    public void Talk()
    {

        UIManager.instance.DisplayPlayerUI(false);
        UIManager.instance.DisplayDialogDisplayer(true);

    }

    public void NextWorld()
    {

        GameManager.instance.NextLevel();

    }

    private bool CheckPerm()
    {

        if(!Permission.HasUserAuthorizedPermission("android.permission.HIGH_SAMPLING_RATE_SENSORS"))
        {

            Permission.RequestUserPermission("android.permission.HIGH_SAMPLING_RATE_SENSORS");

        }

        UIManager.instance.DisplayTipWindow("perm checked");

        return Permission.HasUserAuthorizedPermission("android.permission.HIGH_SAMPLING_RATE_SENSORS");

    }

}