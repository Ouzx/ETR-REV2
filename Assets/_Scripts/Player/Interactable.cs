// Oz
using UnityEngine;

public class Interactable
{
    public enum Type
    {
        Food,
        Enemy,
        Bush,
        None
    }
    public Type type;
    
    public Vector3 position
    {
        get
        {
            if (transform != null)
                return transform.position;
            return position;
        }

        set
        {
            position = value;
        }
    }
    public Transform transform;
}
