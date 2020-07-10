using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float Speed=500;
    public Transform player;
    //public Transform braco;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //delta time é para ter uma rotaçao smoth independete das framse
        float moveX = Input.GetAxis("Mouse X")*Speed*Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y")*Speed* Time.deltaTime;
        xRotation -= moveY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Debug.Log(xRotation);
        player.Rotate(Vector3.up * moveX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Tentativa de rodar o braço consonte a camera----> soluçao
        //usar o braço como child e assim todas as  rotaçoes tambem sao aplicadas ao braço
        //braco.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
