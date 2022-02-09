using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject   basketPrefab;
    public int          numBaskets = 4;
    public float        basketBottomY = -14f;
    public float        basketSpacingY = 2f;
    public List<GameObject> basketList;
    static public int round = 1;
    Text roundText;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }   
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {       
           SceneManager.LoadScene("GameOver");
        }
        else
        {
            //get text object and update round number
            round++;
            roundText = GameObject.Find("Round").GetComponent<Text>();
            roundText.text = "Round: " + round;

            AppleTree appleTree = GameObject.Find("AppleTree").GetComponent<AppleTree>();
            appleTree.speed = 5f;
            appleTree.chanceToChangeDirections = 0.01f;
            appleTree.secondsBetweenAppleDrops = 1f;
            appleTree.appleCounter = 0;
        }

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
