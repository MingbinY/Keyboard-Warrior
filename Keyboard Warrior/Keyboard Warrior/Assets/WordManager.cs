using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class WordManager : MonoBehaviour
    {
        public List<string> words = new List<string>();
        public float destroyDelay = 1.0f;

        public bool CheckString(string str, List<GameObject> objs)
        {
            for (int i = 1; i <= str.Length; i++)
            {
                string newS = str.Substring(0, i);
                Debug.Log(newS);
                if (words.Contains(newS))
                {
                    words.Remove(newS);
                    StartCoroutine(DestroyWord(objs, i));
                    return true;
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
