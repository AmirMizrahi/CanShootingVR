using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMain()
    {
        Debug.Log("sss");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
