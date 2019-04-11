using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSwitch
{
    public class UI : MonoBehaviour
    {
        public Text scoreText;



        // Use this for initialization
        void Start()
        {
            UpdateScore();


        }

        // Update is called once per frame
        void Update()
        {
            UpdateScore();
        }
        void UpdateScore()
        {
            scoreText.text = "Score: " + Player.score;
        }

    }
}
