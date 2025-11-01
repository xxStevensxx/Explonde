using UnityEngine;

public class Life : MonoBehaviour
{

    [SerializeField]private int[] LifePoint;

    private int MaxLife = 3;
    public int CurrentLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        InitLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitLife() 
    {
     
        LifePoint = new int[MaxLife];
        LifePoint[0] = 1;
        LifePoint[2] = 1;

        for (int lp = 0; lp < LifePoint.Length; lp++)
        {
            if (LifePoint[lp] == 1) 
            {
                CurrentLife +=1;
            }
        }

    }

    void AddLife()
    {

    }

    void RemoveLife()
    {

    }

}
