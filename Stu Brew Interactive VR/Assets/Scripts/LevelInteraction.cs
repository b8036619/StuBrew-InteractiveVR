using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInteraction : MonoBehaviour
{
    private int stage = 0;

    //public TextMeshPro whiteboard;

    public TextMeshPro display1;
    public TextMeshPro display2;
    public TextMeshPro display3;
    public TextMeshPro display4;

    private int temp = 20;
    private int loopCounter = 0;
    private float time = 0;
    private float time2 = 0;
    private float liquidClock = 0;
    private bool liquidTick = false;

    public GameObject malt;
    public GameObject hops;
    public GameObject yeast;
    private Quaternion bucketRotation;

    public Material red;
    public Material green;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;

    public Whiteboard whiteboardInstructions;
    public Liquid liquids;



    // Start is called before the first frame update
    void Start()
    {
        bucketRotation = malt.transform.rotation;
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        liquidClock = liquidClock + Time.deltaTime;
        if (liquidClock > 0.002f){ liquidTick = true; liquidClock = 0; }
        else { liquidTick = false; }

        switch (stage)
        {
            case 0:
                display1.text = "Add Water";
                button1.GetComponent<MeshRenderer>().material = green;
                break;
            case 1:
                if (liquidTick) { liquids.LiquidUpdate(1); }
                display1.text = "Heat Water";
                button1.GetComponent<MeshRenderer>().material = red;
                button2.GetComponent<MeshRenderer>().material = green;
                break;
            case 2:
                button2.GetComponent<MeshRenderer>().material = red;
                time = time + Time.deltaTime;
                display1.text = "Temp: " + temp.ToString() + "c";
                if (temp == 78)
                {
                    whiteboardInstructions.NewTask();
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
                button3.GetComponent<MeshRenderer>().material = green;
                break;
            case 4:
                if (liquidTick) { liquids.LiquidUpdate(2); }
                button3.GetComponent<MeshRenderer>().material = red;
                display2.text = "Add Malt";
                display1.text = "Holding Water";
                if (MaltPos())
                {
                    whiteboardInstructions.NewTask();
                    stage++;
                }
                break;
            case 5:
                display2.text = "Mix";
                button4.GetComponent<MeshRenderer>().material = green;
                break;
            case 6:
                button4.GetComponent<MeshRenderer>().material = red;

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
                    whiteboardInstructions.NewTask();
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
                button5.GetComponent<MeshRenderer>().material = green;
                break;
            case 8:
                if (liquidTick) { liquids.LiquidUpdate(6); liquids.LiquidUpdate(3); }
                display2.text = "Sparge";
                button5.GetComponent<MeshRenderer>().material = red;
                button3.GetComponent<MeshRenderer>().material = green;
                break;
            case 9:
                if (liquidTick) { liquids.LiquidUpdate(2); liquids.LiquidUpdate(5); }
                display2.text = "Pump";
                button3.GetComponent<MeshRenderer>().material = red;
                button5.GetComponent<MeshRenderer>().material = green;
                break;
            case 10:
                if (liquidTick) { liquids.LiquidUpdate(6); }
                display2.text = "Empty";
                display3.text = "Add Hops";
                if (HopsPos())
                {
                    whiteboardInstructions.NewTask();
                    stage++;
                }
                button5.GetComponent<MeshRenderer>().material = red;
                break;
            case 11:
                display3.text = "Heat";
                button6.GetComponent<MeshRenderer>().material = green;
                break;
            case 12:
                button6.GetComponent<MeshRenderer>().material = red;
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
                    whiteboardInstructions.NewTask();
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
                button7.GetComponent<MeshRenderer>().material = green;
                break;
            case 14:
                if (liquidTick) { liquids.LiquidUpdate(7); liquids.LiquidUpdate(4); }
                button7.GetComponent<MeshRenderer>().material = red;
                display3.text = "Empty";
                display4.text = "Add Yeast";
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
                    whiteboardInstructions.NewTask();
                }
                else
                {
                    time = time + Time.deltaTime;
                }
                break;
            case 16:
                display4.text = "Pump";
                button8.GetComponent<MeshRenderer>().material = green;

                break;
            case 17:
                if (liquidTick) { liquids.LiquidUpdate(8); }
                display4.text = "Empty";
                button8.GetComponent<MeshRenderer>().material = red;

                break;
        }


    }

    private void NextStage()
    {
        stage++;
    }

    public void Water1() {
        if (stage == 0) { NextStage(); whiteboardInstructions.NewTask(); }
    }
    public void Heat1()
    {
        if (stage == 1) { NextStage(); }
    }
    public void Pump1()
    {
        if (stage == 3) { NextStage(); whiteboardInstructions.NewTask(); }
        if (stage == 8) { NextStage(); whiteboardInstructions.NewTask(); }
    }
    public void Mix2()
    {
        if (stage == 5) { NextStage(); whiteboardInstructions.NewTask(); }
    }
    public void Pump2()
    {
        if (stage == 7) { NextStage(); whiteboardInstructions.NewTask(); }
        if (stage == 9) { NextStage(); whiteboardInstructions.NewTask(); }
    }
    public void Heat3()
    {
        if (stage == 11) { NextStage(); }
    }
    public void Pump3()
    {
        if (stage == 13) { NextStage(); whiteboardInstructions.NewTask(); }
    }
    public void Pump4()
    {
        if (stage == 16) { NextStage(); whiteboardInstructions.NewTask(); }
    }


    private bool MaltPos() {

        if ((malt.transform.position.x < -0.03f && malt.transform.position.x > -0.5f)
            && (malt.transform.position.y < 4.5f && malt.transform.position.y > 3.2f)
            && (malt.transform.position.z < 3.85f && malt.transform.position.z > 3.35f))
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

        if ((hops.transform.position.x < -2.75f && hops.transform.position.x > -3.25f)
            && (hops.transform.position.y < 4.5f && hops.transform.position.y > 3.2f)
            && (hops.transform.position.z < 3.85f && hops.transform.position.z > 3.35f))
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

        if ((yeast.transform.position.x < -4.74f && yeast.transform.position.x > -5.27f)
            && (yeast.transform.position.z < -0.67f && yeast.transform.position.z > -1.2f)
            && (yeast.transform.position.y < 4.5f && yeast.transform.position.y > 3.25f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetLevel()
    {
        stage = 0;
        temp = 20;
        loopCounter = 0;
        time = 0;
        time2 = 0;
        liquidClock = 0;
        liquidTick = false;

        ResetBuckets();

        button1.GetComponent<MeshRenderer>().material = red;
        button2.GetComponent<MeshRenderer>().material = red;
        button3.GetComponent<MeshRenderer>().material = red;
        button4.GetComponent<MeshRenderer>().material = red;
        button5.GetComponent<MeshRenderer>().material = red;
        button6.GetComponent<MeshRenderer>().material = red;
        button7.GetComponent<MeshRenderer>().material = red;
        button8.GetComponent<MeshRenderer>().material = red;

    }

    public void ResetBuckets()
    {
        malt.transform.position = new Vector3(5.621f, 1.197f, -1.5f);
        malt.transform.rotation = bucketRotation;
        hops.transform.position = new Vector3(5.621f, 1.197f, -2f);
        hops.transform.rotation = bucketRotation;
        yeast.transform.position = new Vector3(5.621f, 1.197f, -2.5f);
        yeast.transform.rotation = bucketRotation;
    }
}
