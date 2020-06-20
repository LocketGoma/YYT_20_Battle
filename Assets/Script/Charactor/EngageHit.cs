using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageHit : MonoBehaviour
{
    private DamageChecker dCheck;
    [SerializeField] private float damage;
    public float Damage { get { return damage; } set { damage = value; } }

    private void Start() {
        dCheck = transform.parent.GetComponent<DamageChecker>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //dCheck.
        Debug.Log(gameObject.ToString());
        if (collision.isTrigger==true)
            collision.GetComponent<DamageChecker>().HurtDamage(Damage);
    }
    private void OnTriggerStay2D(Collider2D collision) {
       // Debug.Log(gameObject.ToString()+" is hitted" + collision.name);
    }


}
