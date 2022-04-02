using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class shell : MonoBehaviour
    {
         
         // Start is called before the first frame update
        GameObject ShellExplosion;
  


    void Start()
        {
        
            
        
        ShellExplosion = Resources.Load("ShellExplosion") as GameObject;
            this.GetComponent<Collider>().isTrigger = true;
        

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Floor")
            {
                Destroy(this.gameObject);
                if (other.name == "Player")
                {
                //print("hi");
                GameObject.Find("Scrollbar").GetComponent<Scrollbar>().size -= 0.1f;
                    Player._instance.pt++;
                    // GameObject g = Instantiate(ShellExplosion, other.transform.position, Quaternion.identity);
                    //Destroy(g, 3);
                    Destroy(this.gameObject);
                }

                //Player._instance.fire();
                GameObject g = Instantiate(ShellExplosion, other.transform.position, Quaternion.identity);
                Destroy(g, 3);
                //print(other.name);

                //Instantiate(par, this.transform.position, Qu)


                if (other.name == "Enemy(Clone)")
                {
                    Destroy(GameObject.Find("Enemy(Clone)").gameObject);
                // print("dfsd");
                scoreText.scoreValue += 1;
                
                }
            }
        }
    private int score = 0;
    


    }

