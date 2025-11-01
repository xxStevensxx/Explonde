using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{

    public static event Action<int> CheckCollider;


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision with Player detected!");   
        if (other.CompareTag("Onde"))
        {
            CheckColorCollision(other);
        }
    }

    void CheckColorCollision(Collider other)
    {
        if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
        {
            Debug.Log("Game Over - Color Mismatch");
            StopGame();
            //Destroy(other);
        }
        else 
        {
            Debug.Log("Good");
            CheckCollider?.Invoke(1);
            //Destroy(other);
        }

    }

    void StopGame()
    {
        SceneManager.LoadScene("GameOver");
    }

}
