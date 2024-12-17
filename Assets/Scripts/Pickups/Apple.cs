using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 1.0f;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
        Debug.Log("Power Up");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        
    }
}
