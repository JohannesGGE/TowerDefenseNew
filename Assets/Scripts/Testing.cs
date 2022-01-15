using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour{

    private Grid grid;

    private void Start(){
        grid = new Grid(13, 9, 1.2f, new Vector3(-.6f, -.4f));
    }
}
