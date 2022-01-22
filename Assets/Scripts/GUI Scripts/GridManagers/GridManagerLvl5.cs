using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLvl5 : MonoBehaviour{
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

                // 05 15 25 35 45 55 65 75
                for(int k = 0; k < 8; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 5"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 85 86 87
                for(int k = 5; k <= 7; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 8 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 37 47 57 67 77
                for(int k = 3; k < 8; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 7"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 31 32 33 34 35 36
                for(int k = 1; k < 7; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 3 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 41 51 61 71 81 91 101
                for(int k = 4; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 1"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 111 112 113
                for(int k = 1; k <= 3; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 11 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 63 73 83 93 103
                for(int k = 6; k < 11; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot {k} 3"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
                // 60 61 62
                for(int k = 0; k < 3; k++){
                    if(spawnedTowerSlot.name == $"Tower Slot 6 {k}"){
                        spawnedTowerSlot.GetComponent<Drop>().SetIsGrass(false);
                    }
                }
            }
        }
    }
}
