using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float smooth = 1f;
    private Quaternion targetRotation;
    void Start()
    {
        targetRotation = Quaternion.AngleAxis(60, Vector3.up);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right*50f * Time.deltaTime);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }
}
