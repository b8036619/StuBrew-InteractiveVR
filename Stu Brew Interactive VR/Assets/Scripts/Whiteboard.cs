using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Whiteboard : MonoBehaviour
{
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;

    private int currentTaskNo;

    // Start is called before the first frame update
    void Start()
    {
        currentTaskNo = 0;
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewTask()
    {
        currentTaskNo++;
        SetText();
    }

    private void SetText()
    {
        text1.text = GetInstruction(currentTaskNo);
        text2.text = GetInstruction(currentTaskNo + 1);
        text3.text = GetInstruction(currentTaskNo + 2);
        text4.text = GetInstruction(currentTaskNo + 3);
    }

    private string GetInstruction(int n)
    {
        switch (n) {
            case 0:
                return "Add water to the hot liquor tank";
            case 1:
                return "Heat the water in the hot liquor tank to 78c";
            case 2:
                return "Pump out the water into the mash tun";
            case 3:
                return "Collect the bucket of malt from the shelf and pour it into the mash tun";
            case 4:
                return "Mix the grain and water to create the mash";
            case 5:
                return "Leave mash for 1 hour";
            case 6:
                return "Pump out the mash into the kettle";
            case 7:
                return "Sparge the grain by pumping hot water from the hot liquor tank";
            case 8:
                return "Pump the mash into the kettle";
            case 9:
                return "Collect the bucket of hops from the shelf and pour it into the kettle";
            case 10:
                return "Boil wort for 1 hour";
            case 11:
                return "Pump out the wort through the heat exchanger to the fermentation vessel";
            case 12:
                return "Add yeast to fermentation vessel and ferment for 4 days";
            
            default:
                return "";

        }
    }

}
