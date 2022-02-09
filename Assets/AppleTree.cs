using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;

    public float speed = 5f;

    public float leftAndRightEdge = 20f;

    public float chanceToChangeDirections = 0.01f;

    public float secondsBetweenAppleDrops = 1f;

    public float appleCounter = 0;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        appleCounter++;
        if(appleCounter >= 10)
        {
            if(speed >= 0)
            {
                speed += 3f;
            }
            else
            {
                speed -= 3f;
            }
            
            if(chanceToChangeDirections > 0.2)
            {
                chanceToChangeDirections += 0.01f;
            }
            
            if(secondsBetweenAppleDrops > 0.5)
            {
                secondsBetweenAppleDrops -= 0.1f;
            }
            appleCounter = 0;
        }
        
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //changing direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right 
        } 
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }

    }

    void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }



}
