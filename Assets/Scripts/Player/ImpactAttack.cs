using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAttack : MonoBehaviour
{
    private Vector3 prevPosition;
    private Vector3 velocity;

    public GameObject ImpactPosition;
    public GameObject Impact;
    public float hitcount;

    void Start()
    {
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.deltaTime, 0))
            return;
        var position = transform.position;
        velocity = (position - prevPosition) / Time.deltaTime;
        prevPosition = position;
        print($"velocity = {velocity.magnitude}");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Leftarm")
        {
            if (velocity.magnitude >= hitcount)
            {
                GameObject createdBall = Instantiate(Impact) as GameObject;
                createdBall.transform.position = ImpactPosition.transform.position;
            }
        }
    }
}
