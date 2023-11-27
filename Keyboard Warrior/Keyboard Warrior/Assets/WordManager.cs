using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class WordManager : MonoBehaviour
    {
        [System.Serializable]
        public struct WordAndSound
        {
            public string word;
            public AudioClip audio;
        }

        AudioSource audioSource;
        public List<WordAndSound> words = new List<WordAndSound>();
        public float destroyDelay = 1.0f;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public bool CheckString(string str, List<GameObject> objs)
        {
            for (int i = 1; i <= str.Length; i++)
            {
                string newS = str.Substring(0, i);
                Debug.Log(newS);
                foreach (WordAndSound ws in words)
                {
                    if (ws.word == newS)
                    {
                        if (ws.audio)
                        {
                            audioSource.PlayOneShot(ws.audio);
                        }
                        words.Remove(ws);
                        StartCoroutine(DestroyWord(objs, i));
                        return true;
                    }
                }
            }

            return false;
        }

        IEnumerator DestroyWord(List<GameObject> objs, int i)
        {
            yield return new WaitForSeconds(destroyDelay);
            for (int j = 0; j < i; j++)
            {
                Destroy(objs[j]);
            }
        }
    }
}
