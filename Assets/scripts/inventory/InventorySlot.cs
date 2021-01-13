﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Sprite sprite; 

    public Image icon; //Иконка, куда будет прикрепляться спрайт

    public void UpdateSlot(bool active) //Обновление слота
    {
        if (active)
        {
            icon.sprite = sprite;
        }
        else
        {
            icon.sprite = null;
        }
    }
}
