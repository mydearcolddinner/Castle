using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boycontr : MonoBehaviour
{
    public GameObject boy;
    public GameObject ghost;
    public float startX, finishX;

    Animator anim;
    GameObject WalkingNPC1, WalkingNPC2;

    bool NPCwatchGhost = false;
    bool NPCrunto = false;
    bool NPCstopwatch = false;
    bool NPCwalk1;

    bool Idle = true;
    bool SF = false;
    float direction;

    const float speedMove = 2.0f;
    private bool facingLeft = true;

    //public float spawnX, spawnY;
    private int i = 1, n = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        ghost = GameObject.FindWithTag("ghost");
        boy = GameObject.FindWithTag("boy");
        WalkingNPC1 = GameObject.FindWithTag("WalkingNPC1");
        WalkingNPC2 = GameObject.FindWithTag("WalkingNPC2");
        //spawnX = transform.position.x;
        //spawnY = transform.position.y;
    }

    void Update()
    {
        anim.SetBool("NPCwatchGhost", NPCwatchGhost);
        anim.SetBool("NPCrunto", NPCrunto);
        anim.SetBool("NPCstopwatch", NPCstopwatch);

        anim.SetBool("Idle", Idle);
        anim.SetBool("SF", SF);

        anim.SetFloat("direction", direction);

        
        direction = transform.position.x - ghost.transform.position.x;
        if ((ghost.GetComponent<Renderer>().enabled) && (direction < 5))
        {
            NPCwatchGhost = true;
            //StartWatch();
        }

        if (NPCstopwatch == true)
        {
            GoToGhost();
        }

        if (SF == true)
        {
            if (NPCwalk1 == true)
             WalkingNPCright(); 
            else WalkingNPCleft();
        }
    }

    public void GoToSF()
    {
        Idle = false;
        SF = true;
        
    }

    //public void StartWatch()
    //{
    //    NPCwatchGhost = true;
    //    //StopWatch();
    //}

    public void StopWatch()
    {
        NPCstopwatch = true;
        NPCwatchGhost = false;
        //GoToGhost();
        
    }

    public void GoToGhost()
    {
        if (ghost.GetComponent<Renderer>().enabled)
        {
            NPCrunto = true;
            Vector3 pos = transform.position;
            Vector3 ghostpos = ghost.transform.position;
            Vector3 boypos = boy.transform.position;
            //for (i = 1; i > 0; i++)
            //{
            //    //pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;  //Mathf.Sign Return value is 1 when f is positive or zero, -1 when f is negative.
            //    //transform.position = pos;

            pos.x -= Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
            if (ghostpos.x > boypos.x && facingLeft)
            {
                Flip();
            }
            if (ghostpos.x < boypos.x && !facingLeft)
            {
                Flip();
            }
        }
        else
        {
            NPCrunto = false;
        }
    }

    public void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "WalkingNPC1")
        {
            NPCwalk1 = true;
            SF = false;
            Idle = true;
        }

        if (Col.tag == "WalkingNPC2")
        {
            NPCwalk1 = false;
            SF = false;
            Idle = true;
        }

    }

    public void WalkingNPCright()
    {
        Vector3 pos = transform.position;
        float WalkBetween = WalkingNPC2.transform.position.x - transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(WalkBetween) * speedMove, GetComponent<Rigidbody2D>().velocity.y);
        if (WalkBetween > 0 && facingLeft)
            Flip();
    }

    public void WalkingNPCleft()
    {
        Vector3 pos = transform.position;
        float WalkBetween = WalkingNPC1.transform.position.x - transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(WalkBetween) * speedMove, GetComponent<Rigidbody2D>().velocity.y);
        if (WalkBetween < 0 && !facingLeft)
            Flip();
    }
}       
//NPC идёт за призраком, когда расстояние между ними = direction

        //    float direction = ghost.transform.position.x - transform.position.x; //расстояние между призраком и Npc
        //    //14 изначально


            //    if (Mathf.Abs(direction) < 3)
            //    {
            //        Vector3 pos = transform.position;
            //        Vector3 ghostpos = ghost.transform.position;
            //        Vector3 boypos = boy.transform.position;
            //        //Mathf.Sign Return value is 1 when f is positive or zero, -1 when f is negative.
            //        pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime; 
            //        transform.position = pos; 
            //        if (ghostpos.x > boypos.x && facingLeft)
            //        {
            //            Flip();
            //        }
            //        if (ghostpos.x < boypos.x && !facingLeft)
            //        {
            //            Flip();
            //        }
            //    }

            //    else if (Mathf.Abs(direction) > 3)
            //    {
            //        Vector3 pos = transform.position;
            //        Vector3 boypos = boy.transform.position;
            //        while (boypos.x > -7)
            //        {
            //            pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
            //        }
            //    }