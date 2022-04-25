// Oz
using UnityEngine;

public class Eatable : MonoBehaviour
{
    [SerializeField] private int amount;

    public int GetBite()
    {
        if (amount > 0)
        {
            amount--;
            return 1;
        }
        else
        {
            Invoke(nameof(DestroySelf), 0.1f);
            return 0;
        }

    }

    private void DestroySelf() => Destroy(gameObject);
}
