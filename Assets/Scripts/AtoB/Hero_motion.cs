using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_motion : MonoBehaviour
{
    private Animator animator;    //Animatorのコンポーネントの取得・格納用
    public bool Run;
    public bool Jump;
    public bool Fall;
    public bool Landing;
    void Start()
    {
        animator = GetComponent<Animator>();
        Run = true;
        Jump = false;
        Fall = false;
        Landing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Run == true)
        {
            animator.SetBool("run", true);
        }
        
        if (Jump == true)
        {
            animator.SetBool("jump", true);
        }
        
        if (Fall == true)
        {
            animator.SetBool("fall", true);
        }
        
        if (Landing == true)
        {
            animator.SetBool("landing", true);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("jump"))
        {
            Run = false;
            Jump = true;
        }
        
        if (col.CompareTag("fall"))
        {
            Jump = false;
            Fall = true;
        }
        
        if (col.CompareTag("landing"))
        {
            Fall = false;
            Landing = true;
        }
    }
}
