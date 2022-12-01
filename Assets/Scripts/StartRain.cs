using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

    public class StartRain : MonoBehaviour
    {
        public bool started = false;
        public GameObject rain;
        private RainScript rs;
        private float rainIntensity = 0.0f;
        void Start()
        {
            rs = rain.GetComponent<RainScript>();
        }

        // Update is called once per frame
        // animate the game object from -1 to +1 and back
        public float minimum =  0.0F;
        public float maximum =  1.0F;

        // starting value for the Lerp
        static float t = 0.0f;

        void Update()
        {
            if (started)
            {
                t += 0.6f * Time.deltaTime;
                
                if (t > 1.0f)
                {
                    
                    rainIntensity+=0.1f;
                    rs.setRainIntensity(rainIntensity);
                    t = 0.0f;
                }
            }
        }

        public void startRain()
        {
            started = true;
        }
    }

