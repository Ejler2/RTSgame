using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    public event EventHandler<onActiveBuildingTypeChangedEventArgs> onActiveBuildingTypeChanged;

    public class onActiveBuildingTypeChangedEventArgs : EventArgs {
        public BuildingTypeSO activeBuildingType;
    }


    private Camera mainCamera;
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;

    private void Awake() {
        Instance = this;

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    private void Start() {
        mainCamera = Camera.main;
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if (activeBuildingType != null) {
            Instantiate(activeBuildingType.prefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            }
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType) {
        activeBuildingType = buildingType;

        onActiveBuildingTypeChanged?.Invoke(this, 
            new onActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType });
    }

    public BuildingTypeSO GetActiveBuildingType() {
        return activeBuildingType;
    }
}
