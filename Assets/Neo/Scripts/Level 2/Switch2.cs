using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    private Animator anim;
    public static bool isSwitchOn;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSwitchOn)
        {
            anim.SetBool("on", true);
        }
    }

    public static void SwitchOn()
    {
        isSwitchOn = true;
    }
}
