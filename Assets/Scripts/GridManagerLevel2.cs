using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLevel2 : MonoBehaviour{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    void Start(){
        GenerateGrid();
    }

    void GenerateGrid(){
        for(int x = 0; x < _width; x++){
            for(int y = 0; y < _height; y++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(1.2f * x, 1.2f * y + .2f), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                // 06 16 26 36 46 56 66 76 86 96 106
                for(int i = 0; i < 11; i++){if(spawnedTile.name == $"Tile {i} 6"){spawnedTile.setIsGrass(false);}}

                // 52 53 54 55 56 57 58
                for(int i = 2; i <= 8; i++){if(spawnedTile.name == $"Tile 5 {i}"){spawnedTile.setIsGrass(false);}}

                // 62 72 82 92 102
                for(int i = 6; i < 11; i++){if(spawnedTile.name == $"Tile {i} 2"){spawnedTile.setIsGrass(false);}}

                // 112 113 114 115 116
                for(int i = 2; i <= 6; i++){if(spawnedTile.name == $"Tile 11 {i}"){spawnedTile.setIsGrass(false);}}
            }
        }


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
