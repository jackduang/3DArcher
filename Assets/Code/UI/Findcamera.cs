using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findcamera : MonoBehaviour
{
    public Vector3 UIOffset = new Vector3(0,100,0);
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 cameraPos=  Camera.main.WorldToScreenPoint(transform.parent.position);
        UI.transform.position = cameraPos+ UIOffset;
    }
}
