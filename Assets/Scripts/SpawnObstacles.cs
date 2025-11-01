using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] ObstaclesPrefab;
    [SerializeField]private float spawnOffsetZ = 10f;

    private ElectronicBoardManagement eBManagement;
    private void Start()
    {
        if (eBManagement == null)
        {
            eBManagement = FindFirstObjectByType<ElectronicBoardManagement>();
        }
    }


    private void OnEnable()
    {
        MusiqueManager.OnBeat += SpawnObstacle;
    }


    private void OnDisable()
    {
        MusiqueManager.OnBeat -= SpawnObstacle;
    }



    void SpawnObstacle()
    {
     
        if (eBManagement == null) return;

        //Debug.Log("Spawn Obstacle called");
        for (int line = 0; line < eBManagement.linesEBoard.Length; line++)
        {
            if (!eBManagement.linesIActive[line]) continue;

            int rnd = Random.Range(0, ObstaclesPrefab.Length);
            GameObject newObstacle = Instantiate(ObstaclesPrefab[rnd]);

            newObstacle.transform.SetParent(eBManagement.lineParents[line].transform, false);

            float lastZ = 0f;

            GameObject[] lineBoards = eBManagement.linesEBoard[line];

            for (int l = 0; l < lineBoards.Length; l++)
            {
                if (lineBoards[l] != null) 
                {
                   lastZ = Mathf.Max(lastZ, lineBoards[l].transform.localPosition.z);
                }
            }

            newObstacle.transform.localPosition = new Vector3(0f, 0f, lastZ + spawnOffsetZ);
        }
    }
}
