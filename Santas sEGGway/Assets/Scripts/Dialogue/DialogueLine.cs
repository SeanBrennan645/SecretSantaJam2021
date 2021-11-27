using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        [Header ("Text Options")]
        [SerializeField] private string input;
        //[SerializeField] private Color textColour;
        //[SerializeField] private Font textFont;

        [Header ("Time Parameters")]
        [SerializeField] private float delay;
        //[SerializeField] private float delayBetweenLines;

        private Text textHolder;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay));
        }
    }

}
