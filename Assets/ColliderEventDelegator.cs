using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventDelegator : MonoBehaviour
{
    public GameObject receiveTarget;
    private void OnTriggerEnter(Collider other)
    {
        print(other);
        var param = Tuple.Create(other, name);
        receiveTarget.SendMessage("MyOnTriggerEnter", param);
    }
}
