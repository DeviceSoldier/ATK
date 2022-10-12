using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapPunchandSnap_Test02 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        print($"velocity = {_rigidbody.velocity}");
    }
}
