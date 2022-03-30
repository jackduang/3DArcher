using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    public GameObject[] Points;
    BezierWalkerWithTime bezier;
    public float speed=  5;
    float lastAngle = 0;
    float rotaAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        bezier = GetComponent<BezierWalkerWithTime>();
        bezier.onPathCompleted.AddListener(OnCpmpleted);
        
        //transform.position = Points[4].transform.position;
        //transform.LookAt(Points[5].transform.position);

    }
    void OnCpmpleted()
    {
        bezier.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            rotaAngle = 180;
            doAngle();

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            rotaAngle = 90;
            doAngle();

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            rotaAngle = -90;
            doAngle();

        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            rotaAngle = 0;
            doAngle();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            bezier.enabled = true;

            bezier.isGoingForward = !bezier.isGoingForward;
            if (!bezier.isGoingForward)
            {
                bezier.NormalizedT = 1;
            }
            else
            {
                bezier.NormalizedT = 0;
            }

        }
    }
    void doAngle()
    {
        //lastAngle += rotaAngle;
        transform.parent.DORotate(new Vector3(0, rotaAngle, 0), 1f);
    }
    private void FixedUpdate()
    {
    }
}
