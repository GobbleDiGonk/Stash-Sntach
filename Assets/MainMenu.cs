using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
