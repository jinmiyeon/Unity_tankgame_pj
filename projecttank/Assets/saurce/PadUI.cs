using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PadUI : MonoBehaviour
{
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject b = GameObject.Find("imgPadBG");
        GameObject c = GameObject.Find("imgPadCenter");
        GameObject g = GameObject.Find("Player");

        if (isPressed)
        {
            float r = 50;
            Vector3 v = Input.mousePosition - b.transform.position;

            if (v.magnitude < r)
                c.GetComponent<RectTransform>().position = Input.mousePosition;
            else
                c.GetComponent<RectTransform>().position = b.transform.position + v.normalized * r;

            //GameObject.Find("Player").GetComponent<Player>().PlayerDirection(new Vector3(v.x, 0, v.y));
            Player._instance.PlayerDirection(new Vector3(v.x, 0, v.y));

        }
        
        else
        {         
            c.transform.position = Vector3.Lerp(c.transform.position, b.transform.position, 0.05f);
            //c.GetComponent<RectTransform>().position = b.transform.position;
        }

        
    }

    public void DownCenter()
    {
        isPressed = true;
    }

    public void UpCenter()
    {
        isPressed = false;
    }
}
