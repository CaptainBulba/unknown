using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : MonoBehaviour
{
    public Material dog;

    // Start is called before the first frame update
    void Start()
    {
        Transform page1 = gameObject.transform.GetChild(0);
        Transform page2 = gameObject.transform.GetChild(1);

        Material[] m = page1.GetChild(0).GetComponent<MeshRenderer>().materials;
        m[1] = dog;
        page1.GetChild(0).GetComponent<MeshRenderer>().materials = m;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
