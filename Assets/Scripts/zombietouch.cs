using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombietouch : PlayerInterface
{
    public AudioSource touch;
    void OnMouseDown(){
        touch.Play();
    }
}
