using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerLevel1 : MonoBehaviour{
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
                
                // 04 14 24
                for(int i = 0; i <= 2; i++){if(spawnedTile.name == $"Tile {i} 4"){spawnedTile.setIsGrass(false);}}

                // 23
                if(spawnedTile.name == "Tile 2 3"){spawnedTile.setIsGrass(false);}

                // 22 32 42 52 62 72 82
                for(int i = 2; i < 9; i++){if(spawnedTile.name == $"Tile {i} 2"){spawnedTile.setIsGrass(false);}}

                // 92 93 94 95 96 97 98
                for(int i = 2; i <= 8; i++){if(spawnedTile.name == $"Tile 9 {i}"){spawnedTile.setIsGrass(false);}}
            }
        }

        


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
