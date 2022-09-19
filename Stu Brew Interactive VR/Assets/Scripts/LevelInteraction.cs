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

    public GameObject Malt;
    public GameObject Hops;
    public GameObject Yeast;

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

    public GameObject liquid1;
    public GameObject liquid2;
    public GameObject liquid3;
    public GameObject liquid4;



    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        temp = 20;
        loopCounter = 0;
        time = 0;
        time2 = 0;

        liquid1.transform.position = new Vector3(liquid1.transform.position.x, -1.5f ,liquid1.transform.position.z);
        liquid2.transform.position = new Vector3(liquid2.transform.position.x, -1.5f, liquid2.transform.position.z);
        liquid3.transform.position = new Vector3(liquid3.transform.position.x, -1.5f, liquid3.transform.position.z);
        //liquid4.transform.position = new Vector3(liquid4.transform.position.x, -1.5f, liquid4.transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case 0:
                display1.text = "Add Water";
                
                button1.GetComponent<MeshRenderer>().material = green;
                break;
            case 1:
                display1.text = "Heat Water";
                whiteboardInstructions.NewTask();
                button1.GetComponent<MeshRenderer>().material = red;
                button2.GetComponent<MeshRenderer>().material = green;
                break;
            case 2:
                button2.GetComponent<MeshRenderer>().material = red;
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
                whiteboardInstructions.NewTask();
                button3.GetComponent<MeshRenderer>().material = green;
                break;
            case 4:
                button3.GetComponent<MeshRenderer>().material = red;
                display2.text = "Add Malt";
                display1.text = "Holding Water";
                whiteboardInstructions.NewTask();
                if (MaltPos())
                {
                    stage++;
                }
                break;
            case 5:
                display2.text = "Mix";
                whiteboardInstructions.NewTask();
                button4.GetComponent<MeshRenderer>().material = green;
                break;
            case 6:
                button4.GetComponent<MeshRenderer>().material = red;

                whiteboardInstructions.NewTask();

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
                whiteboardInstructions.NewTask();
                button5.GetComponent<MeshRenderer>().material = green;
                break;
            case 8:
                display2.text = "Sparge";
                whiteboardInstructions.NewTask();
                button5.GetComponent<MeshRenderer>().material = red;
                button3.GetComponent<MeshRenderer>().material = green;
                break;
            case 9:
                display2.text = "Pump";
                whiteboardInstructions.NewTask();
                button3.GetComponent<MeshRenderer>().material = red;
                button5.GetComponent<MeshRenderer>().material = green;
                break;
            case 10:
                display2.text = "Empty";
                display3.text = "Add Hops";
                whiteboardInstructions.NewTask();
                if (HopsPos())
                {
                    stage++;
                }
                button5.GetComponent<MeshRenderer>().material = red;
                break;
            case 11:
                display3.text = "Heat";
                whiteboardInstructions.NewTask();
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
                whiteboardInstructions.NewTask();
                button7.GetComponent<MeshRenderer>().material = green;
                break;
            case 14:
                button7.GetComponent<MeshRenderer>().material = red;
                display3.text = "Empty";
                display4.text = "Add Yeast";
                whiteboardInstructions.NewTask();
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
                display4.text = "Pump";
                //whiteboard.text = "";
                button8.GetComponent<MeshRenderer>().material = green;

                break;
            case 17:
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
        if (stage == 0) { NextStage(); }
    }
    public void Heat1()
    {
        if (stage == 1) { NextStage(); }
    }
    public void Pump1()
    {
        if (stage == 3) { NextStage(); }
        if (stage == 8) { NextStage(); }
    }
    public void Mix2()
    {
        if (stage == 5) { NextStage(); }
    }
    public void Pump2()
    {
        if (stage == 7) { NextStage(); }
        if (stage == 9) { NextStage(); }
    }
    public void Heat3()
    {
        if (stage == 11) { NextStage(); }
    }
    public void Pump3()
    {
        if (stage == 13) { NextStage(); }
    }
    public void Pump4()
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
