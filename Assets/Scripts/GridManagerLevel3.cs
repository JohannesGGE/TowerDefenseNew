using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLevel3 : MonoBehaviour{
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

                // 06 16 26
                for(int i = 0; i <= 2; i++){if(spawnedTile.name == $"Tile {i} 6"){spawnedTile.setIsGrass(false);}}

                // 21 22 23 24 25
                for(int i = 1; i < 6; i++){if(spawnedTile.name == $"Tile 2 {i}"){spawnedTile.setIsGrass(false);}}

                // 31 41 51 61
                for(int i = 3; i < 7; i++){if(spawnedTile.name == $"Tile {i} 1"){spawnedTile.setIsGrass(false);}}

                // 71 72
                for(int i = 1; i < 3; i++){if(spawnedTile.name == $"Tile 7 {i}"){spawnedTile.setIsGrass(false);}}
                
                // 73 83 93 103
                for(int i = 7; i < 11; i++){if(spawnedTile.name == $"Tile {i} 3"){spawnedTile.setIsGrass(false);}}

                // 113 114 115
                for(int i = 3; i < 6; i++){if(spawnedTile.name == $"Tile 11 {i}"){spawnedTile.setIsGrass(false);}}

                // 86 96 106 116
                for(int i = 8; i <= 11; i++){if(spawnedTile.name == $"Tile {i} 6"){spawnedTile.setIsGrass(false);}}

                // 76 77 78
                for(int i = 6; i <= 8; i++){if(spawnedTile.name == $"Tile 7 {i}"){spawnedTile.setIsGrass(false);}}
            }
        }


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
