using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLvl3 : MonoBehaviour{
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

                // 06 16 26
                for(int k = 0; k <= 2; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 6"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 21 22 23 24 25
                for(int k = 1; k < 6; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 2 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 31 41 51 61
                for(int k = 3; k < 7; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 1"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 71 72
                for(int k = 1; k < 3; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 7 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }   
                // 73 83 93 103
                for(int k = 7; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 3"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 113 114 115
                for(int k = 3; k < 6; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 11 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 86 96 106 116
                for(int k = 8; k <= 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 6"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 76 77 78
                for(int k = 6; k <= 8; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 7 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
            }
        }
    }
}
