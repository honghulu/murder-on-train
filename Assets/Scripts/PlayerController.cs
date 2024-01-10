using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerInterface
{
    public float moveSpeed;
    private Vector3 moveInput;
    private Vector3 mouseInput;
    public float mouseSensitivity = 1f;
    public Transform viewCam;
    public AudioSource footstep;
    //public Animator control;
    //public Animation ani;
    void Update()
    {
        //Player Movement
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            
                footstep.Play();
            
        }
        

        thisRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.right * moveInput.x;
        Vector3 moveVertical = transform.forward * moveInput.z;
        this.transform.position += (moveHorizontal + moveVertical) * moveSpeed * Time.deltaTime;

        //Player View Control
        mouseInput = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        viewCam.localRotation = Quaternion.Euler(viewCam.localRotation.eulerAngles + new Vector3(-1 * mouseInput.z, 0f, 0f));
    }
}
