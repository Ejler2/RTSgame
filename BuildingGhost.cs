using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour {

    private GameObject spriteGameObject;

    private void Awake() {
        spriteGameObject = transform.Find("sprite").gameObject;

        Hide();
    }

    private void Start() {
        BuildingManager.Instance.onActiveBuildingTypeChanged += BuildingManager_onActiveBuildingTypeChanged;
    }

    private void BuildingManager_onActiveBuildingTypeChanged(object sender, BuildingManager.onActiveBuildingTypeChangedEventArgs e) {
        if (e.activeBuildingType == null) {
            Hide();
        } else {
            Show(e.activeBuildingType.sprite);
        }
    }

    private void Update() {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }

    private void Show(Sprite ghostSprite) {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }

    private void Hide() {
        spriteGameObject.SetActive(false);
    }

}
