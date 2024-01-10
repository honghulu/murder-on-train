using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDoorInteraction : PlayerInterface
{
    public bool isOpen;
    public float yRotation = 87f;
    public float zValue = 11.54f;
    public float xValue = 1.022f;
    Vector3 originalLocation;
    Quaternion originalRotation;

    public void Start()
    {
        originalLocation = this.transform.position;
        originalRotation = this.transform.rotation;
    }

    public void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) > 3)
        {
            return;
        }
        if (this.transform.position == originalLocation)
        {
            print("open");
            open.Play();
            this.transform.position = new Vector3(xValue, this.transform.position.y, zValue);
            this.transform.Rotate(0, yRotation, 0);
            isOpen = true;
        }
        else
        {
            close.Play();
            this.transform.position = originalLocation;
            this.transform.rotation = originalRotation;
            isOpen = false;
        }
    }
}