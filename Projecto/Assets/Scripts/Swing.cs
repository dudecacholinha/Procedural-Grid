using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    // Start is called before the first frame update
    public float  RotationSpeed=00000.1f;
    Vector3 rotationDirection;
    Quaternion from;
    Quaternion to;
    void Start()
    {
        from = transform.localRotation;
        to = Quaternion.Euler(60, 0f, 0f);
        to=Quaternion.AngleAxis(60, Vector3.up);
        Vector3 rotationDirection= new Vector3(60f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(from);
            //o from tem tar de fora para nao ir mudado a cada call do update como é obvio, nao obtemos
            //um movimento uniforme
            //transform.rotation = Quaternion.Lerp(from,to , Time.time * RotationSpeed);
            //transform.Rotate(rotationDirection * Time.deltaTime *20, Space.Self);
            transform.Rotate(Vector3.right * 500f * Time.deltaTime);
        }
    }
}
