using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Onde;


    public void OnEnable()
    {
        MusiqueManager.OnBeat += SpawnObstacle;
    }


    public void OnDisable()
    {
        MusiqueManager.OnBeat -= SpawnObstacle; 
    }

    void SpawnObstacle()
    {
        //TODO
        Debug.Log("Spawn Obstacle called");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected!");
            CheckColorCollision(other);
        }
    }


    void CheckColorCollision(Collider other)
    {
        if (Onde.GetComponent<Renderer>().material.color != Obstacle.GetComponent<Renderer>().material.color)
        {
            Debug.Log("Game Over - Color Mismatch");
            //StopGame();
        }
    }
}
