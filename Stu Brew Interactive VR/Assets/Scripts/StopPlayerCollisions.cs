using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerCollisions : MonoBehaviour
{
    public Collider player;

    public Collider object1;
    public Collider object2;
    //public Collider object3;
    //public Collider object4;

    private Collider[] objects;


    // Start is called before the first frame update
    void Start()
    {
        Collider[] objects = {object1, object2};
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Physics.IgnoreCollision(objects[i], player);
        }
    }
}
