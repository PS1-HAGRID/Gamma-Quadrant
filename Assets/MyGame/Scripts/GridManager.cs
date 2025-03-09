using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour, iCargoGrid
{
    HashSet<Cargo> _ShippingManifest;
    int[,] _PhysicalizedGrid;

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
        _PhysicalizedGrid = new int[_GridResolution.x, _GridResolution.y];
        for (int i = 0; i < _PhysicalizedGrid.GetLength(0); i++) 
        { 
            for(int j = 0; j < _PhysicalizedGrid.GetLength(1); j++)
            {
                GameObject lCurrentCargo = Instantiate(_CargoPrefab, transform);
                lCurrentCargo.transform.position = new Vector3(i, j, 0);
                lCurrentCargo.transform.localScale = transform.localScale * 0.01f;
            }
        }
    }

    public int EvaluateCargoGridSize()
    {
        return _GridResolution.x * _GridResolution.y;
    }

    public Cargo AddCargo(Cargo pCargoToAdd)
    {
        _ShippingManifest.Add(pCargoToAdd);
        return pCargoToAdd;
    }

    public Cargo RemoveCargo(Cargo pCargoToRemove)
    {
        _ShippingManifest.Remove(pCargoToRemove);
        return pCargoToRemove;
    }
}
