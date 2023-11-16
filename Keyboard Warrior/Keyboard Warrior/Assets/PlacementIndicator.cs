using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyboardWarrior
{
    public class PlacementIndicator : MonoBehaviour
    {
        public float rotateSpeed;
        public float radius;
        public GameObject indicator;

        private void Start()
        {
            radius = PlayerManager.Instance.playerDragManager.placeRadius;
            indicator.transform.position = new Vector2(radius, 0);
        }
        private void Update()
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }
}
