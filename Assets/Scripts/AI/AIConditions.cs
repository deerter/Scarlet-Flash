
[System.Flags]
public enum AIConditions
{
    timer = 1,   /// If exists -> timer < 20sec ; Not exists -> timer > 20 sec || Infinite
    distance = 2,  /// If exists -> distance is close (in-close || poke-range) ; Not exists -> distance is far (mid-screen || full-screen)
    characterHealth = 4,  /// If exists -> character health is low ; Not exists ->  character health is high
    characterStateAir = 8  /// If exists -> character is in the air ; Not exists -> character is in the ground
}