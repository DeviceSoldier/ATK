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
        _keepVec = new Vector3(direction.x, 0f, direction.y);
        _keepVec *= distance;
        _keepVec.y = height;
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.gameObject.GetComponentInChildren<Animator>().transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        float deltaHeight = Mathf.Lerp(0f, -40f, Timeline.CurrentTime / _phaseManager.phaseBTime);
        transform.position = _playerTransform.position + _keepVec + Vector3.up * deltaHeight;
    }
}