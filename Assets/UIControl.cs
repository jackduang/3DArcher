using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIControl : MonoBehaviour
{
    GameObject ConnetUI;
    bool down = true;
    string defultHost = "localhost";
    private void Awake()
    {
        ConnetUI = GameObject.Find("ConnetSet");
        //GameObject.Find("Address").GetComponent<Text>().text = defultHost;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(down)
                ConnetUI.transform.DOLocalMoveY(82, 0.75f);
            else
                ConnetUI.transform.DOLocalMoveY(790, 0.75f);
            down = !down;
        }
    }
}
