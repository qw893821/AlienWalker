using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonsterView : MonoBehaviour {
    [Range(30.0f,90.0f)]
	public float viewAngle;
    public float viewRange;

    //test text shows if player in view
    public GameObject text;
    Text testText;

    private void Start()
    {
        testText = text.GetComponent<Text>();
    }
    private void Update()
    {
        TargetInViewCheck();
    }

    void TargetInViewCheck()
    {
        Collider [] inrangeCol;
        LayerMask selfLayer=1<<8;
        Vector3 currentPos;
        currentPos = transform.position;
        inrangeCol=Physics.OverlapSphere(currentPos, viewRange);
       
        foreach(Collider col in inrangeCol)
        {
            if (col.transform.position != transform.position)
            {
                Vector3 colPos;
                colPos = col.transform.position;
                if (Vector3.Angle(transform.forward, colPos - currentPos) < viewAngle / 2)
                {
                    RayToTarget(col.transform);
                }
                else { testText.text = "not in view"; }
            }
            
        }
        
    }


    void RayToTarget(Transform trans)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, trans.position,out hit, viewRange))
        {
            if (hit.transform.tag == "Player")
            {
                testText.text = "Player in view";
            }
           
        }

    }
}
