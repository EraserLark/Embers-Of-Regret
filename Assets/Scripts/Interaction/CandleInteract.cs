using UnityEngine;

public class CandleInteract : CandleManager    // CandleManager << ObjectInteractable << Monobehavior
{
    public GameObject flame;
    AudioSource candleSource;

    Transform candleTransform;

    public override void Awake()
    {
        base.Awake(); //creates player var, stores the gameObject of the Player
        flame = gameObject.transform.GetChild(0).gameObject; 
        candleTransform = gameObject.transform;
        candleSource = gameObject.GetComponent<AudioSource>();
    }

    public override void Selected()
    {
        if(!fuelUsedUp)
        {
            state = true;

            flame.SetActive(state);
            MonsterFollow2.candleLit = state;   //Monster will track player's position(false) or candle(true)
            fuelUsedUp = state;                 //Player cannot light another candle
            float flameTimer = Random.Range(3.0f, 10.0f);     //Number of seconds until the flame extinguishes

            MonsterFollow2.monsterTargetPosition = candleTransform.position;
            Invoke("Extinguish", flameTimer);
        }
        else
        {
            candleSource.Play();   //Out of fuel, Play extinguish sfx
        }
    }

    void Extinguish()
    {
        state = false;
        flame.SetActive(state);
        MonsterFollow2.candleLit = state;   //Determines if monster will track player's position(false) or candle(true)
        fuelUsedUp = state;                 //Player can light another candle

        candleSource.Play();   //Play extinguish sfx
    }
}
