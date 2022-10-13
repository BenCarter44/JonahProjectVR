using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{

    [SerializeField] private Material mazeGroundMaterial;
    [SerializeField] private Material mazeWallMaterial;
    [SerializeField] private Material startMat;
    [SerializeField] private Material treasureMaterial;

    private MazeMeshGenerator meshGenerator;
    public bool showDebug;
    
    public int startX
    {
        get; private set;
    }
    public bool isImpossible
    {
        get; private set;
    }
    public int startY
    {
        get; private set;
    }
    public int endX
    {
        get; private set;
    }
    public int endY
    {
        get; private set;
    }
    public struct cordin
    {
        public int x;
        public int y;
    };

    public int[,] data  // stores the numbers of the maze. [x,x] shorthand.
    {
        get;  private set;  // get only
    }
    public float hallWidth
    {
        get; private set;
    }
    public float hallHeight
    {
        get; private set;
    }
    public int startRow
    {
        get { return startY; }
        private set {startY = value;}
    }
     
    public int startCol
    {
        get { return startX; }
        private set { startX = value; }
    }

    public int goalRow
    {
        get { return endY; }
        private set { endY = value; }
    }

    public int goalCol
    {
        get { return endX; }
        private set { endX = value; }
    }

    void Awake()
    {
        data = new int[,]
        {
            {1,1,1},
            {1,0,1},
            {1,1,1}
        };
        meshGenerator = new MazeMeshGenerator();
      //  GenerateMaze();
       // DisplayMaze();
    }

    public void GenerateMaze(int r, int c)
    {
        hallWidth = 3.75f;
        hallHeight = 3.5f;

        Random rd = new System.Random();
        data = new int[r, c];
        startY = rd.Next(0, r);
        startX = rd.Next(0, c);
        endY = rd.Next(0, r);
        endX = rd.Next(0, c);
        for (int y = 0; y < r; y++)
        {
            for (int x = 0; x < c; x++)
            {
                if (x == startX && y == startY)
                {
                    data[y, x] = 2;
                }
                else if (x == endX && y == endY)
                {
                    data[y, x] = 3;
                }
                else
                {
                    data[y, x] = (rd.Next(0,100000) % 10 < 3) ? 1 : 0;
                }
            }
        }
        
    }
    public void PlaceStartTrigger(TriggerEventHandler callback)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = new Vector3(startCol * hallWidth, .5f, startRow * hallWidth);
        go.name = "Start Trigger";
        go.tag = "Generated";
        Debug.Log(startCol);
        Debug.Log(startRow);
        Debug.Log("--");
        Debug.Log(goalCol);
        Debug.Log(goalRow);
        Debug.Log("--");
        go.GetComponent<BoxCollider>().isTrigger = true;
        go.GetComponent<MeshRenderer>().sharedMaterial = startMat;

        TriggerEventRouter tc = go.AddComponent<TriggerEventRouter>();
        tc.callback = callback;
    }

    public void PlaceGoalTrigger(TriggerEventHandler callback)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = new Vector3(goalCol * hallWidth, .5f, goalRow * hallWidth);
        go.name = "Treasure";
        go.tag = "Generated";
        Debug.Log("Tresure generated!!!");
        go.GetComponent<BoxCollider>().isTrigger = true;
        go.GetComponent<MeshRenderer>().sharedMaterial = treasureMaterial;
        
        TriggerEventRouter tc = go.AddComponent<TriggerEventRouter>();
        tc.callback = callback;
    }   
    void OnGUI()
    {
        //1
        if (!showDebug)
        {
            return;
        }

        //2
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0); // get the number of rows
        int cMax = maze.GetUpperBound(1); // get number of cols.

        string msg = "";

        //3
        for (int i = rMax; i >= 0; i--)
        {
            for (int j = 0; j <= cMax; j++)
            {
                if (maze[i, j] == 0)
                {
                    msg += "....";
                }
                else if(maze[i,j] == 2)
                {
                    msg += "SS";
                }
                else if(maze[i,j] == 3)
                {
                    msg += "EE";
                }
                else
                {
                    msg += "==";
                }
            }
            msg += "\n";
        }

        //4
        GUI.Label(new Rect(20, 20, 500, 500), msg);
    }
    public void DisplayMaze()
    {
        GameObject go = new GameObject();
        go.transform.position = Vector3.zero;
        go.name = "Procedural Maze";
        go.tag = "Generated";

        MeshFilter mf = go.AddComponent<MeshFilter>();
        mf.mesh = meshGenerator.FromData(data);

        MeshCollider mc = go.AddComponent<MeshCollider>();
        mc.sharedMesh = mf.mesh;

        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        mr.materials = new Material[2] { mazeGroundMaterial, mazeWallMaterial };
    }
    public void DisplayCrumbs()
    {
        Stack<cordin> answers = solver();
        isImpossible = answers.Count == 0;
        foreach(cordin pt in answers)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(pt.x * hallWidth, .5f, pt.y * hallWidth);
            go.transform.localScale = new Vector3(-0.25f, -0.25f, -0.25f);
            go.name = "Crumbs";
            go.tag = "Generated";
            Debug.Log(" Ans: " + pt.x + " " + pt.y);
        }
        
       // go.GetComponent<MeshRenderer>().sharedMaterial = treasureMaterial;
    }
    public void DisposeOldMaze()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Generated");
        foreach (GameObject go in objects)
        {
            Destroy(go);
        }
    }
    private Stack<cordin> solver() // take in the maze data and the console. This function is BigO: O(n) where n is the number of "path" cells in the maze. It goes through each one.
    {
        // print out the path.
        // down, right, left, up
        int[] orderX = new int[] { 0, 1, -1, 0 };
        int[] orderY = new int[] { 1, 0, 0, -1 };

        int currentPositionY = startY;
        int currentPositionX = startX;

        int colLength = data.GetUpperBound(1);
        int rowHeight = data.GetUpperBound(0);

        int[,] dataTemp = new int[rowHeight,colLength];
        for(int x = 0; x < rowHeight; x++)
        {
            for(int y = 0; y < colLength; y++)
            {
                dataTemp[x, y] = data[x, y];
            }
        }


        
        Stack<cordin> mStack = new Stack<cordin>();
        bool valid = false;

        cordin startCord;
        startCord.y = startY;
        startCord.x = startX;

	    //MyStack.push(startCord);
	    /*
		    1 1 3 1 1 1
		    1 0 1 0 0 1
		    1 0 1 0 1 1
		    1 1 0 0 4 0
		    */
	    while (true)
	    {
		    //cout << currentPositionX << " " << currentPositionY << "\n";
		    valid = false;
		    for (int look = 0; look< 4; look++)
		    {
			    int tempX = currentPositionX + orderX[look];
                int tempY = currentPositionY + orderY[look];
			
			    if (tempX >= 0 && tempY >= 0 && tempX<colLength && tempY<rowHeight && dataTemp[tempY,tempX] != 1)
			    {
				    // exists!
				    cordin curCord;
                    curCord.x = currentPositionX;
				    curCord.y = currentPositionY; // push to stack before advancing.
				    mStack.Push(curCord);
				    dataTemp[currentPositionY,currentPositionX] = 1;

                    currentPositionX = tempX;
				    currentPositionY = tempY;
				
				    valid = true;
				    break;
			    }
		    }
		    if (!valid && currentPositionX == startX && currentPositionY == startY)
            {
                // done!
                return new Stack<cordin>();
            }
            if (!valid)
            {
                // go back to the stack!
                dataTemp[currentPositionY,currentPositionX] = 1;

                cordin thePastCur = mStack.Pop();

                currentPositionX = thePastCur.x;
                currentPositionY = thePastCur.y; // go back.

            }
            if (currentPositionX == goalCol && currentPositionY == goalRow)
            {
                // done!
                
                break;
            }
		
	    }
	    int c = 0;
        Stack<cordin> reverseStack = new Stack<cordin>();
        cordin ender;
        ender.x = goalCol;
        ender.y = goalRow;
        reverseStack.Push(ender);
        foreach (cordin pt in mStack) // reverse the stack by dumping it onto another stack.
        {
            reverseStack.Push(pt);
        }
        return reverseStack;
        
    }
    
// Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
