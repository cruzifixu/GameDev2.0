using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    private Button button;
    private bool PlayMusic = true;
    public AudioSource audioSource;
    public TextMeshProUGUI musicText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        button.onClick.AddListener(SetMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMusic()
    {
        PlayMusic = !PlayMusic;
        if(PlayMusic)
        { 
            audioSource.Play();
            musicText.text = "on";
        }
        else 
        { 
            audioSource.Stop();
            musicText.text = "off";
        }
    }
}
