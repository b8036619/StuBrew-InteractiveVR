using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public ParticleSystem particlePour;

    private bool isPouring = false;
    


    // Start is called before the first frame update
    void Start()
    {
        particlePour.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        particlePour.Play();
    }

    private void EndPour()
    {
        particlePour.Stop();
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

}
