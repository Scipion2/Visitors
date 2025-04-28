using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutoTrigger : EventTriger
{

    public void Awake()
    {
        
        Message="Well done <color=blue>Visitor</color>!\nYou end your training here.";

    }

    public void Event()
    {

        SceneManager.LoadScene("Credits");

    }

}
