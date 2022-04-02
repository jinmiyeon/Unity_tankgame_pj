using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



    public class EndUI : MonoBehaviour
    {
    
    public static EndUI _instance;
   
  
    
        // Start is called before the first frame update
        void Start()
        {
        _instance = this;
    }
    public void UpdateScoreText(int newScore)
    {
        
    }

   
        // Update is called once per frame
        void Update()
        {
        Rect r = GameObject.Find("RawImage").GetComponent<RawImage>().uvRect;
        r.x += Time.deltaTime * 0.1f;
        GameObject.Find("RawImage").GetComponent<RawImage>().uvRect = r;
    }

        public void imgbtnretry()
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("scene_intro");
        }

        public void imgBtnreStart()
        {
            SceneManager.LoadScene("scene_play");
        }
    }

