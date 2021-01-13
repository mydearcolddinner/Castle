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
    //public Vector3 position;
    bool getRendEn; //переменная для получения ссылки на рендер объекта
    public float spawnX, spawnY;
    public bool changeIsTrue;
    float villainyBar = 0;
    public ScriptableObject loft;
    public ScriptableObject hall2Room;
    public ScriptableObject hall1Room;
    public ScriptableObject basement;
    int counterBasement1, counterBasement2 = 0;
    int counterHallFromLoft1, counterHallFromLoft2 = 0;
    int counterHallFromBasement1, counterHallFromBasement2 = 0;
    int counterLoft1, counterLoft2 = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        Vector3 pos = transform.position;

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
            else { GetComponent<Renderer>().enabled = true; }
        }
        
        float move = Input.GetAxis("Horizontal"); 
        speed = move * maxSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); 
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight) 
            Flip();


        GameObject basement = GameObject.FindGameObjectWithTag("toBasement");
        SceneChanger positionBasement = basement.GetComponent<SceneChanger>();
        counterBasement1 = positionBasement.counter;

        if (counterBasement2 != counterBasement1)
        {
            pos.x = 0;
            pos.y = -11;
            transform.Translate(pos);
            counterBasement2 = counterBasement1;
        }

        GameObject hallFromBasement = GameObject.FindGameObjectWithTag("ToHallFromBasement");
        SceneChanger positionHallFromBasement = hallFromBasement.GetComponent<SceneChanger>();
        counterHallFromBasement1 = positionHallFromBasement.counter;

        if (counterHallFromBasement2 != counterHallFromBasement1)
        {
            pos.x = 25;
            pos.y = -11;
            transform.Translate(pos);
            counterHallFromBasement2 = counterHallFromBasement1;
        }

        GameObject hallFromLoft = GameObject.FindGameObjectWithTag("ToHallFromLoft");
        SceneChanger positionHallFromLoft = hallFromLoft.GetComponent<SceneChanger>();
        counterHallFromLoft1 = positionHallFromLoft.counter;

        if (counterHallFromLoft2 != counterHallFromLoft1)
        {
            pos.x = 25;
            pos.y = -11;
            transform.Translate(pos);
            counterHallFromLoft2 = counterHallFromLoft1;
        }


        GameObject loft = GameObject.FindGameObjectWithTag("toLoft");
        SceneChanger positionLoft = loft.GetComponent<SceneChanger>();
        counterLoft1 = positionBasement.counter;

        if (counterLoft2 != counterLoft1)
        {
            pos.x = -20;
            pos.y = 8;
            transform.Translate(pos);
            counterLoft2 = counterLoft1;
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

        if (Col.name == "2dRoom")
        {
            SceneManager.LoadScene("hall2dRoom", LoadSceneMode.Additive);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 13, GetComponent<Rigidbody2D>().velocity.y);

            pos.x = -14;
            pos.y = -1;
            transform.Translate(pos);
        }
        if (Col.name == "hall")
        {
            SceneManager.LoadScene("hall1floor", LoadSceneMode.Single);
        }
        if (Col.name == "dragon")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (villainyBar != 100)
                {
                    villainyBar += 1 * Time.deltaTime;
                }
                else
                {
                    //stop animation of villainy and do villainy
                    //then boy scared
                }
            }
        }
        if (Col.name == "out")
        {
            SceneManager.LoadScene("out", LoadSceneMode.Single);
        }
    }

    private void FillVillainyBar (float numberOfVillainy)
    {
        
    }
}

