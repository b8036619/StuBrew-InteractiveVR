using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInteraction : MonoBehaviour
{
    private int stage = 0;

    public TextMeshPro whiteboard;

    public TextMeshPro display1;
    public TextMeshPro display2;
    public TextMeshPro display3;
    public TextMeshPro display4;
    public TextMeshPro display5;

    private int temp = 20;
    private int loopCounter = 0;
    private float time = 0;
    private float time2 = 0;

    public GameObject Malt;
    public GameObject Hops;
    public GameObject Yeast;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        temp = 20;
        loopCounter = 0;
        time = 0;
        time2 = 0;
        whiteboard.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case 0:
                display1.text = "Add Water";
                whiteboard.text = "Add water to the hot liquor tank";
                break;
            case 1:
                display1.text = "Heat Water";
                whiteboard.text = "Heat the water in the hot liquor tank to 78c";
                break;
            case 2:
                time = time + Time.deltaTime;
                display1.text = "Temp: " + temp.ToString() + "c";
                if (temp == 78)
                {
                    stage++;
                    time = 0;
                }
                else
                {
                    if (time > 0.2)
                    {
                        time = 0;
                        temp++;
                    }
                }
                break;
            case 3:
                display1.text = "Pump";
                whiteboard.text = "Pump out the water into the mash tun";
                break;
            case 4:
                display2.text = "Add Malt";
                display1.text = "Holding Water";
                whiteboard.text = "Collect the bucket of malt from the shelf and pour it into the mash tun";
                if (MaltPos())
                {
                    stage++;
                }
                break;
            case 5:
                display2.text = "Mix";
                whiteboard.text = "Mix the grain and water to create the mash";
                break;
            case 6:
                whiteboard.text = "Leave mash for 1 hour";

                time2 = time2 + Time.deltaTime;

                if (time2 > 0.3)
                {
                    switch (loopCounter)
                    {
                        case 0:
                            display2.text = "Rest";
                            loopCounter++;
                            break;
                        case 1:
                            display2.text = "Rest.";
                            loopCounter++;
                            break;
                        case 2:
                            display2.text = "Rest..";
                            loopCounter++;
                            break;
                        case 3:
                            display2.text = "Rest...";
                            loopCounter = 0;
                            break;
                    }
                    time2 = 0;
                }
                if (time > 10)
                {
                    stage++;
                    time = 0;
                }
                else
                {
                    time = time + Time.deltaTime;
                }

                break;
            case 7:
                display2.text = "Pump";
                display3.text = "Holding Malt";
                whiteboard.text = "Pump out the mash into the kettle";
                break;
            case 8:
                display2.text = "Sparge";
                whiteboard.text = "Sparge the grain by pumping hot water from the hot liquor tank";
                break;
            case 9:
                display2.text = "Pump";
                whiteboard.text = "Pump the mash into the kettle";
                break;
            case 10:
                display3.text = "Add Hops";
                whiteboard.text = "Collect the bucket of hops from the shelf and pour it into the kettle";
                if (HopsPos())
                {
                    stage++;
                }
                break;
            case 11:
                display3.text = "Heat";
                whiteboard.text = "Boil wort for 1 hour";
                break;
            case 12:
                time2 = time2 + Time.deltaTime;

                if (time2 > 0.3)
                {
                    switch (loopCounter)
                    {
                        case 0:
                            display3.text = "Boiling";
                            loopCounter++;
                            break;
                        case 1:
                            display3.text = "Boiling.";
                            loopCounter++;
                            break;
                        case 2:
                            display3.text = "Boiling..";
                            loopCounter++;
                            break;
                        case 3:
                            display3.text = "Boiling...";
                            loopCounter = 0;
                            break;
                    }
                    time2 = 0;
                }
                if (time > 10)
                {
                    stage++;
                    time = 0;
                }
                else
                {
                    time = time + Time.deltaTime;
                }
                break;
            case 13:
                display3.text = "Pump";
                whiteboard.text = "Pump out the wort to the heat exchanger";
                break;
            case 14:
                display3.text = "Empty";
                display4.text = "Add Yeast";
                whiteboard.text = "Add yeast to fermentation vessel and ferment for 4 days";
                if (YeastPos())
                {
                    stage++;
                }
                break;
            case 15:
                time2 = time2 + Time.deltaTime;

                if (time2 > 0.3)
                {
                    switch (loopCounter)
                    {
                        case 0:
                            display4.text = "Fermenting";
                            loopCounter++;
                            break;
                        case 1:
                            display4.text = "Fermenting.";
                            loopCounter++;
                            break;
                        case 2:
                            display4.text = "Fermenting..";
                            loopCounter++;
                            break;
                        case 3:
                            display4.text = "Fermenting...";
                            loopCounter = 0;
                            break;
                    }
                    time2 = 0;
                }
                if (time > 10)
                {
                    stage++;
                    time = 0;
                }
                else
                {
                    time = time + Time.deltaTime;
                }
                break;
            case 16:


                break;
        }


    }

    private void NextStage()
    {
        stage++;
    }

    public void Water1() { 
        if (stage == 0) { NextStage(); }
    }
    public void Heat1()
    {
        if (stage == 1) { NextStage(); }
    }
    public void Send1()
    {
        if (stage == 4) { NextStage(); }
    }
    public void Mix2()
    {
        if (stage == 5) { NextStage(); }
    }
    public void Send2()
    {
        if (stage == 6) { NextStage(); }
    }
    public void Heat3()
    {
        if (stage == 8) { NextStage(); }
    }
    public void Send3()
    {
        if (stage == 10) { NextStage(); }
    }
    public void Cool4()
    {
        if (stage == 11) { NextStage(); }
    }
    public void Send4()
    {
        if (stage == 13) { NextStage(); }
    }
    public void Send5()
    {
        if (stage == 16) { NextStage(); }
    }

    private bool MaltPos() {

        if ((Malt.transform.position.x < -0.03f && Malt.transform.position.x > -0.5f)
            && (Malt.transform.position.y < 4.5f && Malt.transform.position.y > 3.2f)
            && (Malt.transform.position.z < 3.85f && Malt.transform.position.z > 3.35f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool HopsPos()
    {

        if ((Hops.transform.position.x < -2.75f && Hops.transform.position.x > -3.25f)
            && (Hops.transform.position.y < 4.5f && Hops.transform.position.y > 3.2f)
            && (Hops.transform.position.z < 3.85f && Hops.transform.position.z > 3.35f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool YeastPos()
    {

        if ((Yeast.transform.position.x < -4.74f && Yeast.transform.position.x > -5.27f)
            && (Yeast.transform.position.z < -0.18f && Yeast.transform.position.z > -0.7f)
            && (Yeast.transform.position.y < 4.5f && Yeast.transform.position.y > 3.25f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
