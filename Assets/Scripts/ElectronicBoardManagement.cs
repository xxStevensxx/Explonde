using UnityEngine;

public class ElectronicBoardManagement : MonoBehaviour
{

    [SerializeField]private GameObject[] electronicBoardPrefab;
    private GameObject[] electronicBoardOnScene;

    private int[] LinesEBoard;
    private bool[] LinesIActive;
    private int LineEBordMax = 3;
    private float ElectronicBoardSizeZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the electronic boards on the scene
        LinesEBoard = new int[LineEBordMax];
        LinesIActive = new bool[LineEBordMax];

        // Set default values
        for (int i = 0; i < LineEBordMax; i++)
        {
            LinesEBoard[i] = -1; // No electronic board assigned
            LinesIActive[i] = false; // All lines inactive initially
        }

        electronicBoardOnScene = new GameObject[electronicBoardPrefab.Length];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitLines()
    {
       
    }

    void CreateElectronicBoard(int lineIndex, int boardType)
    {

    }
}

