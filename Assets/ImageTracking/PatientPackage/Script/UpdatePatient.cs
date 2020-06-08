using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCard : MonoBehaviour
{
    public GameObject defaultCard;
    public GameObject face;
    //public GameObject back;
    public Sprite faceSprite;

    private SpriteRenderer spriteRenderer;
    //private Selectable selectable;
    private ARNursingGame checkGame;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject face = this.transform.GetChild(1).gameObject;
        print(defaultCard.transform.GetChild(0).gameObject);
        //List<string> deck = CheckGame.GenerateDeck();
        //checkGame = Find*ObjectOfType<CheckGame>();

        //print("Card name: " + this.name);
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //int i = 0;
        //foreach (string card in deck)
        //{
        //    print("update sprite: " + this.name);
        //    if (this.name == card)
        //    {

        //        faceSprite = checkGame.cardFaces[i];

        //        print(faceSprite);
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
        
        //spriteRenderer.sprite = faceSprite;
        //if (selectable.faceUp)
        //{
        //    // do nothing...
        //}
        //else
        //{
        //    transform.Rotate(new Vector3(0, 90, 0));
        //}
    }
}
