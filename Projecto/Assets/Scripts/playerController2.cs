using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController2 : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    public float Speed=10;
    void Start()
    {
        //tirar o cursor
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x= Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");
        Vector3 move=transform.right*x+transform.forward*z;

        
        controller.Move(move);
    }

}
