using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMove : MonoBehaviour
{
    public float speed = 5;
    public float rotate = 100;
    void Update()
    {
        float forwardMove = Input.GetAxis("Vertical")
            * speed * Time.deltaTime; // s 뒤로  w앞으로
        transform.Translate(0, 0, forwardMove);
        float _rotate = Input.GetAxis("Horizontal") 
            * rotate * Time.deltaTime;
        transform.Rotate(new Vector3(0, _rotate, 0));
    }
}
