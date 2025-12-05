using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public MyFirstScript Victium;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Victium == null) return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Victium.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Victium.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Destroy(Victium.gameObject);
            Victium = null;
        }


    }
}
