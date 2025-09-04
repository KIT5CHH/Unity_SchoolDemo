using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
 
     public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadStore()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

}
