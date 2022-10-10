public class CandleManager : ObjectInteractable
{
    public static bool fuelUsedUp;

    public override void Awake()
    {
        base.Awake();  //creates player var, stores the gameObject of the Player
        fuelUsedUp = false;
    }
}
