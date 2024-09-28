using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    
    public bool canBePressed;
    public bool hasStarted;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public float beatTempo;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        // detect whether the game has started
        if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        // Decide where the notes go
        if (hasStarted && player == 1)
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        } else if (hasStarted && player == 2)
        {
            transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
        
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();
                //Mathf.Abs(transform.position.x + 8.01f) denotes the distance between the note and square.
                if (Mathf.Abs(transform.position.x + 8.01f) > 0.25f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } else if (Mathf.Abs(transform.position.x + 8.01f) > 0.05f)
                {
                    Debug.Log("Good");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
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

                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
