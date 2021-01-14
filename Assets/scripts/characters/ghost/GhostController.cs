using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    public float maxSpeed = 10f; //переменная для установки макс. скорости персонажа
    private bool isFacingRight = true; //переменная для определения направления персонажа вправо/влево
    //ссылка на компонент анимаций
    private Animator anim;
    float speed;
    bool getRendEn; //переменная для получения ссылки на рендер объекта
    public GameObject trigger2dRoom;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        getRendEn = GetComponent<Renderer>().enabled;

        anim.SetFloat("speed", speed);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (getRendEn == true)
            { 
                GetComponent<Renderer>().enabled = false;
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            else
            {
                GetComponent<Renderer>().enabled = true;
            }
        }
        
        float move = Input.GetAxis("Horizontal"); 
        speed = move * maxSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; 
        Vector3 theScale = transform.localScale; 
        theScale.x *= -1; 
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        Vector3 pos = transform.position;

        if (Col.name == "triggerTo2dRoom")
        {
            pos.x = -12;
            pos.y = -1;
            transform.Translate(pos);
            trigger2dRoom.GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (Col.name == "triggerToHall")
        {
            pos.x = 11;
            pos.y = -1;
            pos.z = -3;
            transform.Translate(pos);
            trigger2dRoom.GetComponent<BoxCollider2D>().isTrigger = true;
        }
       
        if (Col.name == "triggerToOut")
        {
            
        }
    }
}

