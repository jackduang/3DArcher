using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bezier : MonoBehaviour
{
    public Transform[] controlPoints;
    public float speed;
    public bool canMove =true;
    void Start()
    {
    }
    public float inex = 0;
    public float _segmentNum = 200;

    void FixedUpdate()
    {
        if (canMove)
        {
            inex += Time.deltaTime * speed;
            float t = inex / (float)_segmentNum;
            if (Vector3.Distance(transform.position, controlPoints[2].position) > 0.5f && 0 < t && t < 1)
            {

                
                transform.position = Vector3.Lerp(transform.position, BezierUtils.CalculateCubicBezierPoint(t, controlPoints[0].position,
                controlPoints[1].position, controlPoints[2].position), Time.deltaTime*speed);
                transform.LookAt(GameObject.Find("lookpont").transform);
            }
            else
            {
                canMove = false;
            }
        }
        
        
    }

    public void changedir()
    {

        var temp = controlPoints[0];
        controlPoints[0] = controlPoints[2];
        controlPoints[2] = temp;
    }
}
