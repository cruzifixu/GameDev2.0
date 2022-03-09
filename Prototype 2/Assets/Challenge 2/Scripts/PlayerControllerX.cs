using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timer = 0;
    private float breaktTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // counter to prevent from spamming
        if(timer >= breaktTime)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
            }
        }
    }
}
