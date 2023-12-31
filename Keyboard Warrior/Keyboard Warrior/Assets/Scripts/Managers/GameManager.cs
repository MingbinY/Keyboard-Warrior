using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    //Handle Game Functions such as respawn point
    public class GameManager : Singleton<GameManager>
    {
        public Vector2 respawnPoint {  get; private set; }
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(instance);
        }

        public void SetSpawnPoint(Transform newPoint)
        {
            respawnPoint = newPoint.position;
        }

        public void Respawn()
        {
            GameSceneManager.Instance.ReloadScene();
        }
    }
}
