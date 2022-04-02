using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIScript1 : MonoBehaviour
{
    public AudioClip ed;
    float t = 0;
    bool isSound = false;
    float r;
    float r1;
    float r2;

    Vector2 oSize;
    Vector2 sSize;
    RectTransform rt;

    RectTransform et;
    RectTransform et1;
    RectTransform et2;

    


    // Start is called before the first frame update
    void Start()
    {

        

        rt = GameObject.Find("imgStart").GetComponent<RectTransform>();
        oSize = rt.sizeDelta;

        et = GameObject.Find("imgSound").GetComponent<RectTransform>();
        et1 = GameObject.Find("imgSound1").GetComponent<RectTransform>();
        et2 = GameObject.Find("imgSound2").GetComponent<RectTransform>();
        sSize = et.sizeDelta;

         r = Random.Range(0, 100);
         r1 = Random.Range(0, 100);
         r2 = Random.Range(0, 100);

       
    }


    void soundbar()
    {
        t += Time.deltaTime;

        float e =  Mathf.Sin(r + t * 8);
        float e1 = Mathf.Sin(r1 + t * 8);
        float e2 = Mathf.Sin(r2 + t * 8);

        et.sizeDelta = sSize + new Vector2(0, e) * 20;
        et1.sizeDelta = sSize + new Vector2(0, e1) * 20;
        et2.sizeDelta = sSize + new Vector2(0, e2) * 20;
    }

   
    // Update is called once per frame
    void Update()
    {

        
        //RectTransform rt = GameObject.Find("imgStart").GetComponent<RectTransform>();
        //rt.sizeDelta += new Vector2(0.1f, 0.1f);
        float inc = Mathf.Abs(Mathf.Sin(Time.time*2));    
        rt.sizeDelta = oSize + new Vector2(inc,inc) * 30;      

        if(isSound)
        {
            soundbar();
        }
    }
    
    public void imgBtnStart()
    {
        SceneManager.LoadScene("scene_play");
    }
    
    public void sourceChange()
    {
        this.gameObject.GetComponent<AudioSource>().clip = ed;
        this.GetComponent<AudioSource>().Play();
    }

    public void ImgSoundBar()
    {
        isSound =! isSound; //토글
        if(!isSound)
        {
            this.GetComponent<AudioSource>().Pause();
        }else
        {
            this.GetComponent<AudioSource>().Play();
        }
    }

}


