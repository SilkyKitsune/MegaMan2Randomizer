namespace MM2Randomizer;

internal enum Equipment : byte
{
    None = 0x00,

    AtomicFire = 0x01,
    AirShooter = 0x02,
    LeafShield = 0x04,
    BubbleLead = 0x08,
    QuickBoomerang = 0x10,
    FlashStopper = 0x20,
    MetalBlade = 0x40,
    CrashBomber = 0x80,

    Item1 = AtomicFire,
    Item2 = AirShooter,
    Item3 = LeafShield
}