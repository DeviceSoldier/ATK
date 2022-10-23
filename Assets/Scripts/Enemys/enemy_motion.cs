using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_motion : MonoBehaviour
{
    private Animator animator;    //Animatorのコンポーネントの取得・格納用
    private GameObject target; 　 //プレイヤーのオブジェクト
    public GameObject cubeA;   　 //このオブジェクト
    public float jumpPoint;
    void Start()
    {
        target = GameObject.Find("PlayerOBJ");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posA = target.transform.position;
        Vector3 posB = cubeA.transform.position;
        float dis = Vector3.Distance(posA, posB);
        
        if (dis <= jumpPoint)
        {
            animator.SetBool("jump", true);
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Impact"))
        {
            animator.SetBool("dead", true);
        }

        if (col.CompareTag("Leftarm"))
        {
            animator.SetBool("dead", true);
        }
        
        if (col.CompareTag("Guard"))
        {
            animator.SetBool("dead", true);
        }
    }
}
