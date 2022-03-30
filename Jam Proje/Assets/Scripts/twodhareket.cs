using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class twodhareket : MonoBehaviour
{
    public float hiz = 10;
    private Rigidbody2D rigid;
    Animator animator;
    bool faceRight = true;
    public Vector3 offset;
    public int damage;
    public int jumpSpeed;
    RaycastHit2D hit;
    bool canAttack = true;
    Vector2 forward;
    bool canJump = true;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.S) && canAttack)
        {
            Kayma();
        }
        if (Input.GetKeyDown(KeyCode.W) && canAttack)
        {
            Jump();
        }
        // if (Input.GetKeyDown(KeyCode.Q) && canAttack)
        //  {
        //  hiz = hiz * 2f;
        // qhiz();
        // hiz = hiz / 2f;


        //  }
        //if (Input.GetKeyDown(KeyCode.Q) && canAttack)
        //{
        //    QAttack();
        //}

    }
    void FixedUpdate()
    {
       // float dikey2 = Input.GetAxisRaw("Vertical");
        float yatay = Input.GetAxisRaw("Horizontal");
        // transform.Translate(new Vector2(yatay, dikey2) * Time.deltaTime * hiz);
        rigid.velocity = new Vector2(yatay * hiz, rigid.velocity.y);

      //  if (dikey2 > 0 || dikey2 < 0 || yatay < 0 || yatay > 0)
            if (yatay < 0 || yatay > 0)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag =="Platform")
        {
            canJump = true;
        }

    }
    private void Jump()
    {
        if(canJump)
        {
            rigid.AddForce(Vector2.up * jumpSpeed);
            canJump = false;
        }
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
    //private void QAttack()
    //{
    //    canAttack = false;
    //    if (!faceRight)
    //    {
    //        forward = transform.TransformDirection(Vector2.right * -2);
    //    }
    //    else
    //    { forward = transform.TransformDirection(Vector2.right * 2); }
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

    //    animator.SetTrigger("qskill");
    //    StartCoroutine(QAttackDelay());
    //}

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;

    }
    //IEnumerator qhiz()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    canAttack = true;
    //    hiz = hiz / 2f;
    //}
    //IEnumerator QAttackDelay()
    //{
    //    yield return new WaitForSeconds(5f);
    //    canAttack = true;

    //}
    private void Kayma()
    {
        animator.SetTrigger("kayma");
    }

}
