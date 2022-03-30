using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class karakterhareket : MonoBehaviour
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
        
        float yatay = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(yatay, 0) * Time.deltaTime * hiz);


        if ( yatay < 0 || yatay > 0)
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
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        collision.transform.GetComponent<KarakterStat>().TakeDamage(1); // aldýðý damage
    //    }
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        collision.transform.GetComponent<KarakterStat>().TakeDamage(0);
    //        animator.SetBool("block", true);
    //    }
    //    else if (Input.GetKeyUp(KeyCode.E))
    //    {
    //        animator.SetBool("block", false);
    //    }

    //}
}
