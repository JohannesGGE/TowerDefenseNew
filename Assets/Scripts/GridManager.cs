using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{
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

                
                for(int i = 3; i <= 8; i++){
                    if(spawnedTile.name == $"Tile {i} 7"){
                        spawnedTile.setIsGrass(false);
                    }
                }

                if(spawnedTile.name == "Tile 3 6" || spawnedTile.name == "Tile 8 6" || spawnedTile.name == "Tile 6 2" || spawnedTile.name == "Tile 11 2" || spawnedTile.name == "Tile 6 0"){
                    spawnedTile.setIsGrass(false);
                }

                for(int i = 2; i <= 4; i++){
                    if(spawnedTile.name == $"Tile 3 {i}"){
                        spawnedTile.setIsGrass(false);
                    }
                }

                for(int i = 0; i <= 8; i++){
                    if(spawnedTile.name == $"Tile {i} 5"){
                        spawnedTile.setIsGrass(false);
                    }
                }

                for(int i = 6; i <= 11; i++){
                    if(spawnedTile.name == $"Tile {i} 3"){
                        spawnedTile.setIsGrass(false);
                    }
                }

                for(int i = 3; i <= 11; i++){
                    if(spawnedTile.name == $"Tile {i} 1"){
                        spawnedTile.setIsGrass(false);
                    }
                }
                
            }
        }


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
