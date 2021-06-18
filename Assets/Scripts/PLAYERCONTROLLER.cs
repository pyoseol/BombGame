using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    private float translation; 
    private float rotation;

    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.isGameover) { return; }
        translation = Input.GetAxis("Vertical") * 15f;
        rotation = Input.GetAxis("Horizontal") * 100f;

        transform.Translate(0, 0, translation * Time.deltaTime);
        transform.Rotate(0, rotation * Time.deltaTime, 0);

        if (translation != 0 || rotation != 0)
        {
            ani.SetBool("Run Forward", true);
        }
        else
        {
            ani.SetBool("Run Forward", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameover) { return; }
        if (collision.collider.tag == "Obstacle")
        {
            ani.SetTrigger("Take Damage");
            GameManager.instance.AddScore(-1);
        }
        if (collision.collider.tag == "Enermy")
        {
            ani.SetTrigger("Die");
            GameManager.instance.OnPlayerDead();
        }
    }
}


