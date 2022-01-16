using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLevel4 : MonoBehaviour{
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

                // 111 112 113 114 115 116
                for(int i = 1; i <= 6; i++){if(spawnedTile.name == $"Tile 11 {i}"){spawnedTile.setIsGrass(false);}}

                // 71 81 91 101
                for(int i = 7; i < 11; i++){if(spawnedTile.name == $"Tile {i} 1"){spawnedTile.setIsGrass(false);}}

                // 61 62 63
                for(int i = 1; i <= 3; i++){if(spawnedTile.name == $"Tile 6 {i}"){spawnedTile.setIsGrass(false);}}

                // 13 23 33 43 53
                for(int i = 1; i < 6; i++){if(spawnedTile.name == $"Tile {i} 3"){spawnedTile.setIsGrass(false);}}

                // 10 11 12
                for(int i = 0; i < 3; i++){if(spawnedTile.name == $"Tile 1 {i}"){spawnedTile.setIsGrass(false);}}
            }
        }


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
