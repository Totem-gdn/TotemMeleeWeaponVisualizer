using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{
    [SerializeField]
    private float RotationSpeed = 5000f;

    [SerializeField]
    private Rigidbody sword;
    
    private Vector3 rotationVector;

    private void Update()
    {

        rotationVector = new Vector3(0, Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime, 0);
        if (Input.GetButton("Fire1") == true)
        {
            sword.AddTorque(-rotationVector);
            
        }
        sword.AddTorque(-sword.angularVelocity);
    }
}
