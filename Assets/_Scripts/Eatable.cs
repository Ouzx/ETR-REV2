// Oz
using UnityEngine;

public class Eatable : MonoBehaviour
{
    [SerializeField] private int amount;
    private bool empty = false;
    public int GetBite()
    {
        if (empty) return 0;

        if (amount > 0)
        {
            amount--;
            return 1;
        }
        else
        {
            // TODO: Can raise an error
            empty = true;
            Invoke(nameof(DestroySelf), 0.1f);
            return 0;
        }

    }

    private void DestroySelf() => gameObject.SetActive(false);;
}
