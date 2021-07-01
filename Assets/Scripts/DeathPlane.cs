using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathPlane : MonoBehaviour
{
    Sausage sausage;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<Sausage>(out sausage);
        if (sausage)
        {
            sausage.isFailed = true;
        }
    }
}
