using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayGround : MonoBehaviour
{
    public float groundLevel;
    Rigidbody myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= (groundLevel)) {
            myRigid.constraints = RigidbodyConstraints.FreezeAll;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.position = new Vector3(transform.position.x, groundLevel+ 2.2f, transform.position.z);
        }
    }
}
