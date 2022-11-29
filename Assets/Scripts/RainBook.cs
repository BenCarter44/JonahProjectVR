using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class RainBook : MonoBehaviour
{


    private int[] bookExclude = { 6, 7, 11, 12, 13, 17, 18, 19, 23, 24, 25, 28, 36, 37 }; // valid is 1 - 67
    private List<int> bookNum;
    private int maxX = -150;
    private int maxZ = 92;
    private int minX = 150;
    private int minZ = -92;

    public GameObject mainPlayer;
    public float limitRadius;
    private int createCounter;
    public float timeInv;
    private float timeElap;

    // Start is called before the first frame update
    void Start()
    {
        createCounter = 0;

        
        // jeepReplica.SetActive(false); // disable it.

        bookNum = new List<int>();

        for (int x = 1; x < 68; x++)
        {
            if (binarySearch(bookExclude, bookExclude.Length, x) != -1)
            {
                bookNum.Add(x);
            }
        }
        timeElap = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeInv + timeElap)
        {
            timeElap = Time.time;
            CreateBooks();
        }
    }
    void CreateBooks()
    {
        Random rd = new Random();

        while (true)
        {
            float x = (float)rd.NextDouble() * (maxX - minX) + (float)minX;
            float z = (float)rd.NextDouble() * (maxZ - minZ) + (float)minZ;
            float y = 40.0f;

            Vector3 pl = mainPlayer.transform.position;
            Vector3 newPl = new Vector3(x, pl.y, z);
            if (Vector3.Distance(pl, newPl) > limitRadius)
            {
                int gameObjNumber = bookNum[createCounter];
                string fixedCount = "" + (gameObjNumber);
                if (gameObjNumber < 10)
                {
                    fixedCount = "0" + (gameObjNumber);
                }
                GameObject newBook = (GameObject)Instantiate(Resources.Load("QA_Books/Models/Book_" + fixedCount));
                newPl.y = y;
                newBook.transform.position = newPl;
                newBook.transform.localScale = new Vector3(10f, 10f, 10f);
                newBook.transform.localEulerAngles = new Vector3(0f, rd.Next(360), 0f);
                newBook.AddComponent<StopBook>();
                newBook.GetComponent<StopBook>().floor = -4f;
                newBook.GetComponent<StopBook>().me = newBook;
                newBook.AddComponent<Rigidbody>();
                newBook.SetActive(true);
                createCounter++;
                if (createCounter >= bookNum.Count)
                {
                    createCounter = 0;
                }
                break;
            }
        }

        
    }
    public static int binarySearch(int[] myList, int len, int lookFor)
    {
        // 1,2,5,8,15,17,20
        int targetStart = 0;
        int targetEnd = len;
        while (targetStart < targetEnd - 1) // while the target minilist is longer than 1
        {
            // cout << targetStart << " " << targetEnd << '\n';
            if (myList[(targetStart + targetEnd) / 2] > lookFor)
            {
                targetEnd = (targetStart + targetEnd) / 2;
            }
            else if (myList[(targetStart + targetEnd) / 2] < lookFor)
            {
                targetStart = (targetStart + targetEnd) / 2;
            }
            else
            {
                return (targetStart + targetEnd) / 2;
            }
        }
        if (targetStart == targetEnd && lookFor == myList[targetStart])
        {
            return targetStart;
        }
        return -1;



    }
}
