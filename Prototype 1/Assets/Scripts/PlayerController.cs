using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputid;
    public Camera cam;
    public string CamSwitcher;
    public GameObject player;
    private Vector3 offsetBackView = new Vector3(0, 5, -7);
    private Vector3 offsetSideView = new Vector3(13, 4, 7);
    private Vector3 offsetTopView = new Vector3(0, 20, 2);
    private Vector3 offsetDriverView = new Vector3(0, 2, 2);
    private Vector3 ResetPosition;
    private Quaternion ResetAngle;
    private int count = 0;
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    private Vector3 ViewSettings;
    private Quaternion angle; // represents rotations - rotate rotations/vector

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = player.transform.position + offsetBackView;

        // save start positions
        ResetPosition = player.transform.position;
        ResetAngle = player.transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputid);
        forwardInput = Input.GetAxis("Vertical" + inputid);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // moves vehicle forward
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); // turn left or right

        if (transform.position.y < -2f)
        {
            transform.position = ResetPosition; // falls wir runter fallen, dass wir nach oben gesetzt wird
            transform.rotation = ResetAngle;
          
        }
    }

    
    private void LateUpdate()
    {
        if(Input.GetKeyDown(CamSwitcher))
        {
            count++;
            switch(count)
            {
                case 1:
                    ViewSettings = offsetBackView; // is already child only need to set the offset
                    break;
                case 2:
                    ViewSettings = offsetTopView;
                    angle = player.transform.rotation * Quaternion.Euler(80, 0, 0);
                    break;
                case 3:
                    ViewSettings = offsetSideView;
                    angle = player.transform.rotation * Quaternion.Euler(15, -90, 0);
                    break;
                case 4:
                    ViewSettings = offsetDriverView;
                    angle = player.transform.rotation * Quaternion.Euler(12, 0, 0);
                    break;
                default:
                    ViewSettings = offsetBackView;
                    count = 1;
                    break;
            }
           
            cam.transform.localPosition = ViewSettings; // move to same position as parent
            cam.transform.rotation = angle; // move to same angle as parent
        }
    }
}
