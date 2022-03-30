using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hareket : MonoBehaviour
{
    public float hiz = 10;
    private Rigidbody2D rigid;
    Animator animator;
    bool faceRight = true;
    public Vector3 offset;
    public int damage;
    RaycastHit2D hit;
    bool canAttack = true;
    Vector2 forward;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
        }

    }
    void FixedUpdate()
    {
        float dikey2 = Input.GetAxis("Vertical");
        float yatay = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(hiz * yatay, hiz * dikey2);

        if (dikey2 > 0 || dikey2 < 0 || yatay < 0 || yatay > 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (faceRight == true && yatay < 0)
        {
            Flip();
        }
        else if (faceRight == false && yatay > 0)
        { Flip(); }

    }
    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private void Attack()
    {
        canAttack = false;
        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        { forward = transform.TransformDirection(Vector2.right * 2); }
        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

        animator.SetTrigger("atak");
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;

    }

}
