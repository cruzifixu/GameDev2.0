using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10.0f;
    private Vector3 StartPosition = new Vector3(0,0,-8);
    private float xRange = 18;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // if player gets off grounds
        if(transform.position.x < -xRange)
        { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if(transform.position.x > xRange)
        { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }

        if(Input.GetKeyDown(KeyCode.Space))
        { Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); } // returns clone of original
    }
}
