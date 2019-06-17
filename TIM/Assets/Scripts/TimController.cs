using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimController : MonoBehaviour {
    private Animator anim;
    bool Jump = false;
    public int speed = 1;
    private Rigidbody rb;
    private bool inLife = true;
    private int timeToDeath = 10;
    public AudioSource run;
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        this.rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            this.transform.Translate(0, 0, 0.1f);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (!anim.GetBool("Running"))
            run.Play();

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -0.1f);
            anim.SetBool("Running", true);
            run.Play();
        }
        else
        {
            anim.SetBool("Idle", true);
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Roll", true);
        }
        else
        {
            anim.SetBool("Roll", false);
        }



        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(0, -2, 0);
            this.transform.Translate(0.1f, 0, 0);
            this.transform.Translate(0, 0, 0.1f);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 0.5f, 0);
            this.transform.Translate(0, 0, 0.1f);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.Space))
            Jump = true;

        
        else Jump = false;

        
        if (Jump == false)
            anim.SetBool("Jumping", false);

        
        if (Jump == true)
            anim.SetBool("Jumping", true);

        if (!this.inLife)
        {
            this.timeToDeath--;
            // transform.localScale += new Vector3(0.3F, 0.3F, 0.3F);
            if (this.timeToDeath <= 0)
            {
               // Destroy(this.gameObject);
                anim.SetBool("Dying", true);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(anim.GetBool("Dying"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.name == "BadCrystal")
        {
            this.inLife = false;
        }
    }
}
