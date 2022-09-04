using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMove : MonoBehaviour
{
    public float acc = 200;      // 가속도(acceleration)
    public float maxSpeed = 20000;
    public float currentSpeed = 0;
    public float attenuation = 0.1f;   // 마찰에 의한 속도 감쇠('감쇠'는 '힘이나 세력 따위가 줄어서 약하여짐.')
    [SerializeField] float maxAttenuation;
    public float backSpeedRatio = 0.5f;
    public float rotate = 1f;
    public Rigidbody rb;
    private void FixedUpdate()
    {
        var angularVelocity = rb.angularVelocity;
        angularVelocity.x = 0; // 앞뒤로 흔들리는 물리 제거
        angularVelocity.z = 0; // 좌우로 흔들리는 물리 제거
        rb.angularVelocity = angularVelocity;

        var velocity = rb.velocity;
        velocity.x = 0; // 좌우 이동
        velocity.z = 0; // 앞뒤 이동
        rb.velocity = velocity;

        float forwardMove = Input.GetAxis("Vertical");

        currentSpeed = currentSpeed + acc * forwardMove;  // 속도 증가/감소
        float absCurrentSpeed = Math.Abs(currentSpeed);
        maxAttenuation = Math.Clamp(acc * attenuation, -absCurrentSpeed, absCurrentSpeed);
        currentSpeed = currentSpeed + (currentSpeed > 0 ? -maxAttenuation : maxAttenuation); // 감쇠
        currentSpeed = Math.Clamp(currentSpeed, -maxSpeed * backSpeedRatio, maxSpeed);
        float force = currentSpeed;

        if (force != 0)
        {
            var forward = transform.forward;
            forward.y = 0;
            rb.AddForce(forward * force);
        }

        float rotate = Input.GetAxis("Horizontal") * this.rotate;
        rb.AddRelativeTorque(0, rotate, 0, ForceMode.VelocityChange);
    }
}
