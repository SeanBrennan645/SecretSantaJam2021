using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool isFinished { get; private set; }
        protected IEnumerator WriteText(string input, Text TextHolder, float delay)
        {
            for(int i =0; i<input.Length; i++)
            {
                TextHolder.text += input[i];
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => Input.GetButtonDown("Jump")); //using jump cause cba to mess with unity input. Its spacebar anyway lol
            isFinished = true;
        }
    }
}