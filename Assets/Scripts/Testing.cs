using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour{

    private Grid grid;

    private void Start(){
        grid = new Grid(20, 11, 2f, new Vector3(0, 0));
    }
}
