using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardWarrior
{
    public class LetterUI : MonoBehaviour
    {
        Text uiText;
        Word word;
        private void Start()
        {
            uiText = GetComponent<Text>();
            word = GetComponentInParent<Word>();
        }

        private void Update()
        {
            uiText.text = word.letter;
        }
    }
}
