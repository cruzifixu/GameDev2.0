using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetBackView = new Vector3(0, 5, -7);
    private Vector3 offsetSideView = new Vector3(13, 4, 3);
    private Vector3 offsetTopView = new Vector3(0, 20, 2);
    private Vector3 offsetDriverView = new Vector3(0, 2, 2);
    private string ViewSettings;


    // Start is called before the first frame update
    void Start()
    {
        setView("back");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        { setView("back"); }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        { setView("top"); }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        { setView("side"); }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        { setView("driver"); }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        { setView("back"); }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        { setView("top"); }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        { setView("side"); }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        { setView("driver"); }

        getView();
    }

    private void setView(string ViewSettings)
    {
        this.ViewSettings = ViewSettings;
    }

    private void getView()
    {
        switch(this.ViewSettings)
        {
            case "back":
                transform.position = player.transform.position + offsetBackView;
                break;
            case "top":
                transform.position = player.transform.position + offsetTopView;
                transform.rotation = player.transform.rotation * Quaternion.Euler(80, 0, 0);
                break;
            case "side":
                transform.position = player.transform.position + offsetSideView;
                transform.rotation = player.transform.rotation * Quaternion.Euler(15, -90, 0);
                break;
            case "driver":
                transform.position = player.transform.position + offsetDriverView;
                transform.rotation = player.transform.rotation * Quaternion.Euler(12, 0, 0);
                break;
        }
    }
}
