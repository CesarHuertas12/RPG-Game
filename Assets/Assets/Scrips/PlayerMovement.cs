using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    Animator animator;
    Rigidbody2D myRogidbody;
    Vector2 move;

    public GameObject initialMap;

    public void Awake()
    {
        Assert.IsNotNull(initialMap);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        myRogidbody = GetComponent<Rigidbody2D>();

        Camera.main.GetComponent<MainCamera>().SetBounds(initialMap);
    }

    // Update is called once per frame
    void Update()
    {

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if(move != Vector2.zero)
        {
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void FixedUpdate()
    {
        myRogidbody.MovePosition(myRogidbody.position + (move * speed * Time.deltaTime));
    }
}
