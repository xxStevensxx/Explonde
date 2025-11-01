using UnityEngine;

public class SphereController : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private int[] LifePoints;

    private float CurrentSpeed;
    private Renderer sphereRenderer;
    private Color[] Colors = { Color.red, Color.green, Color.blue };
    private int colorIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        sphereRenderer = GetComponentInChildren<Renderer>();
        int rnd = Random.Range(0, Colors.Length);
        colorIndex = rnd;
        sphereRenderer.material.color = Colors[rnd];

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeColor();
        }

        Movement();
        SpeedLimit();
    }


 
    private void ChangeColor()
    {
        colorIndex++;

        if (colorIndex > Colors.Length - 1)
        {
            colorIndex = 0;
        }

        sphereRenderer.material.color = Colors[colorIndex];

    }

    private void Movement() 
    {
        //Movement
        CurrentSpeed += Speed * Time.deltaTime;
        transform.position += transform.forward * CurrentSpeed;
    }

    private void SpeedLimit() 
    {
        //Limite de vitesse
        if (CurrentSpeed >= MaxSpeed)
        {
            CurrentSpeed = MaxSpeed;
        }

    }

    private void SpawnSphere()
    {
        for (int lp = 0; lp < LifePoints.Length; lp++) 
        {
            if (LifePoints[lp] == 1)
            {

                Instantiate(this.gameObject, new Vector3(0, 5, 0), Quaternion.identity);

            }
            else 
            {
                Destroy(this.gameObject);
            }

        }
    }
}
