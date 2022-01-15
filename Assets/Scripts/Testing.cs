using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour{

    private Grid grid;

    private void Start(){
        grid = new Grid(13, 9, 120f, new Vector3(-960, -540));
    }
}
