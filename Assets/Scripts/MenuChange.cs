using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public void goToGame(){
        SceneManager.LoadScene(2);
    }
    public void goToTuning(){
        SceneManager.LoadScene(1);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
