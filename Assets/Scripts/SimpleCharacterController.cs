using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.smoothDeltaTime, ForceMode.VelocityChange);

        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
        }
    }
}
