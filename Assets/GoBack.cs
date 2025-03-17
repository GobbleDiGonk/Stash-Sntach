using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
