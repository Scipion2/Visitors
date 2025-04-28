using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutoTrigger : EventTriger
{

    public void Awake()
    {
        
        Message="Well done <color=blue>Visitor</color>!\nYour training end here.";

    }

    public void Event()
    {

        SceneManager.LoadScene("Credits");

    }

}
