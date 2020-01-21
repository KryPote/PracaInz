using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    public GameMaster gameMaster;
    public bool open;
    public int value = 1;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        open = false;
    }
    void Update()
    {
        anim.SetBool("open", open);

        if(gameMaster.nuts >= value)
        {
            open = true;
        }
    }
}
