using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour, iCargoGrid
{
    Dictionary<Cargo, int> _ShippingManifest;

    [Header("Grid Variables")]
    [SerializeField] int2 _GridResolution = new int2(1,1);

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

    }

    public int EvaluateCargoGridSize()
    {
        return _GridResolution.x * _GridResolution.y;
    }

    public Cargo AddCargo(Cargo pCargoToAdd)
    {
        _ShippingManifest.Add(pCargoToAdd, 0);
        return pCargoToAdd;
    }

    public Cargo RemoveCargo(Cargo pCargoToRemove)
    {
        _ShippingManifest.Remove(pCargoToRemove);
        return pCargoToRemove;
    }
   
}
