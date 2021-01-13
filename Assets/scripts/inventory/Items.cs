using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public int[] items = new int[] { 0, 1, 2, 3, 4, 5 };
    public bool[] hasItems = new bool[] { false, false, false, false, false, false };

    //private int currItem = 0;
    //public int defence = 0;

    public GameObject itemObject;
    public Sprite[] sprites;

    //public void Equip(int index)
    //{
    //    if (hasItems[index])
    //    {
    //        currItem = index;
    //        defence = items[currItem];
    //        itemObject.GetComponent<SpriteRenderer>().sprite = sprites[currItem];
    //    }
    //}

    public void AddItem(int index)
    {
        hasItems[index] = true;
    }
}
