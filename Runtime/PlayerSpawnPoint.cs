using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        _playerTransform.position = transform.position;
        _playerTransform.rotation = transform.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.33f);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
    }
}
