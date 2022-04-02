using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace A
//{
//    public class Scrollbar
//    {
//        public Scrollbar()
//        {

//        }
//    }
//}


public class Player : MonoBehaviour
{
    float v;
    public static Player _instance;
    public GameObject shell;
    public int hp, pt;
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        shell = Resources.Load("Shell") as GameObject;
        
        //GameObject shell = Resources.Load("Shell") as GameObject;
        //GameObject bullet =Instantiate(shell, this.transform.position, this.transform.rotation);

    }
    public void move(float v)
    {
        //float v = Input.GetAxis("Vertical");
        int speed = 5;
        this.transform.position += this.transform.forward * v * speed * Time.deltaTime; //앞, 뒤
        
    }
    public void PlayerMove(int v)
    {
        move(v);
    }


    public void PlayerDirection(Vector3 v)
    {
        //this.transform.forward = v;
        float ang = Vector3.Angle(this.transform.forward, v.normalized);

        Vector3 cross = Vector3.Cross(this.transform.forward, v.normalized);

        this.transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(0, ang, 0.1f), cross.normalized) * this.transform.rotation;

        //Mathf.Lerp(0, ang, 0.1f); 방향키 돌릴때 천천히 회전하는 코드     
        //if(cross.y>0) 
        //    this.transform.rotation=Quaternion.AngleAxis(ang, this.transform.up) * this.transform.rotation;
        //else
        //    this.transform.rotation = Quaternion.AngleAxis(ang, -this.transform.up) * this.transform.rotation;
        move(v.magnitude / 50.0f);
    }


    void headmove()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.GetChild(0).GetChild(3).rotation = Quaternion.AngleAxis(1, this.transform.GetChild(0).GetChild(3).transform.up) * this.transform.GetChild(0).GetChild(3).transform.rotation;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.GetChild(0).GetChild(3).rotation = Quaternion.AngleAxis(-1, this.transform.GetChild(0).GetChild(3).transform.up) * this.transform.GetChild(0).GetChild(3).transform.rotation;
            }
            
        }
    }

    public void fire()
    {
       //if (Input.GetKeyUp(KeyCode.Space))
       
       {
           
            GameObject bullet = Instantiate(shell, this.transform.GetChild(0).GetChild(3).GetChild(0).position, this.transform.GetChild(0).GetChild(3).GetChild(0).rotation);
            bullet.AddComponent<Rigidbody>().AddForce(bullet.transform.forward * 30, ForceMode.Impulse);           
            bullet.GetComponent<Collider>().isTrigger = true;
            //bullet.AddComponent<enemy1>();
            bullet.AddComponent<shell>();
        }
    }

    bool fpsFlag = false;
    void camWorks()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            fpsFlag = true;
        if (Input.GetKeyUp(KeyCode.Alpha3))
            fpsFlag = false;

        Vector3 dest;
        if (fpsFlag)
            dest = this.transform.GetChild(1).transform.position;
        else
            dest = this.transform.GetChild(2).transform.position;


        Vector3 pos = Vector3.Lerp(Camera.main.transform.position, dest, 0.1f);
        Camera.main.transform.position = pos;
        Camera.main.transform.rotation = this.transform.rotation;
    }


    // Update is called once per frame
    void Update()
     {
         move(Input.GetAxis("Vertical"));
        float h = Input.GetAxis("Horizontal");
        this.transform.rotation = Quaternion.AngleAxis(h*5, this.transform.up) * this.transform.rotation;

        headmove();
        
          camWorks();
        if (Input.GetKeyUp(KeyCode.Space))
            fire();


        if (GameObject.Find("Scrollbar").GetComponent<UnityEngine.UI.Scrollbar>().size <= 0.1f)
          UnityEngine.SceneManagement.SceneManager.LoadScene("scene_end");

    }
}
