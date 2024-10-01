using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerObject : MonoBehaviour
{
    public float health;

    public Text healthbar;

//     public Text towerHealthLeft1, towerHealthLeft2, towerHealthRight1, towerHealthRight2; 
//     public int currentTowerHealthLeft1, currentTowerHealthLeft2, currentTowerHealthRight1, currentTowerHealthRight2; 


    void Start(){
        healthbar.text = "Health: 100";
        health = 100;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log($"{gameObject.name} was hitted, remain health : {health}");
        healthbar.text = "Health: " + health;
        
        if (health <= 0)
        {
            DestroyTower();
        }
    }

    void DestroyTower()
    {
        Destroy(gameObject);
    }
}



