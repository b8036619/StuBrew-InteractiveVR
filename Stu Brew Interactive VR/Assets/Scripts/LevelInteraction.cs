using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInteraction : MonoBehaviour
{
    private int stage = 0;
    private bool stageFinished = true;

    public TextMeshPro whiteboard;

    public TextMeshPro display1;
    public TextMeshPro display2;
    public TextMeshPro display3;
    public TextMeshPro display4;
    public TextMeshPro display5;

    private int temp = 20;
    private int fermenting = 0;
    private float time = 0;
    private float time2 = 0;

    public GameObject Malt;
    public GameObject Hops;
    public GameObject Yeast;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        stageFinished = true;
        temp = 20;
        fermenting = 0;
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
                whiteboard.text = "Add water to the mash tun";
                break;
            case 1:
                display1.text = "Heat Water";
                whiteboard.text = "Heat the water in the mash tun to 78c";
                break;
            case 2:
                time = time + Time.deltaTime;
                display1.text = "Temp: " + temp.ToString() + "c";
                
                if (temp == 78) { 
                    display1.text = "Add Malt";
                    whiteboard.text = "Collect the bucket of malt from the shelf and pour it into the mash tun";
                    if (MaltPos())
                    {
                        stageFinished = true;
                        stage++;
                        temp = 60;
                        time = 0;
                    }
                }
                else {
                    if (time > 0.2)
                    {
                        time = 0;
                        temp++;
                    }
                    stageFinished = false;
                }

                break;
            case 3:
                display1.text = "Mix";
                whiteboard.text = "Mix the water and malt in the mash tun";
                break;
            case 4:
                display1.text = "Send";
                whiteboard.text = "Pump out the mash into the lauter tun";
                break;
            case 5:
                display1.text = "Empty";
                display2.text = "Mix";
                whiteboard.text = "Mix the mash to separate liquid from the grain";
                break;
            case 6:
                display2.text = "Send";
                whiteboard.text = "Pump out the wort into the brew kettle";
                break;
            case 7:
                display2.text = "Empty";
                display3.text = "Add Hops";
                whiteboard.text = "Collect the bucket of hops from the shelf and pour it into the brew kettle";
                if (HopsPos()) { 
                    stage++;
                }
                break;
            case 8:
                display3.text = "Heat";
                whiteboard.text = "Heat the wort to 85c for upto 2 hours";
                break;
            case 9:
                time = time + Time.deltaTime;
                stageFinished = false;
                display3.text = "Temp: " + temp.ToString() + "c";
                if (temp == 85)
                {
                    stageFinished = true;
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
            case 10:
                display3.text = "Send";
                whiteboard.text = "Pump out the wort into the whirlpool to separate the solid particles";
                break;
            case 11:
                display3.text = "Empty";
                display4.text = "Cool";
                whiteboard.text = "Pump the wort through the plate heat exchanger to cool";
                break;
            case 12:
                time = time + Time.deltaTime;
                stageFinished = false;
                display4.text = "Temp: " + temp.ToString() + "c";
                if (temp == 10)
                {
                    stageFinished = true;
                    stage++;
                    time = 0;
                }
                else
                {
                    if (time > 0.2) {
                        time = 0;
                        temp--; 
                    }
                }
                break;
            case 13:
                display4.text = "Send";
                whiteboard.text = "Pump out the wort to the fermentation tank";
                break;
            case 14:
                display4.text = "Empty";
                display5.text = "Add Yeast";
                whiteboard.text = "Collect the bucket of yeast from the shelf and pour it into the fermentation tank";
                if (YeastPos())
                {
                    stage++;
                }
                break;
            case 15:
                stageFinished = false;
                time2 = time2 + Time.deltaTime;

                whiteboard.text = "The beer is fermenting";

                if (time2 > 0.3) {
                    switch (fermenting)
                    {
                        case 0:
                            display5.text = "Fermenting";
                            fermenting++;
                            break;
                        case 1:
                            display5.text = "Fermenting.";
                            fermenting++;
                            break;
                        case 2:
                            display5.text = "Fermenting..";
                            fermenting++;
                            break;
                        case 3:
                            display5.text = "Fermenting...";
                            fermenting = 0;
                            break;
                    }
                    time2 = 0;
                }
                if (time > 10)
                {
                    stageFinished = true;
                    stage++;
                }
                else
                {
                    time = time + Time.deltaTime;
                }
                break;
            case 16:
                display5.text = "Send";
                whiteboard.text = "Pump out the beer into the storage tank";
                break;
            case 17:
                display5.text = "Empty";
                whiteboard.text = "The beer is left in the storage tank for upto 3 months";
                break;
        }


    }

    private void NextStage()
    {
        if (stageFinished)
        {
            stage++;
        }
    }

    public void Water1() { 
        if (stage == 0) { NextStage(); }
    }
    public void Heat1()
    {
        if (stage == 1) { NextStage(); }
    }
    public void Mix1()
    {
        if (stage == 3) { NextStage(); }
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

        if ((Malt.transform.position.x < 2.13f && Malt.transform.position.x > 1.68f)
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
