using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer{
    public float time;
    /*public*/ float timer=0f;
    public bool isInner;
    public bool isOutter;

    //a trigger to start the count;
    public bool trigger=false;

    public Timer(float fixedval)
    {
        time = fixedval;
    }
    public void InnerTimeCounter()
    {
        Counter();
        if (timer > time)
        {
            trigger = false;
        }
        else { }
    }

    void Counter()
    {
        if (trigger)
        {
            timer += Time.deltaTime;
        }
        else
        {
            TimerReset();
        }
    }

    //reset timer to 0;
    public void TimerReset()
    {
        timer = 0;
    }
}
