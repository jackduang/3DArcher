using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rig;
    // Start is called before the first frame update
    float H = 0;
    float V = 0;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rig.AddForce(transform.forward*V, ForceMode.VelocityChange);
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print(dir);
       // transform.forward = 
    }
}
