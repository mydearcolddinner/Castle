using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChangerScene : MonoBehaviour
{
    int counterBasement1, counterBasement2 = 0;
    int counterHallFromLoft1, counterHallFromLoft2 = 0;
    int counterHallFromBasement1, counterHallFromBasement2 = 0;
    int counterLoft1, counterLoft2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

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
}
