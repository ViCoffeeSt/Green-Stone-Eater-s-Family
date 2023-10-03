using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameQarakerField;
    [SerializeField] private NameEaterAppers _nameEaterAppers;
    [SerializeField] private GemCollector _gemCollector;
    [SerializeField] private float _multiScale;

    private string _name;

    private RaycastHit _hit;

    private float _levelPlayer;

    public float LevelPlayer => _levelPlayer;

    private int _eatedStones;

    private Camera _mainCamera;

    private MemoryPlayerResult _memoryPlayerResult;

    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        Time.timeScale = 1f;
        _mainCamera = Camera.main;
        _name = _nameEaterAppers.GetUnusedRandomName();
        Debug.Log(_name);
        _nameQarakerField.text = _name;
        _levelPlayer = transform.localScale.x;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _memoryPlayerResult = FindObjectOfType<MemoryPlayerResult>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out _hit);
            _navMeshAgent.SetDestination(_hit.point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Gem"))
        {
            return;
        }

        Gem gemComponent = other.GetComponentInChildren<Gem>();

        if (gemComponent == null)
        {
            return;
        }

        if (gemComponent.PlayerInteract(this))
        {
            _gemCollector.GemEated++;
            _eatedStones++;
            UpdateLevelPlayer();
        }
    }

    private void UpdateLevelPlayer()
    {
        _levelPlayer = transform.localScale.x + _multiScale;
    }

    public void IncreaseStonesEaten()
    {
        _eatedStones++;
    }

    public void TransitResults()
    {
        _memoryPlayerResult.AddLevelToField(_levelPlayer);
        _memoryPlayerResult.AddNameToField(_name);
        _memoryPlayerResult.AddStonesToField(_eatedStones);
    }
}
