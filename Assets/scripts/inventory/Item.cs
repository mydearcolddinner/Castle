using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int index;
    public GameObject ghost;

    //void OnTriggerEnter2D(Collider2D obj) //«Наезд» на объект
    //{
    //    if (obj.transform.tag == "Player")
    //    {
    //        obj.GetComponent<Items>().AddItem(index);//Если наехал игрок, то он сможет подобрать предмет
    //        Destroy(gameObject); //Удаление объекта с карты
    //    }
    //}

    public void getItem()
    {
        ghost.GetComponent<Items>().AddItem(index);
        Destroy(this.gameObject);
    }  
}
