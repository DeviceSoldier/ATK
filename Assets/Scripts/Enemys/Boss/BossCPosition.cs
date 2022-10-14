using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCPosition : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float height;
    [SerializeField] private float deltaHeight;
    private Vector3 _keepVec;
    [SerializeField] private float minPercentage;
    [SerializeField] private float comeTime, waitTime, leaveTime;
    private Vector3 _vec;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove_1005>().transform;
        direction = direction.normalized;
        var tempVec = direction * distance;
        _keepVec = new Vector3(tempVec.x, height, tempVec.y);
        _keepVec = _keepVec.normalized;
        StartCoroutine(Act());
    }

    void Update()
    {
        var t = Timeline.CurrentTime % 1f;
        transform.position = _playerTransform.position + _vec + Vector3.up * deltaHeight;
    }

    IEnumerator Act()
    {
        while (true)
        {
            yield return StartCoroutine(Come(comeTime));
            yield return StartCoroutine(Wait(waitTime));
            yield return StartCoroutine(Leave(leaveTime));
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator Come(float time)
    {
        var timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _vec = _keepVec * (distance * Mathf.Lerp(1f, minPercentage, timer / time));
            yield return null;
        }
    }

    IEnumerator Leave(float time)
    {
        var timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _vec = _keepVec * (distance * Mathf.Lerp(minPercentage, 1f, timer / time));
            yield return null;
        }
    }
}