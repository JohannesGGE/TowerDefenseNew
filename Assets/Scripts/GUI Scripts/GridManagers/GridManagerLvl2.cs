using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLvl2 : MonoBehaviour{
    [SerializeField] private GameObject _towerSlotPrefab;

    public void Start(){
        GenerateGrid();
    }

    public void GenerateGrid(){
        for(int i = 0; i < 13; i++){
            for(int j = 0; j < 9; j++){
                var spawnedTowerSlot = Instantiate(_towerSlotPrefab, new Vector3(120 * i + 55, 120 * j + 59), Quaternion.identity, GameObject.Find("Grid").transform);
                spawnedTowerSlot.name = $"Tower Slot {i} {j}";

                if(spawnedTowerSlot.name == "Tower Slot 11 8" || spawnedTowerSlot.name == "Tower Slot 12 8"
                || spawnedTowerSlot.name == "Tower Slot 0 7" || spawnedTowerSlot.name == "Tower Slot 0 8"
                || spawnedTowerSlot.name == "Tower Slot 1 7" || spawnedTowerSlot.name == "Tower Slot 1 8"){
                    spawnedTowerSlot.SetActive(false);
                }

                // 06 16 26 36 46 56 66 76 86 96 106
                for(int k = 0; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 6"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 52 53 54 55 56 57 58
                for(int k = 2; k <= 8; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 5 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);                    }
                }

                // 62 72 82 92 102
                for(int k = 6; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 2"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }

                // 112 113 114 115 116
                for(int k = 2; k <= 6; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 11 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
            }
        }
    }
}
