using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hunger;
    public int amountToBeFull;
    private int currHunger = 0;

    private UpdatePlayerStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("PlayerStats").GetComponent<UpdatePlayerStats>();

        hunger.maxValue = amountToBeFull;
        hunger.value = 0;
        hunger.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Feed(int food)
    {
        currHunger += food;
        hunger.fillRect.gameObject.SetActive(true);
        hunger.value = currHunger;

        if(currHunger >= amountToBeFull)
        {
            Stats.UpdateScore(amountToBeFull);
            Destroy(gameObject, 0.1f); // delay before destroy
        }
    }
}
