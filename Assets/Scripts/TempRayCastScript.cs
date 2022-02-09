//Attach this script to your Canvas GameObject.
//Also attach a GraphicsRaycaster component to your canvas by clicking the Add Component button in the Inspector window.
//Also make sure you have an EventSystem in your hierarchy.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TempRayCastScript : MonoBehaviour
{
    //GraphicRaycaster m_Raycaster;
    //PointerEventData m_PointerEventData;
    //EventSystem m_EventSystem;
    //public Text audit;//temp
    //public Canvas tempCanvas;

    //[SerializeField]
    //GameObject indicator;

    private Camera cam;

    void Start()
    {
        ////Fetch the Raycaster from the GameObject (the Canvas)
        //m_Raycaster = GetComponent<GraphicRaycaster>();
        ////Fetch the Event System from the Scene
        //m_EventSystem = GetComponent<EventSystem>();

        //cam = Camera.main;
        //tempCanvas = GetComponent<Canvas>();
    }

    void Update()
    {
        ////Check if the left Mouse button is clicked
        //if (Input.anyKeyDown)
        //{
        //    //Set up the new Pointer Event
        //    m_PointerEventData = new PointerEventData(m_EventSystem);
        //    //Set the Pointer Event Position to that of the mouse position
        //    m_PointerEventData.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

        //    //m_PointerEventData.position = new Vector2(270f, 570f);

        //    //m_PointerEventData.position = new Vector2(Screen.height / 2f, Screen.width / 2f);

        //    //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        //    //m_PointerEventData.position = new Vector2(ray.direction.x, ray.direction.y);

        //    //Create a list of Raycast Results
        //    List <RaycastResult> results = new List<RaycastResult>();

        //    //Raycast using the Graphics Raycaster and mouse click position
        //    m_Raycaster.Raycast(m_PointerEventData, results);

        //    //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        //    foreach (RaycastResult result in results)
        //    {
        //        Debug.Log("Hit " + result.gameObject.name);
        //        result.gameObject.GetComponent<Button>().onClick.Invoke();
        //        indicator.transform.position = result.gameObject.transform.position;
        //    }


        //}
        //audit.text = m_PointerEventData.position.x.ToString() + "," + m_PointerEventData.position.y.ToString(); //temp
        //Debug.Log(audit.text.ToString()); //temp


        if (Input.anyKeyDown)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.GetComponent<Button>() != null)
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}