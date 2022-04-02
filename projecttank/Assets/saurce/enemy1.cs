using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class enemy1 : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject shell, turret;
        //public GameObject ShellExplosion;
        void Start()
        {
            turret = this.transform.GetChild(0).GetChild(3).gameObject;
            shell = Resources.Load("Shell") as GameObject;
            thTime = Random.Range(1f, 3f);
            //InvokeRepeating("fire", thTime, thTime);    



            StartCoroutine("co_routine");
        }
        IEnumerator co_routine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 5f));
                fire();

            }

        }

        float thTime = 3;
        void fire()
        {

            {
                GameObject bullet = Instantiate(shell, turret.transform.position + turret.transform.forward * 2, turret.transform.rotation);
                bullet.AddComponent<Rigidbody>().AddForce(bullet.transform.forward * 20, ForceMode.Impulse);
                bullet.AddComponent<shell>();

            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 v = GameObject.Find("Player").transform.position - this.transform.position;
            this.transform.forward = v.normalized;
            this.transform.position += v.normalized * 1 * Time.deltaTime;

        }


    }

