using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Qskill : MonoBehaviour
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

       
        if (Input.GetKeyDown(KeyCode.Q) && canAttack)
        {
            
            QAttack();
            hiz = hiz * 2f;
            Delay();
            hiz = hiz / 2f;
        }

    }
    void FixedUpdate()
    {
    

    }
    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
 
    private void QAttack()
    {
        canAttack = false;
        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        { forward = transform.TransformDirection(Vector2.right * 2); }
        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

        animator.SetTrigger("qskill");
        StartCoroutine(QAttackDelay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator QAttackDelay()
    {
        yield return new WaitForSeconds(5f);
        canAttack = true;

    }

}
