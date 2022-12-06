using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSplash : MonoBehaviour
{
    public AudioClip splashSound;
    public GameObject whaleCam;
    public GameObject whale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSplashSound()
    {
        whale.GetComponent<AudioSource>().Play();
        AudioSource.PlayClipAtPoint(splashSound, whaleCam.transform.position, 0.75f);
        
    }
}
