using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //This script loads a new scene based on the inputted screen index integer
    public void SwitchScene(int sceneIndexNum)
    {
        SceneManager.LoadScene(sceneIndexNum);
    }
}
