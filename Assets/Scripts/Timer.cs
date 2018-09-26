using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer :MonoBehaviour{
    public float time;
    public float timer=0f;
    public bool isInner;
    public bool isOutter;
    public Timer(float fixedval)
    {
        time = fixedval;
    }
    public IEnumerator InnerTimeCounter()
    {
        if (timer > time)
        {
            isInner = false;
            StopCoroutine(InnerTimeCounter());
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.016f);
            StartCoroutine(InnerTimeCounter());
            Debug.Log("counting");
        }
        yield return null;
    }

}
