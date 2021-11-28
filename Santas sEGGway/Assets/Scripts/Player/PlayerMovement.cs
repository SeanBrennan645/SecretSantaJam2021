using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Animator animator;

    Vector2 movement;

    private NPCController NPC = null;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (!inDialogue())
        {
            rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private bool inDialogue()
    {
        if (NPC != null)
        {
            return NPC.DialogueActive();
        }
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            NPC = collision.gameObject.GetComponent<NPCController>();
            if (Input.GetKey(KeyCode.Space)) // should change to a check within update
            {
                NPC.ActivateDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NPC = null;
    }
}
