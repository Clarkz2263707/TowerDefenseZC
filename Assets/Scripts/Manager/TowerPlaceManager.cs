using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlaceManager : MonoBehaviour
{
    public Camera MainCamera;
    public LayerMask TileLayer;
    public InputAction PlaceTowerAction;

    
    
    private GameObject currentTowerPrefabToSpawn;
    private GameObject towerPreview;
    private Vector3 towerPlacementPosition;
    [SerializeField] private float placementHeightOffset = 0.2f;

    [SerializeField] private bool isPlacingTower = false;
    private bool isTileSelected = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isPlacingTower)
        {
            Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, TileLayer))
            {
                towerPlacementPosition = hitInfo.transform.position + Vector3.up * placementHeightOffset;
                if (towerPreview != null)
                {
                    towerPreview.transform.position = towerPlacementPosition;
                    towerPreview.SetActive(true);
                }
                isTileSelected = true;
            }
            else
            {
                if (towerPreview != null)
                    towerPreview.SetActive(false);
                isTileSelected = false;
            }
        }
    }

    private void OnEnable()
    {
        PlaceTowerAction.Enable();
        PlaceTowerAction.performed += OnPlaceTower;
    }

    private void OnDisable()
    {
        PlaceTowerAction.performed -= OnPlaceTower;
        PlaceTowerAction.Disable();
    }

    public void StartPlacingTower(GameObject towerPrefab)
    {
        if (currentTowerPrefabToSpawn != towerPrefab)
        {
            isPlacingTower = true;
            currentTowerPrefabToSpawn = towerPrefab;
            if (towerPreview != null)
            {
               Destroy(towerPreview);
            }
            towerPreview = Instantiate(currentTowerPrefabToSpawn);
        }
    }

    private void OnPlaceTower(InputAction.CallbackContext context)
    {
        if(isPlacingTower && isTileSelected)
        {
            int towerCost = currentTowerPrefabToSpawn.GetComponent<Tower>().Cost;
            if (MoneyManager.Instance.SpendMoney(towerCost))
            {
                Instantiate(currentTowerPrefabToSpawn, towerPlacementPosition, Quaternion.identity);
                Destroy(towerPreview);
                currentTowerPrefabToSpawn = null;
                isPlacingTower = false;
            }
            else
            {
                Debug.Log("Not enough money to place this tower!");
            }
        }
    }
}
