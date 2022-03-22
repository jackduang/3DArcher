using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameralControl : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPostRender()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(material!=null)
            Graphics.Blit(source, destination, material);
    }
}
