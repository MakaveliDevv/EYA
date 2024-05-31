using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite defaultImg;
    public Sprite pressedImg;

    public KeyCode keyToPress;

    void Start() 
    {
        sr = GetComponent<SpriteRenderer>();

    }

    void Update() 
    {
        if(Input.GetKeyDown(keyToPress))
        {
            sr.sprite = pressedImg;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            sr.sprite = defaultImg;
        }
    }
}
