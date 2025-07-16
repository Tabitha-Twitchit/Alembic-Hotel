using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    //the base game object to be randomly instantiated. could be multiple objects. comes from here: https://youtu.be/15PVp-7P9D8
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    //public GameObject theNextThing etc;
    //variables to set the area in 3d space, a randomizer for what objects to generate, and 2 variables to count up to then limit the number to be generated
    private int xPos;
    private int yPos;
    private int zPos;
    private int objectToGenerate;
    private int objectQuantity;
    public int objectQuantityCap;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        while(objectQuantity < objectQuantityCap)
        {
            //range is always 1 more than the total number you want instantiated. 
            objectToGenerate = Random.Range(1, 7);
            xPos = Random.Range(119, 343);
            yPos = Random.Range(14, 262);
            zPos = Random.Range(-119, 70);
           
            if (objectToGenerate == 1)
            {
                Instantiate(object1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            //for every additional object you want to add, duplicate and adapt this if statement.
            if (objectToGenerate == 2)
            {
                Instantiate(object2, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            if (objectToGenerate == 3)
            {
                Instantiate(object3, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            if (objectToGenerate == 4)
            {
                Instantiate(object4, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            if (objectToGenerate == 5)
            {
                Instantiate(object5, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            if (objectToGenerate == 6)
            {
                Instantiate(object6, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

            yield return new WaitForSeconds(0.01f);
            objectQuantity += 1;

        }
    }
    
}
