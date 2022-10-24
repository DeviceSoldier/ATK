using System;
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
    private PhaseManager _phaseManager;

    void Start()
    {
        _phaseManager = FindObjectOfType<PhaseManager>();
        _playerTransform = FindObjectOfType<PlayerMove_1005>().transform;

        direction = direction.normalized;
        var tempVec = direction * distance;
        _keepVec = new Vector3(tempVec.x, height, tempVec.y);
        _keepVec = _keepVec.normalized;
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.gameObject.GetComponentInChildren<Animator>().transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        float deltaHeight = Mathf.Lerp(0f, 60f, Timeline.CurrentTime / _phaseManager.phaseBTime);
        var dis = Mathf.Lerp(distance, 150f, Timeline.CurrentTime / _phaseManager.phaseBTime);
        var vec = _keepVec * dis + _playerTransform.position;
        vec.y = _playerTransform.position.y + deltaHeight;
        transform.position = vec;
    }
}