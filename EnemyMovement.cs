using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (player)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
