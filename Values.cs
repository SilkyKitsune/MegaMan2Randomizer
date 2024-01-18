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

internal enum StageIndex : byte
{
    HeatStage = 0x00,
    AirStage = 0x01,
    WoodStage = 0x02,
    BubbleStage = 0x03,
    QuickStage = 0x04,
    FlashStage = 0x05,
    MetalStage = 0x06,
    CrashStage = 0x07,

    WilyStage1 = 0x08,
    //not sure where wily 2 is
    WilyStage3 = 0x0A,
    WilyStage4 = 0x0B,
    WilyStage5 = 0x0C,//rematches
    WilyStage6 = 0x0D,

    TitleScreen = 0x09
}

internal enum Pickups : byte
{
    BigWeapon = 0x78,
    ETank = 0x7A,
    OneUp = 0x7E
}
