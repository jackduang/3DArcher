using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    public LayerMask layer;
    public float rotaSpeed = 0.5f;
    public float MoveSpeed = 10;
    public Animator anima;
    Rigidbody rig;
    Transform arrow;
    // Start is called before the first frame update
    float H = 0;
    float V = 0;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        arrow = transform.Find("Arrow");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        Ray ra = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        var ph = Physics.Raycast(ra,out RaycastHit raycastHit,1000, layer);
        if (!ph) return;
        Vector3 dir = raycastHit.point;
        dir.y = transform.position.y;
        arrow.DOLookAt(dir, rotaSpeed);
    }
    private void FixedUpdate()
    {
        print(arrow.forward * V * MoveSpeed);
        rig.AddForce(arrow.forward*V* MoveSpeed, ForceMode.VelocityChange);
        anima.SetFloat("Speed", rig.velocity.z);
        // transform.forward = 
    }
}
