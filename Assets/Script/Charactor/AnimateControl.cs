using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateControl : MonoBehaviour
{
    [Header("공격")]
    [SerializeField] private bool AttackA;
    [SerializeField] private bool AttackB;
    [SerializeField] private bool AttackC;
    
    [Header("이동")]
    [SerializeField] private bool CrouchState;
    [SerializeField] private float HorizontalMove;
    [SerializeField] private bool JumpState;


    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        AttackA = false;
        AttackB = false;
        AttackC = false;
        CrouchState = false;
        HorizontalMove = 0.0f;
        JumpState = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    public void ActionAttackA(bool input) {
        if (input == true) {
            anim.enabled = false;
            anim.enabled = true;
        }
        anim.SetBool("AttackA", input);
    }
    public void ActionAttackB(bool input) {
        anim.SetBool("AttackB", input);
    }
    public void ActionAttackC(bool input) {
        anim.SetBool("AttackC", input);
    }
    public void ActionCrouch(bool input) {
        anim.SetBool("Crouch", input);
    }
    public void MoveAnimation(float input) {
        anim.SetFloat("HMove", input);
    }



}
