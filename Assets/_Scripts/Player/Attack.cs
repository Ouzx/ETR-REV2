// Oz
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    
    // If I am stronger; return true;
    public bool ComparePowers(Transform _enemy) => player.stats.GetPower() > _enemy.GetComponent<Player>().stats.GetPower();
}
