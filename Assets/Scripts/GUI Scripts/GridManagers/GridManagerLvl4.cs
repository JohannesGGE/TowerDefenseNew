using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLvl4 : MonoBehaviour{
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
                // 111 112 113 114 115 116
                for(int k = 1; k <= 6; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 11 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 71 81 91 101
                for(int k = 7; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 1"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 61 62 63
                for(int k = 1; k <= 3; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 6 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 13 23 33 43 53
                for(int k = 1; k < 6; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 3"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 10 11 12
                for(int k = 0; k < 3; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 1 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
            }
        }
    }
}
