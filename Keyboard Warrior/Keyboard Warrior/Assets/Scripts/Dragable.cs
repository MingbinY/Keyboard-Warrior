using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardWarrior
{
    public class Dragable : MonoBehaviour
    {
        public Color hoverColor;
        Color defaultColor = Color.white;
        Vector3 startPos;
        Image image;
        GameObject playerObj;

        public GameObject obstaclePrefab;

        private void Start()
        {
            playerObj = PlayerManager.Instance.gameObject;
            image = GetComponent<Image>();
            startPos = transform.position;
        }

        private void Update()
        {
            //Debug.Log(transform.position + "," + Camera.main.ScreenToWorldPoint(transform.position));
        }

        public void OnHover()
        {
            image.color = hoverColor;
        }

        public void OnEndHover()
        {
            image.color = defaultColor;
        }

        public void OnDrag()
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag()
        {
            Vector2 currentPos = new Vector2(GetWorldPos().x, GetWorldPos().y);
            if (Mathf.Abs(currentPos.x - playerObj.transform.position.x) < 0.5f && Mathf.Abs(currentPos.y - playerObj.transform.position.y) < 0.5f)
            {
                Debug.Log("Equip Skill");
            }
            else
            {
                Debug.Log("Create New Obstacle");
                if (obstaclePrefab != null)
                {
                    obstaclePrefab.SetActive(true);
                    obstaclePrefab.transform.position = new Vector3(GetWorldPos().x, GetWorldPos().y, 0);
                }
            }
            OnEndHover();
            transform.position = startPos;
            gameObject.SetActive(false);
        }

        Vector3 GetWorldPos()
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(transform.position);
            return worldPos;
        }
    }
}
