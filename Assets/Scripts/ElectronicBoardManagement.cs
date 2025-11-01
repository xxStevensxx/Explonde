using UnityEngine;

public class ElectronicBoardManagement : MonoBehaviour
{

    [SerializeField] private GameObject[] electronicBoardPrefab;
    [SerializeField] private Transform ElectronicBoard;
    [SerializeField] private GameObject Onde;

    private GameObject[] electronicBoardOnScene;

    //getters 
    private GameObject[][] LinesEBoard;
    public GameObject[][] linesEBoard => LinesEBoard;

    private bool[] LinesIActive;
    public bool[] linesIActive => LinesIActive;

    private GameObject[] LineParents;
    public GameObject[] lineParents => LineParents;

    //********

    private int LineEBordMax = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InitLines();
        CreateElectronicBoard();

    }

    // Update is called once per frame
    void Update()
    {
        RecycleEBoards();
    }


    void InitLines()
    {
        // Initialize the electronic boards on the scene
        LinesEBoard = new GameObject[LineEBordMax][];
        LinesIActive = new bool[LineEBordMax];
        LineParents = new GameObject[LineEBordMax];

        // Set default values
        for (int i = 0; i < LineEBordMax; i++)
        {

            // Calculate offset for each line
            float offsetX = i * ElectronicBoard.GetComponent<Renderer>().bounds.size.x;

            // Create parent object for each line
            GameObject LineParent = new GameObject($"Line_{i}");
            LineParent.transform.parent = transform;
            LineParent.transform.localPosition = new Vector3(offsetX, 0f, 0f);


            LinesEBoard[i] = new GameObject[electronicBoardPrefab.Length]; // No electronic board assigned
            LinesIActive[i] = false; // All lines inactive initially
            LineParents[i] = LineParent;
        }

        // Activate the first line for demonstration
        LinesIActive[0] = true;
        LinesIActive[1] = false;
        LinesIActive[2] = true;
        electronicBoardOnScene = new GameObject[electronicBoardPrefab.Length];
    }



    // Create electronic boards on active lines
    void CreateElectronicBoard()
    {
        for (int line = 0; line < LinesEBoard.Length; line++)
        {
            if (LinesIActive[line])
            {
                for (int eBoard = 0; eBoard < electronicBoardPrefab.Length; eBoard++)
                {
                    int rnd = Random.Range(0, electronicBoardPrefab.Length);
                    GameObject newBoard = Instantiate(electronicBoardPrefab[rnd], LineParents[line].transform);
                    newBoard.transform.localPosition = new Vector3(0f, 0f, eBoard * ElectronicBoard.GetComponent<Renderer>().bounds.size.z);
                    electronicBoardOnScene[eBoard] = newBoard;
                    LinesEBoard[line][eBoard] = newBoard;

                }
            }
        }
    }


    void RecycleEBoards()
    {
        float boardSizeZ = ElectronicBoard.GetComponent<Renderer>().bounds.size.z;
        float boardSizeX = ElectronicBoard.GetComponent<Renderer>().bounds.size.x;

        for (int line = 0; line < LinesEBoard.Length; line++)
        {

            if (!LinesIActive[line] || LinesEBoard[line] == null) continue;

            for (int eBoard = 0; eBoard < electronicBoardOnScene.Length; eBoard++)
            {
                GameObject board = LinesEBoard[line][eBoard];

                    // Create a new random board at the end
                    int rnd = Random.Range(0, electronicBoardPrefab.Length);

                if (board.transform.position.z + boardSizeZ / 2 < Onde.transform.position.z)
                {
                    // Recycle the board by moving it to the end of the line
                    float oldPosZ = board.transform.position.z;
                    Destroy(board);
                    GameObject newboard = Instantiate(electronicBoardPrefab[rnd], LineParents[line].transform);
                    newboard.transform.localPosition = new Vector3(0f, 0f, oldPosZ + boardSizeZ * electronicBoardOnScene.Length);
                    LinesEBoard[line][eBoard] = newboard;

                }
            }
        }
    }
}

