// Oz
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Awake,
        Sleep
    }
    public PlayerState state;


    public Stats stats;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void GetTired(float Distance)
    {
        
    }

    public void TakeDamage(float damge)
    {
        
    }

    public void Eat(int food)
    {

    }
    private void Regen()
    {
        
    }

    public void Reproduce()
    {
        
    }
} 
