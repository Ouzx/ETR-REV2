// Oz
using UnityEngine;

public class Interactable
{
    public enum Type
    {
        Food,
        Enemy,
        Bush,
        None,
        ToBase

    }
    public Type type;
    private Vector3 position;
    public Vector3 Position
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
