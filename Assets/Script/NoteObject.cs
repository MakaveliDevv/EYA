using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool noteHit;  // Add this flag
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
 
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                noteHit = true;  // Set the flag to true when the note is hit|
                gameObject.SetActive(false);
                // GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > .25) 
                {
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    Debug.Log("Hit");
                }
                else if(Mathf.Abs(transform.position.y) > .05f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("Good Hit");
                }
                else 
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("Perfect Hit");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Activator"))
        {
            canBePressed = true;
            // Debug.Log("CanBePressed");
        }
    }

    void OnTriggerExit2D(Collider2D other)	
    {
        if(other.CompareTag("Activator"))
        {
            if(!noteHit)
            {
                canBePressed = false;
                // Debug.Log("CannotBePressed");
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
