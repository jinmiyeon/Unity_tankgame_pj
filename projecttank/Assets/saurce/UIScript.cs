using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    
    
    bool isPressed0 = false;

    bool[] isPressed = new bool[4];
  

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed0)
        {
            print("누르고 있음");
        }
        if (isPressed[0])
        {
            btnForward();
            //this.GetComponent<AudioSource>().Play();
        }
        if (isPressed[1])
        {
            btnBack();
        }
        if (isPressed[2])
        {
            btnLeft();
        }
        if (isPressed[3])
        {
            btnRight();
        }

    }

    public void btnTest() //public 있어야 외부에서 나한테 코드를 접근시킬 수 있다.
    {
        //print("btnTest");
       
        GameObject.Find("Player").GetComponent<Player>().fire();

    }

    public void btnForward()
    {
        GameObject g = GameObject.Find("Player");
        g.transform.position += g.transform.forward *1* 10 * Time.deltaTime;
    }
    public void btnBack()
    {
        GameObject g = GameObject.Find("Player");
        g.transform.position -= g.transform.forward * 1 * 10 * Time.deltaTime;
    }
    public void btnLeft()

    {
        GameObject g = GameObject.Find("Player");
        g.transform.rotation *= Quaternion.AngleAxis(-10, g.transform.up);
    }
    public void btnRight()
    {
        GameObject g = GameObject.Find("Player");
        g.transform.rotation *= Quaternion.AngleAxis(10, g.transform.up);
    }

    public void imgStartMouseDown()
    {
        isPressed0 = true;
        print("d");
    }
    public void imgStartMouseUp()
    {
        isPressed0 = false;
        print("u");
    }

    public void ImageFMouseDown(int v)
    {
        isPressed[v] = true;
        print("d");
    }
    public void ImageFMouseUp(int v)
    {
        isPressed[v] = false;
        print("u");
    }

  

}


