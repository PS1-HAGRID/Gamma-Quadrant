using UnityEngine;

public interface iCargoGrid
{
    public iHaulable AddCargo(iHaulable cargo);
    public iHaulable RemoveCargo(iHaulable cargo);


}
