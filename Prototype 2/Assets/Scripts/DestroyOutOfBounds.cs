using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundary = 30.0f;
    private float lowerBound = -10.0f;

    private UpdatePlayerStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("PlayerStats").GetComponent<UpdatePlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBoundary)
        {
            if(gameObject.CompareTag("Animal")) { Stats.UpdateHealth(-1); }
            
            Destroy(gameObject); 
        } // remove GameObjects Assets etc
        else if(transform.position.z < lowerBound)
        {
            if (gameObject.CompareTag("Animal")) { Stats.UpdateHealth(-1); }
            
            Destroy(gameObject); 
        }
    }
}
