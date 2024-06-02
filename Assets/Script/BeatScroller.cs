using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo = 120f;
    public bool hasStarted;

    void Start()
    {
        beatTempo /= 60f;
    }

    void Update()
    {
        if(!hasStarted)
        {
            // Something
        }
        else 
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f); // CHANGE THIS LATER ON THE X AXIS (SIDE WAYS) SINCE MY GAME IS NOT GONNA BE FROM TOP DOWN BOT
        }
    }
}
