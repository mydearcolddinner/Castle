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
    public GameObject door;

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
    
    private int i = 1, n = 1;

    Vector3 ghostpos;
    Vector3 boypos;

    void Start()
    {
        anim = GetComponent<Animator>();
        ghost = GameObject.FindWithTag("ghost");
        boy = GameObject.FindWithTag("boy");
        WalkingNPC1 = GameObject.FindWithTag("WalkingNPC1");
        WalkingNPC2 = GameObject.FindWithTag("WalkingNPC2");
        
    }

    void Update()
    {
        anim.SetBool("NPCwatchGhost", NPCwatchGhost);
        anim.SetBool("NPCrunto", NPCrunto);
        anim.SetBool("NPCstopwatch", NPCstopwatch);

        anim.SetBool("Idle", Idle);
        anim.SetBool("SF", SF);

        anim.SetFloat("direction", direction);

        ghostpos = ghost.transform.position;
        boypos = boy.transform.position;
        direction = transform.position.x - ghost.transform.position.x;
        if ((ghost.GetComponent<Renderer>().enabled) && (direction < 4) && (((ghostpos.x < boypos.x && facingLeft) || (ghostpos.x > boypos.x && !facingLeft))))
        {
            NPCwatchGhost = true;
        }

        if (NPCstopwatch == true)
        {
            GoToGhost();
        }

        if (SF == true)
        {
            NPCrunto = false;
            Idle = true;

            if (NPCwalk1 == true)
            {
                WalkingNPCright();
            }
            else
            {
                WalkingNPCleft();
            }
        }
    }

    public void GoToSF()
    {
        Idle = false;
        SF = true;
        
    }
    

    public void StopWatch()
    {
        NPCstopwatch = true;
        NPCwatchGhost = false;
        
    }

    public void GoToGhost()
    {
        if (ghost.GetComponent<Renderer>().enabled)
        {
            SF = false;
            NPCrunto = true;
            Vector3 pos = transform.position;
            ghostpos = ghost.transform.position;
            boypos = boy.transform.position;
            pos.x -= Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
            //if (ghostpos.x > boypos.x && facingLeft)
            //{
            //    Flip();
            //}
            //else if (ghostpos.x < boypos.x && !facingLeft)
            //{
            //    Flip();
            //}
            //else
            //{
            //    NPCrunto = false;
            //}

            if (door.GetComponent<BoxCollider2D>().isTrigger == false)
            {
                NPCwatchGhost = false;
                GoToSF();
            }
        }
    }

    private void Flip()
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

    private void WalkingNPCright()
    {
        Idle = false;
        Vector3 pos = transform.position;
        float WalkBetween = WalkingNPC2.transform.position.x - transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(WalkBetween) * speedMove, GetComponent<Rigidbody2D>().velocity.y);
        if (WalkBetween > 0 && facingLeft)
            Flip();
    }

    private void WalkingNPCleft()
    {
        Idle = false;
        Vector3 pos = transform.position;
        float WalkBetween = WalkingNPC1.transform.position.x - transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(WalkBetween) * speedMove, GetComponent<Rigidbody2D>().velocity.y);
        if (WalkBetween < 0 && !facingLeft)
            Flip();
    }
}       