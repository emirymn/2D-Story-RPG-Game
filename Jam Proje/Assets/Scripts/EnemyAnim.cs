using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public float hiz;
    public int turnDelay;
    public int health;
     Animator animator;
    bool faceRight = false;
    bool yurumek;
    int rastgelemove;
   public Rigidbody2D rb;
    public int enemygeritepme = 350;
    Animator animatorr;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(IEFlip());
    }
    private void Update()
    {
      
      

    }
    void FixedUpdate()
    {
     
        
       transform.Translate(Vector3.right * hiz * Time.deltaTime);
        IEFlip();

        
    }
    
    IEnumerator IEFlip()
    {
        yield return new WaitForSeconds(turnDelay);
            Flip2();
    }
    private void Flip2()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        hiz *= -1;
        StartCoroutine(IEFlip());
    }
    public void TakeDamage(int amount) //öldürme
    {
        rb.AddForce(Vector2.right * enemygeritepme);
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<KarakterStat>().TakeDamage(1); // aldýðý damage

           
        }
        StartCoroutine(Delay());
        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    collision.transform.GetComponent<KarakterStat>().TakeDamage(0);
        //    animatorr.SetBool("block", true);
        //}
        //else if(Input.GetKeyUp(KeyCode.E))
        //        {
        //    animator.SetBool("block", false);
        //}

    }
   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }

}
