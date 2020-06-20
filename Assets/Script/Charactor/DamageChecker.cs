using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//공격, 공격판정
//https://www.gamasutra.com/blogs/NahuelGladstein/20180514/318031/Hitboxes_and_Hurtboxes_in_Unity.php
public class DamageChecker : MonoBehaviour {


    [Range(0.0f, 100.0f)]
    public float damageAttackA;
    [Range(0.0f, 100.0f)]
    public float damageAttackB;
    [Range(0.0f, 100.0f)]
    public float damageAttackC;
    [Range(0.0f, 100.0f)]
    public float damageAttackCA;

    [Header("HP check")]
    [Range(0.0f, 200.0f)]
    public float MaxHP = 200.0f;
    [SerializeField] private float nowHP;
    [SerializeField] private Scrollbar sBar;
    

    [Header("Actions")]
    [SerializeField] private GameObject ColliderAttackA;
    [SerializeField] private GameObject ColliderAttackB;
    [SerializeField] private GameObject ColliderAttackC;
    [SerializeField] private GameObject ColliderAttackCA;




    // Start is called before the first frame update
    void Start() {
        nowHP = MaxHP;
        ColliderAttackA.GetComponent<EngageHit>().Damage = damageAttackA;
        ColliderAttackC.GetComponent<EngageHit>().Damage = damageAttackC;
        ColliderAttackCA.GetComponent<EngageHit>().Damage = damageAttackCA;
        

        ColliderAttackA.GetComponent<BoxCollider2D>().enabled = false;
        ColliderAttackC.GetComponent<BoxCollider2D>().enabled = false;
        ColliderAttackCA.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame

    public void ActionAttackA(bool input) {
        if (input == true) {
            ColliderAttackA.GetComponent<BoxCollider2D>().enabled = true;
            Invoke("ResetState", 0.7f);
        }
    }
    public void ActionAttackB(bool input) {
        ColliderAttackB.GetComponent<BoxCollider2D>().enabled = input;
        //  Invoke("ResetState", 0.7f);
    }
    public void ActionAttackC(bool input) {
        if (input == true) {
            ColliderAttackC.GetComponent<BoxCollider2D>().enabled = input;
            Invoke("ResetState", 1.2f);
        }
    }
    public void ActionAttackCA(bool atinput, bool input) {
        if (atinput == true && input == true) {
            ColliderAttackCA.GetComponent<BoxCollider2D>().enabled = true;
            Invoke("ResetState", 0.7f);
        }
    }



    public void ResetState() {
        ColliderAttackA.GetComponent<BoxCollider2D>().enabled = false;
        ColliderAttackC.GetComponent<BoxCollider2D>().enabled = false;
        ColliderAttackCA.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void HurtDamage(float Damage) {
        Debug.Log(gameObject.name + " is got " + Damage + " Damage!");
        //피격 효과
        nowHP -= Damage;

        sBar.size = (nowHP / MaxHP);

    }

}