using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _fixedDistance;
    [SerializeField] private MemoryPlayerResult _memoryPlayerResult;

    private Transform _target;

    private void Start()
    {
        SetTaget();
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 playerSize = _target.localScale;

            Vector3 cameraPosition = _target.position - Vector3.forward * _fixedDistance * Mathf.Max(playerSize.x, playerSize.y);

            transform.position = cameraPosition;
        }
        else SetTaget();
    }

    private void SetTaget()
    {
        GameObject newTarget = GameObject.FindGameObjectWithTag("Player");

        if (newTarget != null)
        {
            Player player = newTarget.GetComponent<Player>();
            _target = newTarget.transform;
            player.enabled = true;
        }
        else _memoryPlayerResult.ShowResultsWindow();
    }
}
