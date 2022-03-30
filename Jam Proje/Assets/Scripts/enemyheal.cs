using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyheal : MonoBehaviour
{
    public int health;
    int amount;

    private void Update()
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Helikopterr");
        }
    }
    
}
