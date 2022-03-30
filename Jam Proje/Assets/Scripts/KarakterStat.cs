using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KarakterStat : MonoBehaviour
    
{
    public Rigidbody2D rb;
    float zaman = 2;
    bool cantakedamage= true;
    // UI
    public Image[] hearts;
    

   
    //Stats
    public int health = 55;
  int maxHealth = 55;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    public void TakeDamage(int amount)
    {
        if (health > 1 && cantakedamage == true)
        {
            hearts[health - 1].enabled = false;
            health -= amount;
            rb.AddForce(Vector2.left * 5750);
            DamageDelay();
            StartCoroutine(EnemyDamageDelay());
        }
        else
        {
          
            Destroy(gameObject);
            //StartCoroutine(EnemyDamageDelay());
            Death();
           
          
        }
    }
    public void Regen(int amount)
    {
        health += amount;
        for (int i = 0; i < health; i++)
        {
            hearts[i].enabled = true;
        }

    }
    private void Update()
    {
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        //if(Input.GetKeyDown(KeyCode.H))
        //{
        //    if(health>0)
        //    {
        //        TakeDamage(1);
        //    }

        //}
        //if(Input.GetKeyDown(KeyCode.J))
        //{
        //    if(health < maxHealth)
        //    {
        //        Regen(1);
        //    }
        
    }
    IEnumerator EnemyDamageDelay()
    {
        yield return new WaitForSeconds(1f);
        
    }
    void Death()
    {
        for (zaman = 2; zaman > 0; zaman -= Time.deltaTime)
        {


            SceneManager.LoadScene("SampleScene");


        }
    }
        void DamageDelay()
        {
            for (zaman = 1; zaman > 0; zaman -= Time.deltaTime)
            {
            EnemyDamageDelay();

                cantakedamage = false;
            for (zaman = 1; zaman > 0; zaman -= Time.deltaTime)
            {

                EnemyDamageDelay();
                cantakedamage = true;


            }

        }

            //if (zaman > 0)
            //{
            //    zaman -= Time.deltaTime;
            //    Debug.Log(zaman);
            //}
            //else
            //{
            //    SceneManager.LoadScene("SampleScene");
            //}

        }
}

 