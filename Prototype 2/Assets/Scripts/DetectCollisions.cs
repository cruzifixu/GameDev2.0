using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    private UpdatePlayerStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("PlayerStats").GetComponent<UpdatePlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name.Equals("Player") && !gameObject.name.Equals("Cookie(Clone)"))
       {
            Stats.UpdateHealth(-1);
            Destroy(gameObject);
       }
       else if(other.tag.Equals("Animal"))
       {
            other.GetComponent<AnimalHunger>().Feed(1);
            Destroy(gameObject);
            //Destroy(other.gameObject);
       }
    }
}
