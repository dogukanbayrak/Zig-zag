using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject lastGroundObject;

    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject fasterGroundPrefab;
    [SerializeField] private GameObject slowerGroundPrefab;


    public GameObject newGroundObject;
    public GameObject fasterGroundObject;
    public GameObject slowerGroundObject;

    private int groundDirection;
    private int groundSpeedSet;


    void Start()
    {
        for(int i=0; i<2; i++)
        {
            GenerateRandomNewGrounds();
        }
        
    }

    
    void Update()
    {
        if (GameManager.groundCounter >= 75)
        {
            GameManager.groundCounter = 0;
            GenerateRandomNewGrounds();

        }

    }

    private void CreateNewGround()
    {
        groundDirection = Random.Range(0,2);

        groundSpeedSet = Random.Range(0, 20);

        if (groundDirection == 0)
        {
            if(groundSpeedSet == 15)
            {
                fasterGroundObject = Instantiate(fasterGroundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z), Quaternion.identity);
                lastGroundObject = fasterGroundObject;
            }

            else if (groundSpeedSet == 1)
            {
                slowerGroundObject = Instantiate(slowerGroundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z), Quaternion.identity);
                lastGroundObject = slowerGroundObject;
            }


            else
            {
                newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z), Quaternion.identity);
                lastGroundObject = newGroundObject;
            }


            
        }

        else
        {
            if(groundSpeedSet == 15)
            {
                fasterGroundObject = Instantiate(fasterGroundPrefab, new Vector3(lastGroundObject.transform.position.x,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z + 1f), Quaternion.identity);
                lastGroundObject = fasterGroundObject;
            }

            else if (groundSpeedSet == 1)
            {
                slowerGroundObject = Instantiate(slowerGroundPrefab, new Vector3(lastGroundObject.transform.position.x ,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z + 1f), Quaternion.identity);
                lastGroundObject = slowerGroundObject;
            }


            else
            {
                newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x,
                                                                    lastGroundObject.transform.position.y,
                                                                    lastGroundObject.transform.position.z + 1f), Quaternion.identity);
                lastGroundObject = newGroundObject;
            }
            
        }

    }

    public void GenerateRandomNewGrounds()
    {
        for( int j=0; j<=75; j++)
        {
            CreateNewGround();
        }
    }
}
