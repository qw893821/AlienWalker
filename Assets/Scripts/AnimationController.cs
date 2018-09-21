using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public Animator anim;
    public bool walk, run, idle;

    private void Update()
    {
        AnimeSelect();
    }
    void AnimeSelect()
    {
        if (walk)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run",false);
            anim.SetBool("Idle", false);
        }
        else if (run)
        {
            anim.SetBool("Walk",false);
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }
    }

}
