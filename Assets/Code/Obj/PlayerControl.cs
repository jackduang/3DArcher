using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    public LayerMask layer;
    public float ArrowRotaSpeed = 0.5f;
    public float RotaSpeed = 0.4f;
    public float MoveSpeed = 250;
    public float Gravity = 20;
    public float jumpSpeed = 10;

    private CharacterController _characterController;
    public Animator anima;
    Rigidbody rig;
    Transform arrow;
    // Start is called before the first frame update
    float H = 0;
    float V = 0;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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
        print(V);
        
        if(V!=0) anima.SetBool("Run", true);
        else anima.SetBool("Run", false);

        Ray ra = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        var ph = Physics.Raycast(ra,out RaycastHit raycastHit,1000, layer);
        if (!ph) return;
        Vector3 dir = raycastHit.point;
        dir.y = transform.position.y;
        arrow.DOLookAt(dir, ArrowRotaSpeed);
    }

    private void FixedUpdate()
    {
        if (V != 0)
        {
            transform.GetChild(0).DOLookAt(transform.Find("Arrow/LookPoint").position, RotaSpeed);
            _characterController.SimpleMove(arrow.forward * MoveSpeed);

            //rig.MovePosition(transform.position+arrow.forward * MoveSpeed * Time.fixedDeltaTime);
        }
        if (_characterController.isGrounded)
        {
            // 跳跃
            if (Input.GetButton("Jump"))
            {
                rig.AddForce(jumpSpeed * new Vector3(0, 100, 0));
                print("Jump");
            }
        }
    }
}
