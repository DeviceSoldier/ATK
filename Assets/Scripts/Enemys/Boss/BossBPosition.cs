using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBPosition : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float height;
    private Vector3 _keepVec;
    
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove_1005>().transform;
        direction = direction.normalized;
        _keepVec = new Vector3(direction.x, 0f, direction.y);
        _keepVec *= distance;
        _keepVec.y = height;
    }
    
    void Update()
    {
        transform.position = _playerTransform.position + _keepVec;
    }
}
