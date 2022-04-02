using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main _this;
    public GameObject EnemyType1;
    float t = 0, thTime = 3;
    Vector3 dest, panelPos;
    bool isShowPanel;

    // Start is called before the first frame update
    void enemySpawn()
    {

        Vector3 pos = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));       
        GameObject e=Instantiate(EnemyType1, pos, Quaternion.identity);      
        Renderer[] r = e.transform.GetChild(0).GetComponentsInChildren<Renderer>();
        for (int i = 0; i < r.Length; i++)
            r[i].material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    GameObject Enemy;
    void Start()
    {
        _this = this;
        panelPos = GameObject.Find("Panel").transform.position;
        Enemy = Resources.Load("Enemy") as GameObject;
        StartCoroutine("co_routine");
        
        dest = new Vector3(panelPos.x, -120, 0);       

    }
    Vector3 mPos;

    IEnumerator co_routine()
    {
        while (true)
        {          
            
            
            enemySpawn();

            yield return new WaitForSeconds(3); //시간을 기다렸다가 실행
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0))
        {
            mPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 v = Input.mousePosition - mPos;
            float ang = Vector3.Angle(new Vector3(0, 1, 0), v.normalized);
            float hang = Vector3.Angle(new Vector3(1, 0, 0), v.normalized);
            //print(hang);

            //v.magnitude
            //Screen.height * 0.3

            //if (v.magnitude > Screen.height * 0.2)
            {
                if (ang< 10) //0이 포함되면 드레그가 아니라 클릭만 해도 움직임              
                    isShowPanel = true;

                if (ang > 170)
                    isShowPanel = false;


                if (hang < 10) //0이 포함되면 드레그가 아니라 클릭만 해도 움직임              
                    isShowPanel = true;

                if (hang > 170)
                    isShowPanel = false;

            }


        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isShowPanel = !isShowPanel;

        }

        if (isShowPanel)
            dest = new Vector3(panelPos.x, 100, 0);
        else
            dest = new Vector3(panelPos.x, -100, 0);

GameObject.Find("Panel").transform.position = Vector3.Lerp(GameObject.Find("Panel").transform.position, dest, 0.05f);


    }


}
