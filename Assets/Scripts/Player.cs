using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float timeToJumpApex;
    public float jumpHeight;
    public int moveSpeed;
    float gravity = 20;
    Vector3 velocity;
    Controller2D controller;
    bool hasJumpedTwice;
    float jumpVelocity = 8;
    public bool flipped = false;
    public bool isWalking;
    bool attachedToWall;
    bool canWallJump;
    private Vector3 offset = new Vector3(0, .8f, -10);
    GameObject lastCollision;
    Vector3 initPos;

    void Start()
    {
        initPos = transform.position;
        Animator animator = GetComponent<Animator>();
        gravity = (2 * jumpHeight) /(timeToJumpApex* timeToJumpApex);
        jumpVelocity = gravity * timeToJumpApex;
        controller = GetComponent<Controller2D>();
        GetComponent<Animator>().SetBool("isWalking", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.collisions.collidedObject!= null && controller.collisions.collidedObject.layer == 10)
        {
            controller.collisions.collidedObject.GetComponent<Item>().onPickup();
        }

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            hasJumpedTwice = false;
            if (controller.collisions.collidedObject.tag.Equals("MovingPlatform"))
            {
                float xmo = controller.collisions.collidedObject.GetComponent<MovablePlatform>().speed;
                velocity.x += xmo;
            }
        }
        if (controller.collisions.left || controller.collisions.right)
        {
            if (lastCollision != controller.collisions.collidedObject && canWallJump)
            {
                hasJumpedTwice = false;
            }
            if (controller.collisions.collidedObject.tag.Equals("sticky"))
            {
                float ymo = controller.collisions.collidedObject.GetComponent<MomentumPlatform>().drag;
                velocity.y = ymo;
            }
            lastCollision = controller.collisions.collidedObject;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space)&&!hasJumpedTwice)
        {
            if (!controller.collisions.below)
            {
                hasJumpedTwice = true;
            }
            velocity.y = jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            controller.fire(input);
        }

        velocity.y += ((gravity * -1) * Time.deltaTime);

        if (input.x > 0)
        {
            velocity.x = input.x * moveSpeed * Time.deltaTime;
        }
        if (input.x < 0)
        {
            velocity.x = input.x * moveSpeed * Time.deltaTime;
        }
        else if(input.x == 0)
        {
            velocity.x = 0;
            isWalking = false;
        }
        if (transform.position.y < -20)
        {
            respawn();
        }
        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.collidedObject.tag.Equals("MovingPlatform"))
            {
                float xmo = controller.collisions.collidedObject.GetComponent<MovablePlatform>().speed;
                velocity.x += xmo;
            }
        }
        controller.Move(velocity);

    }

    private void LateUpdate()
    {

        Camera.main.transform.position = transform.position + offset;

    }
    public void ActivateWallJump()
    {
        canWallJump = true;
        GetComponent<SpriteRenderer>().color = new Color(.8f,.6f,0f);
    }
    public void respawn()
    {
        transform.position = initPos;
        velocity.x = 0;
        velocity.y = 0;
    }

}

