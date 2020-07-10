using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public float JumpHeight = 2f;
    private string moveInputAxis="Vertical";
    private string turnInputAxis = "Horizontal";
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        Move(moveAxis);
    }
    private void Move(float moveInput)
    {
        rb.AddForce(transform.forward * moveInput * Speed,ForceMode.Force);
    }
}
