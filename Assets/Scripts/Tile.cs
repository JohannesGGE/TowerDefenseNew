using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    private bool _isGrass = true;


    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlightGreen;
    [SerializeField] private GameObject _highlightRed;


    public void Init(bool isOffset){
        _renderer.color = isOffset ?  _offsetColor : _baseColor;
    }

    private void OnMouseEnter(){
        if(this._isGrass){
            _highlightGreen.SetActive(true);
        } else{
            _highlightRed.SetActive(true);
        }
    }

   private void OnMouseExit(){
        _highlightGreen.SetActive(false);
        _highlightRed.SetActive(false);
    }

    public bool getIsGrass(){
        return this._isGrass;
    }

    public void setIsGrass(bool x){
        this._isGrass = x;
    }
}
