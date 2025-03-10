using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour, iCargoGrid
{
    HashSet<iHaulable> _ShippingManifest = new HashSet<iHaulable>();
    GameObject[,] _PhysicalizedGrid;

    [Header("Grid Variables")]
    [SerializeField] int2 _GridResolution = new int2(1,1);

    [SerializeField] GameObject _CargoPrefab;
    [SerializeField] Material _GridMaterial;

    private int GridSize;

    private void Start()
    {
        InitializeGrid();
    }

    private void Update()
    {
        UpdateGrid();
    }

    private void UpdateGrid()
    {

    }

    private void InitializeGrid()
    {
        _PhysicalizedGrid = new GameObject[_GridResolution.x, _GridResolution.y];
        for (int i = 0; i < _PhysicalizedGrid.GetLength(0); i++) 
        { 
            for(int j = 0; j < _PhysicalizedGrid.GetLength(1); j++)
            {
                GameObject lCurrentCargo = Instantiate(_CargoPrefab, transform);
                lCurrentCargo.transform.position = new Vector3(i, j, 0);
                lCurrentCargo.transform.localScale = transform.localScale * 0.01f;
                _PhysicalizedGrid[i, j] = lCurrentCargo;

                AddCargo(lCurrentCargo.GetComponent<iHaulable>());
            }
        }

        GameObject lCargoToRemove = _PhysicalizedGrid[1, 4];
        RemoveCargo(lCargoToRemove.GetComponent<iHaulable>());
        _PhysicalizedGrid[1, 4] = null;
        Destroy(lCargoToRemove);
    }

    public int EvaluateCargoGridSize()
    {
        return _GridResolution.x * _GridResolution.y;
    }

    public iHaulable AddCargo(iHaulable pCargoToAdd)
    {
        _ShippingManifest.Add(pCargoToAdd);
        return pCargoToAdd;
    }

    public iHaulable RemoveCargo(iHaulable pCargoToRemove)
    {
        _ShippingManifest.Remove(pCargoToRemove);
        return pCargoToRemove;
    }
}
