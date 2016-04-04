using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBallsType : MonoBehaviour
{

    public static int BALL_TYPE_FULL_FILL = 0;
    public static int BALL_TYPE_HALF_FILL = 1;
    public static int BALL_TYPE_BLACK = 2;
    public static int BALL_TYPE_WHITE = 4;


    public int type;
    public int number;
    public Sprite sprite;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        image.sprite = sprite;

    }




}
