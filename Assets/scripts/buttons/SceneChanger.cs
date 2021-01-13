using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int counter;
    public int number;
    public void OnMouseDown()
    {
        //SceneManager.LoadScene(number, LoadSceneMode.Additive);
        counter++;
    }
}
