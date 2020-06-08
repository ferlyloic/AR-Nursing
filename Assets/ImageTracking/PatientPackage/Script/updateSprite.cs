using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateSprite : MonoBehaviour
{

    //public string name;
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    //private Selectable selectable;
    private ARNursingGame checkGame;

    // Start is called before the first frame update
    void Start()
    {
        //List<List<string>> deck = ARNursingGame.GenerateDeck();
        //checkGame = FindObjectOfType<ARNursingGame>();

        //int i = 0;
        //foreach (List<string> card in deck)
        //{
        //    //print("update sprite: " + this.name);
        //    if (this.name == card[1])
        //    {
        //        cardFace = checkGame.cardFaces[i];
        //        break;
        //    }
        //    i++;
        //}
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (selectable.faceUp)
        //{
        //    spriteRenderer.sprite = cardFace;
        //}
        //else{
        //    spriteRenderer.sprite = cardBack;
        //}
    }
}
