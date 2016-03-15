using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBallsType : MonoBehaviour {

    public int type;
    public int number;
    public Sprite sprite;    

    private Image image;
    
	void Start () {
        image = GetComponent<Image>();

        image.sprite = sprite;
        
    }


    
	
}
