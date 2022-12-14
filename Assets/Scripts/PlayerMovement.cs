using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Inventory))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public static Inventory Inventory { get; private set; }

    [SerializeField] private Animator animator;

    [SerializeField] private float speed = 5;
    private int moveDirection;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    public static bool Interacting { get; private set; }

    private List<IInteractable> interactables = new List<IInteractable>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        animator.Play(moveDirection != 0 ? "PlayerWalk" : "PlayerIdle");
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactables.Count <= 0)
                return;
            
            if (Interacting)
                interactables[0].QuitInteraction();
            else
                interactables[0].Interact(this);
            Interacting = !Interacting;
        }

        if (Interacting)
        {
            moveDirection = 0;
            return;
        }

        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            moveDirection = 0;
        else if (Input.GetKey(KeyCode.A))
            moveDirection = -1;
        else if (Input.GetKey(KeyCode.D))
            moveDirection = 1;
        else
            moveDirection = 0;

        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
            Jump();
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * 10;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    
    private bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable == null)
            return;
        interactables.Add(interactable);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable == null)
            return;
        interactables.Remove(interactable);
    }
}
