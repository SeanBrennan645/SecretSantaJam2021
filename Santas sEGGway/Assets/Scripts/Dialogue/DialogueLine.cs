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
        private IEnumerator lineAppear;

        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder, delay);
            StartCoroutine(lineAppear);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;                  
                }
                else
                    isFinished = true;
            }
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            isFinished = false;
        }
    }

}
