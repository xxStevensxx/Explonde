using UnityEngine;

public class ElectronicBoardManagement : MonoBehaviour
{

    [SerializeField]private GameObject[] electronicBoardPrefab;

    public GameObject[] electronicBoardOnScene;

    public GameObject[][] LinesEBoard;
    private bool[] LinesIActive;
    private int LineEBordMax = 3;
    private float ElectronicBoardSizeZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the electronic boards on the scene
        LinesEBoard = new GameObject[LineEBordMax][];
        LinesIActive = new bool[LineEBordMax];

        // Set default values
        for (int i = 0; i < LineEBordMax; i++)
        {
            LinesEBoard[i] = new GameObject[electronicBoardPrefab.Length]; // No electronic board assigned
            LinesIActive[i] = false; // All lines inactive initially
        }

        LinesIActive[0] = true;
        electronicBoardOnScene = new GameObject[electronicBoardPrefab.Length];

    }

    // Update is called once per frame
    void Update()
    {
        CreateElectronicBoard();
    }

    void InitLines()
    {
       
    }

    void CreateElectronicBoard()
    {
        for (int line = 0; line < LinesEBoard.Length; line++) 
        {
            if (LinesIActive[line])
            {
                for (int eBoard = 0; eBoard < electronicBoardPrefab.Length; eBoard++)
                {
                    int rnd = Random.Range(0, electronicBoardPrefab.Length);
                    GameObject newBoard = Instantiate(electronicBoardPrefab[rnd], Vector3.zero, Quaternion.identity);
                    electronicBoardOnScene[eBoard] = newBoard;
                    LinesEBoard[line][eBoard] = newBoard;

                }
            }
        }
    }
}

