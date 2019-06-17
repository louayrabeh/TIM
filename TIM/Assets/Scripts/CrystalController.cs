using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    private int speed = 130;
    private bool inLife = true;
    private int timeToDeath = 7;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (!this.inLife)
        {
            this.timeToDeath--;
           // transform.localScale += new Vector3(0.3F, 0.3F, 0.3F);
            if (this.timeToDeath <= 0)
            {
                
            }
        }*/
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    // Executée lors d'une collision
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.name == "Tim")
        {
            //this.inLife = false;
            Destroy(this.gameObject);
        }
    }
}