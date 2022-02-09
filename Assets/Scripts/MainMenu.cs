using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //private void Update()
    //{
    //    PointerEventData touch = new PointerEventData(EventSystem.current);
    //    touch.position = new Vector2 (0,0);
    //    List<RaycastResult> hits = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(touch, hits);
    //    //RaycastHit hit;
    //    //if (Physics.Raycast(transform.position, transform.forward, out hit))
    //    //{
    //    //    {
    //    //        Debug.Log(hit.transform.name);
    //    //    }

    //    //}


    //    //RaycastHit hit;
    //    //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
    //    //if (Physics.Raycast(ray, out hit))
    //    //        Debug.Log(hit.transform.name);

    //    if (Input.anyKeyDown)
    //        PlayGame();
    //}

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
