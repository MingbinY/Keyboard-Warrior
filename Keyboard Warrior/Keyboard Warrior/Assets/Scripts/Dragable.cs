using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardWarrior
{
    public enum DragState
    {
        Player,
        InteractableObject,
        Environment
    }
    public class Dragable : MonoBehaviour
    {
        public Color hoverColor;
        public Color pressColor;
        public string enchantmentDirection;
        Color defaultColor = Color.white;
        Vector3 startPos;
        Image image;
        GameObject playerObj;
        public LayerMask raycastIgnoreLayers;
        GameObject rayHitObject;
        DragState dragState;
        bool isDraging = false;

        public GameObject obstaclePrefab;

        private void Start()
        {
            playerObj = PlayerManager.Instance.gameObject;
            image = GetComponent<Image>();
            startPos = transform.position;
        }

        private void Update()
        {
            if (isDraging)
            {
                // Mouse Raycast
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, ~raycastIgnoreLayers);
                if (hit.collider != null)
                {
                    rayHitObject = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject == PlayerManager.Instance.gameObject)
                    {
                        dragState = DragState.Player;
                    }
                    else if (hit.collider.GetComponent<InteractableObject>() != null)
                    {
                        dragState = DragState.InteractableObject;
                    }
                    else
                    {
                        dragState = DragState.Environment;
                    }
                }
                else
                {
                    rayHitObject = null;
                    dragState = DragState.Environment;
                }
            }
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), name)))
            {
                image.color = pressColor;
            }
            if (Input.GetKeyUp((KeyCode)System.Enum.Parse(typeof(KeyCode), name)))
            {
                image.color = defaultColor;
            }
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
            dragState = DragState.Environment;
            isDraging = true;
            PlayerManager.Instance.playerDragManager.dragging = true;
        }

        public void OnEndDrag()
        {
            switch (dragState)
            {
                case DragState.Environment:
                    //Create new obstacle
                    if (obstaclePrefab != null)
                    {
                        obstaclePrefab.SetActive(true);
                        obstaclePrefab.transform.position = new Vector3(GetWorldPos().x, GetWorldPos().y, 0);
                    }
                    break;
                case DragState.Player:
                    //Player Skill
                    PlayerManager.Instance.playerEquipmentManager.Equip(gameObject, enchantmentDirection);
                    break;
                case DragState.InteractableObject:
                    // Interactable Object state change
                    rayHitObject.GetComponent<InteractableObject>().OnInteract(enchantmentDirection);
                    break;
            }
            //if (Mathf.Abs(currentPos.x - playerObj.transform.position.x) < 0.5f && Mathf.Abs(currentPos.y - playerObj.transform.position.y) < 0.5f)
            //{
            //    Debug.Log("Equip Skill");   
            //}
            //else
            //{
            //    Debug.Log("Create New Obstacle");

            //}
            PlayerManager.Instance.playerDragManager.dragging = false;
            OnEndHover();
            PlayerManager.Instance.playerKeyboardManager.UseKey(name);
            transform.position = startPos;
            Debug.Log(enchantmentDirection + " " + transform.position);
            gameObject.SetActive(false);
        }

        Vector3 GetWorldPos()
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(transform.position);
            return worldPos;
        }
    }
}
