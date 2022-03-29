using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class CameraControl : MonoBehaviour
{
    public GameObject[] Points;
    BezierSpline beziers;
    BezierWalkerWithSpeed withSpeed;
    // Start is called before the first frame update
    void Start()
    {
        beziers = new GameObject().AddComponent<BezierSpline>();
        withSpeed = GetComponent<BezierWalkerWithSpeed>();
        withSpeed.spline = beziers;
        beziers.Initialize(3);
        //transform.position = Points[4].transform.position;
        //transform.LookAt(Points[5].transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetCameraPos(0);

        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SetCameraPos(2);

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SetCameraPos(1);

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            SetCameraPos(3);

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SetCameraPos(4);

        }
    }
    public void SetCameraPos(int index)
    {
        withSpeed.enabled = true;
        Vector3 end = Points[index].transform.position;
        //transform.position = Points[index].transform.GetChild(0).position;
        beziers[0].position = transform.position;
        beziers[1].position = GetControlVector(transform.position,end);

        beziers[beziers.Count-1].position = end;
        withSpeed.Execute(1);
        transform.LookAt(Points[5].transform.position);
    }
    Vector3 GetControlVector(Vector3 startPoint,Vector3 EndPoint) 
    {
        Vector3 MidPos = EndPoint- startPoint;
        MidPos.y = 0.505f;
        MidPos *= 0.5f;
       Vector3 dir = MidPos - Points[5].transform.position;
        MidPos += dir.normalized * 5;
        return MidPos;
    }
}
