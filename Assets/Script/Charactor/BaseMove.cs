using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    [Header("Scale")]
    [Range(0.0f, 100.0f)]
    [SerializeField] private float BaseSpeed = 20f;
    [Range(0.0f, 100.0f)]
    [SerializeField] private float JumpPower = 10f;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float GravityWeigth = 1f;
    private Vector3 Gravity = Vector3.down;

    [Header("PlayerData")]
    private Rigidbody2D rbody;

    private void Awake() {
        Gravity *= GravityWeigth * 9.81f;
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        rbody.gravityScale = GravityWeigth;
    }
    void Update() {
       


        if (Input.GetKeyUp(KeyCode.UpArrow))
            Jump();

    }

    public void HorizontalMove(float toggleData) {
        transform.Translate(Vector2.right * toggleData * BaseSpeed / 100.0f);
        /*
        if (toggleData < 0) {
            rbody.AddForce(Vector2.right * toggleData * BaseSpeed);
            
        }
        if (toggleData > 0) {
            rbody.AddForce(Vector2.right * toggleData * BaseSpeed);
        }
        */
    }
    public void Jump() {
        //Debug.Log("JP");
        rbody.AddForce(Vector2.up * JumpPower * rbody.mass, ForceMode2D.Impulse);

    }


}
