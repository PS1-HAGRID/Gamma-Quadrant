using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class Cargo : MonoBehaviour, iHaulable
{
    GameObject[] _Models = new GameObject[1];

    public enum CargoType
    {
        Iron = 0,Copper = 1,Gold = 2,Hydrogen = 3,Ration = 4,Ice = 5
    }

    [SerializeField][Range(1,256)] private int _Size = 1;
    [SerializeField] private CargoType _Type;
    [SerializeField] private float _SpaceBetweenBoxes;

    [SerializeField] private GameObject _Model;
    [SerializeField] private Material[] _Materials;

    public int size { get; private set; }
    public CargoType type { get; private set; }
    
    private float spacing;
#if UNITY_EDITOR

    private void OnEnable()
    {
        EditorApplication.update += InEditorUpdateLoop;
    }

    private void OnDisable()
    {
        EditorApplication.update -= InEditorUpdateLoop;
    }

    private void InEditorUpdateLoop()
    {
        if(Application.isPlaying) return;

        if (!(size != _Size || type != _Type || spacing != _SpaceBetweenBoxes)) return;

        UpdateCargo();
    }

    private void UpdateCargo()
    {
        foreach(GameObject model in _Models)
        {
            DestroyImmediate(model);
        }

        size = _Size;
        type = _Type;
        spacing = _SpaceBetweenBoxes;

        _Models = new GameObject[size];

        int lMaterialIndex = 0;
        switch (type)
        {
            case CargoType.Iron:
                lMaterialIndex = (int)CargoType.Iron;
                break;
            case CargoType.Copper:
                lMaterialIndex = (int)CargoType.Copper;
                break;
            case CargoType.Hydrogen:
                lMaterialIndex = (int)CargoType.Hydrogen;
                break;
            case CargoType.Ice:
                lMaterialIndex = (int)CargoType.Ice;
                break;
            case CargoType.Gold:
                lMaterialIndex = (int)CargoType.Gold;
                break;
            case CargoType.Ration:
                lMaterialIndex = (int)CargoType.Ration;
                break;
        }

        Material lMaterial = _Materials[lMaterialIndex];

        int lBoxesPerRow = (int)Mathf.Sqrt(size);
        int lBoxesPerColumn = (size - 1) / lBoxesPerRow + 1;
        for (int i = 0; i < _Models.Length; i++) 
        { 
            GameObject lCurrentModel = Instantiate(_Model, transform);
            lCurrentModel.GetComponent<Renderer>().material = lMaterial;

            float xPos = (i % lBoxesPerRow - lBoxesPerRow * 0.5f + 0.5f) * (1 + _SpaceBetweenBoxes);
            float yPos = (i / lBoxesPerRow - lBoxesPerColumn * 0.5f + 0.5f) * (1 + _SpaceBetweenBoxes);
            lCurrentModel.transform.position = new Vector3(xPos, yPos, 0);

            _Models[i] = lCurrentModel;
        }
    }



    #endif
}
