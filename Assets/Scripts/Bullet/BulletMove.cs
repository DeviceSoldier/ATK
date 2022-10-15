using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Transform dragon;
    private GameObject target;
    public float speed;
    public float duration;
    private float timer = 0f;
    private float controll = 0f;

    void Start()
    {
        target = GameObject.Find("PlayerOBJ");
        dragon = GameObject.Find("DoragonRoot").transform;
        controll = Random.Range(-100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > duration)
            return;
        timer += Time.deltaTime;

        Vector3 middlePoint = Vector3.Lerp(dragon.position, target.transform.position, 0.5f);
        middlePoint += target.transform.rotation * Vector3.right * controll;
        transform.position =
            BezirCurve.GetPoint(dragon.position,
                target.transform.position + (target.transform.rotation * Vector3.right), middlePoint, timer / duration);
        transform.LookAt(target.transform);
        //transform.position += transform.forward * speed;
    }
}