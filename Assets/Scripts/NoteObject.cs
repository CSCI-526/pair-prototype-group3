using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerObject;



public class NoteObject : MonoBehaviour
{
    
    public bool canBePressed;
    public bool hasStarted;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public int player;
    public float damage; 
    public float speed;
    public float normalRate, goodRate;
    private TowerObject tower;

    // Start is called before the first frame update
    void Start()
    {
        speed =2;
        damage = 5;
        normalRate = 0.5f;
        goodRate = 0.25f;
        tower = null; 
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            hasStarted = true;
        }
        if (hasStarted && player == 1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (hasStarted && player == 2)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                Debug.Log("Can hit in key");
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();
                //Mathf.Abs(transform.position.x + 8.01f) denotes the distance between the note and square.
                if (player == 2)
                {
                    if (Mathf.Abs(transform.position.x + 8.01f) > 0.25f)
                    {
                        Debug.Log("Hit");
                        if (tower != null)
                        {
                            tower.TakeDamage(damage * normalRate);
                        }
        
                        GameManager.instance.NormalHit();
                        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    } else if (Mathf.Abs(transform.position.x + 8.01f) > 0.05f)
                    {
                        Debug.Log("Good");
                        if (tower != null)
                        {
                            tower.TakeDamage(damage * goodRate);
                        }

                        GameManager.instance.GoodHit();
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    } else
                    {
                        Debug.Log("Perferct");
                        GameManager.instance.PerfectHit();
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    }
                }else
                {
                    if (Mathf.Abs(transform.position.x - 8.01f) > 0.25f)
                    {
                        Debug.Log("Hit");
                        if (tower != null)
                        {
                            tower.TakeDamage(damage * normalRate);
                        }
        
                        GameManager.instance.NormalHit();
                        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    } else if (Mathf.Abs(transform.position.x - 8.01f) > 0.05f)
                    {
                        Debug.Log("Good");
                        if (tower != null)
                        {
                            tower.TakeDamage(damage * goodRate);
                        }

                        GameManager.instance.GoodHit();
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    } else
                    {
                        Debug.Log("Perferct");
                        GameManager.instance.PerfectHit();
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    }
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            tower = other.GetComponent<TowerObject>();
            Debug.Log("Can hit");
            canBePressed = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (other.tag == "Activator") 
            {
                canBePressed = false;

                // tower = other.GetComponent<TowerObject>();
                tower.TakeDamage(damage); 
                Destroy(gameObject); 


                GameManager.instance.NoteMissed();
                //Instantiate(missEffect, transform.position, missEffect.transform.rotation);


            }
        }
    }
}


