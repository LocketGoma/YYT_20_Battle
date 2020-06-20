using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//= 사실상 캐릭터측 "컨트롤 매니저"
public class CharactorControl : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private bool keyA;
    [SerializeField] private bool keyB;
    [SerializeField] private bool keyC;
    [SerializeField] private bool keyX;     //앉기
    [SerializeField] private bool keyY;     //점프


    [Header("Scripts")]
    [SerializeField] private AnimateControl aControl;
    [SerializeField] private BaseMove bMove;
    [SerializeField] private DamageChecker dCheck;      //공격판정 쪽




    // Start is called before the first frame update
    void Start()
    {
        aControl = GetComponent<AnimateControl>();
        bMove = GetComponent<BaseMove>();
        dCheck = GetComponent<DamageChecker>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float moveState = Input.GetAxis("Horizontal");
        keyA = Input.GetKeyDown(KeyCode.Z);
        keyB = Input.GetKeyDown(KeyCode.X);
        keyC = Input.GetKeyDown(KeyCode.C);
        keyX = Input.GetKey(KeyCode.DownArrow);


        bMove.HorizontalMove(moveState);

        dCheck.ActionAttackA(keyA);
        dCheck.ActionAttackC(keyC);
        dCheck.ActionAttackCA(keyA, keyX);

        aControl.ActionAttackA(keyA);
        aControl.ActionAttackB(keyB);
        aControl.ActionAttackC(keyC);
        aControl.ActionCrouch(keyX);
        aControl.MoveAnimation(moveState);
    }
}
