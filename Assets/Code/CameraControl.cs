using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    public Transform lookPoint;
    public float speed=  5;
    float lastAngle = 0;
    float rotaAngle = 0;
    bezier bezie;
    // Start is called before the first frame update
    void Start()
    {
        bezie = GetComponent<bezier>();

    }
    void OnCpmpleted()
    {

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
            bezie.inex = 0;
            bezie.canMove = true;
            bezie.changedir();
        }
    }
    void doAngle()
    {
        //lastAngle += rotaAngle;
        transform.parent = lookPoint;

        transform.parent.DORotate(new Vector3(0, rotaAngle, 0), 1f);
    }
    private void FixedUpdate()
    {
    }
}
