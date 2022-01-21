using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLvl1 : MonoBehaviour{
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

                // 04 14 24
                for(int k = 0; k <= 2; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 4"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 23
                if(spawnedTowerSlot.name == "Tower Slot 2 3"){
                    spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                }
                // 22 32 42 52 62 72 82
                for(int k = 2; k < 9; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 2"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 92 93 94 95 96 97 98
                for(int k = 2; k <= 8; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 9 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                 }
            }
        }
    }
}
