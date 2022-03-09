using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerStats : MonoBehaviour
{
    private int Score = 0;
    private int Health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth(int val)
    {
        Health += val;

        if (Health < 1)
        { 
            Debug.Log("Game Over");
        }

        Debug.Log("Health = " + Health);
    }

    public void UpdateScore(int val)
    {
        if (Score % 3 == 0) Health++;
        Debug.Log("Score = " + Score++);
    }

    public float getHealth()
    {
        return Health;
    }
}
