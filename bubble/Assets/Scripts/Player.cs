using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Vector2 inputDirection;
    [SerializeField]
    private Rigidbody rigid;
    public int JumpPower;
    private bool isMove;
    public float speed;
    private bool isJump = false;
    private bool getWeapon = false;
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator.SetBool("isMove", false);
    }

    // Update is called once per frame
    void Update()
    {
        Move(inputDirection);
    }
    public void IsJump()
    {
        if(isJump == true)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = false;
        }
        
    }

    public void GetWeapon()
    {
        getWeapon = !getWeapon;
        animator.SetBool("GetWeapon", getWeapon);
    }
    public void Move(Vector2 inputDirection)
    {
        isMove = inputDirection.magnitude != 0;

        Vector3 move = new Vector3(inputDirection.y, 0f, -inputDirection.x).normalized;
        if (isMove)
        {

            transform.position += move * Time.deltaTime * speed;     
        }

        transform.position += move * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJump = true;
    }
}

