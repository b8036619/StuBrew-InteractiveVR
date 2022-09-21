using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public GameObject liquid1;
    public GameObject liquid2;
    public GameObject liquid3;
    public GameObject liquid4;

    private int flowingLiquid;

    //private List<GameObject> liquids;

    // Start is called before the first frame update
    void Start()
    {
        liquid1.transform.position = new Vector3(liquid1.transform.position.x, -1.5f, liquid1.transform.position.z);
        liquid2.transform.position = new Vector3(liquid2.transform.position.x, -1.5f, liquid2.transform.position.z);
        liquid3.transform.position = new Vector3(liquid3.transform.position.x, -1.5f, liquid3.transform.position.z);
        liquid4.transform.position = new Vector3(liquid4.transform.position.x, -0.45f, liquid4.transform.position.z);
        liquid4.transform.localScale = new Vector3(liquid4.transform.localScale.x, 0.01f, liquid4.transform.localScale.z);

        //liquids.Add(liquid1);
        //liquids.Add(liquid2);
        //liquids.Add(liquid3);
        //liquids.Add(liquid4);

    }

    // Update is called once per frame
    void Update()
    {
        switch (flowingLiquid)
        {
            case 0:
                break;
            case 1:
                if (liquid1.transform.position.y >= 1.5f) {
                    flowingLiquid = 0;
                    break;
                }
                liquid1.transform.position = new Vector3(liquid1.transform.position.x, (liquid1.transform.position.y + 0.01f) * Time.deltaTime, liquid1.transform.position.z);
                break;
            case 2:
                if (liquid2.transform.position.y >= 1.5f)
                {
                    flowingLiquid = 0;
                    break;
                }
                liquid2.transform.position = new Vector3(liquid2.transform.position.x, (liquid2.transform.position.y + 0.01f) * Time.deltaTime, liquid2.transform.position.z);
                break;
            case 3:
                if (liquid3.transform.position.y >= 1.5f)
                {
                    flowingLiquid = 0;
                    break;
                }
                liquid3.transform.position = new Vector3(liquid3.transform.position.x, (liquid3.transform.position.y + 0.01f) * Time.deltaTime, liquid3.transform.position.z);
                break;
            case 4:
                if (liquid4.transform.position.y >= 0f)
                {
                    flowingLiquid = 0;
                    break;
                }
                liquid4.transform.position = new Vector3(liquid4.transform.position.x, (liquid4.transform.position.y + 0.0045f) * Time.deltaTime, liquid4.transform.position.z);
                liquid4.transform.localScale = new Vector3(liquid4.transform.localScale.x, (liquid4.transform.localScale.y + 0.0038f) * Time.deltaTime, liquid4.transform.localScale.z);
                break;
        }
    }

    public void RaiseLiquid(int i)
    {
        flowingLiquid = i;
    }


}
