using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLevel5 : MonoBehaviour{
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

                // 05 15 25 35 45 55 65 75
                for(int i = 0; i < 8; i++){if(spawnedTile.name == $"Tile {i} 5"){spawnedTile.setIsGrass(false);}}

                // 85 86 87
                for(int i = 5; i <= 7; i++){if(spawnedTile.name == $"Tile 8 {i}"){spawnedTile.setIsGrass(false);}}

                // 37 47 57 67 77
                for(int i = 3; i < 8; i++){if(spawnedTile.name == $"Tile {i} 7"){spawnedTile.setIsGrass(false);}}

                // 31 32 33 34 35 36
                for(int i = 1; i < 7; i++){if(spawnedTile.name == $"Tile 3 {i}"){spawnedTile.setIsGrass(false);}}

                // 41 51 61 71 81 91 101
                for(int i = 4; i < 11; i++){if(spawnedTile.name == $"Tile {i} 1"){spawnedTile.setIsGrass(false);}}

                // 111 112 113
                for(int i = 1; i <= 3; i++){if(spawnedTile.name == $"Tile 11 {i}"){spawnedTile.setIsGrass(false);}}

                // 63 73 83 93 103
                for(int i = 6; i < 11; i++){if(spawnedTile.name == $"Tile {i} 3"){spawnedTile.setIsGrass(false);}}

                // 60 61 62
                for(int i = 0; i < 3; i++){if(spawnedTile.name == $"Tile 6 {i}"){spawnedTile.setIsGrass(false);}}
            }
        }


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
