using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public GameObject liquid1;
    public GameObject liquid2;
    public GameObject liquid3;
    public GameObject liquid4;


    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiquidUpdate(int i)
    {
        switch (i)
        {
            case 0:
                break;
            case 1:
                LiquidUp(liquid1);
                break;
            case 2:
                LiquidUp(liquid2);
                break;
            case 3:
                LiquidUp(liquid3);
                break;
            case 4:
                if (liquid4.transform.position.y > 2.2f)
                {
                    break;
                }
                liquid4.transform.position = new Vector3(liquid4.transform.position.x, (liquid4.transform.position.y + 0.0035f), liquid4.transform.position.z);
                liquid4.transform.localScale = new Vector3(liquid4.transform.localScale.x, (liquid4.transform.localScale.y + 0.0015f), liquid4.transform.localScale.z);
                break;


            case 5:
                LiquidDown(liquid1);
                break;
            case 6:
                LiquidDown(liquid2);
                break;
            case 7:
                LiquidDown(liquid3);
                break;
            case 8:
                if (liquid4.transform.position.y < 1.3f)
                {
                    break;
                }
                liquid4.transform.position = new Vector3(liquid4.transform.position.x, (liquid4.transform.position.y - 0.0035f), liquid4.transform.position.z);
                liquid4.transform.localScale = new Vector3(liquid4.transform.localScale.x, (liquid4.transform.localScale.y - 0.0015f), liquid4.transform.localScale.z);
                break;
        }
    }


    private void LiquidUp(GameObject l)
    {
        
        if (l.transform.position.y > 1.5f)
        {
        }
        else
        {
            l.transform.position = new Vector3(l.transform.position.x, (l.transform.position.y + 0.01f), l.transform.position.z);
        }
    }

    private void LiquidDown(GameObject l)
    {
        
        if (l.transform.position.y < -1.5f)
        {
        }
        else
        {
            l.transform.position = new Vector3(l.transform.position.x, (l.transform.position.y - 0.01f), l.transform.position.z);
        }
    }

    public void ResetLevel()
    {
        liquid1.transform.position = new Vector3(liquid1.transform.position.x, -1.5f, liquid1.transform.position.z);
        liquid2.transform.position = new Vector3(liquid2.transform.position.x, -1.5f, liquid2.transform.position.z);
        liquid3.transform.position = new Vector3(liquid3.transform.position.x, -1.5f, liquid3.transform.position.z);
        liquid4.transform.position = new Vector3(liquid4.transform.position.x, 1.3f, liquid4.transform.position.z);
        liquid4.transform.localScale = new Vector3(liquid4.transform.localScale.x, 0.01f, liquid4.transform.localScale.z);
    }

}


