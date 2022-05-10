// Oz
using UnityEngine;
using UnityEngine.AI;

public class DummyPoints : MonoBehaviour
{
    #region Singleton
    public static DummyPoints instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    [SerializeField] private Transform fredDummyPoints;
    [SerializeField] private Transform barneyDummyPoints;

    public Vector3 GetRandomBasePoint(Player.PlayerType playerType)
    {
        if(playerType == Player.PlayerType.Player)
        {
            return GetRandomPoint(fredDummyPoints);
        }
        else
        {
            return GetRandomPoint(barneyDummyPoints);
        }
    }

    private Vector3 GetRandomPoint(Transform transform) => transform.GetChild(Random.Range(0, transform.childCount)).position;

    //public Vector3 GetRandomWalkablePoint()
    //{
    //    // return random point on navmesh
    //    NavMeshHit hit;
    //    NavMesh.SamplePosition(Vector3.zero, out hit, 100f, NavMesh.AllAreas);
    //    return hit.position;
    //}
}
