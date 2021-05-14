using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    private float translation;
    private float rotation;

    public float tspeed = 10f;
    public float rspeed = 100f;
    void Update() {
        translation = Input.GetAxis("Vertical") * 10f; 
        rotation = Input.GetAxis("Horizontal") * 100f;

        transform.Translate(0, 0, translation* Time.deltaTime);
        transform.Rotate(0, rotation* Time.deltaTime, 0);
    }
}
