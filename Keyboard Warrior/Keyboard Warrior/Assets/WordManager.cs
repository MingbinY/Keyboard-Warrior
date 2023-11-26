using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class WordManager : MonoBehaviour
    {
        public List<string> words = new List<string>();

        public bool CheckString(string str, List<GameObject> objs)
        {
            for (int i = 1; i <= words.Count; i++)
            {
                string newS = str.Substring(0, i);
                if (words.Contains(newS))
                {
                    words.Remove(newS);
                    for (int j = 0; j < i; j++)
                    {
                        Destroy(objs[j]);
                    }
                    return true;
                }
            }

            return false;
        }
    }
}
