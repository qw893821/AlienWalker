using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public Animator anim;
    public bool walk, run, idle;

    void AnimeSelect()
    {
        if (walk)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run",false);
        }
        else if (run)
        {
            anim.SetBool("Walk",false);
            anim.SetBool("Run", true);
        }
    }

}
