using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsInteraction : PlayerInterface
{
    public bool isOpen;
    public float yRotation = 0;
    public float zValue = 4f;
    public float xValue = 0.25f;
    Vector3 originalLocation;
    Quaternion originalRotation;

    public void Start() {
        originalLocation = this.transform.position;
        originalRotation = this.transform.rotation;
    }

    public void OnMouseDown() {
        if (Vector3.Distance(this.transform.position, player.transform.position) > 3)
        {
            return;
        }
        if (this.transform.position == originalLocation) {
            open.Play();
            this.transform.position = new Vector3(xValue, this.transform.position.y, zValue);
            this.transform.rotation = new Quaternion(this.transform.rotation.x, yRotation, this.transform.rotation.z, this.transform.rotation.w);
            isOpen = true;
        } else {
            close.Play();
            this.transform.position = originalLocation;
            this.transform.rotation = originalRotation;
            isOpen = false;
        }
    }
}
