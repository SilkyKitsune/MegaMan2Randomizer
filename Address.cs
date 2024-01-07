namespace MM2Randomizer;

internal enum Address : int
{
    BoomBeamCrashWall0 = 0xFAE6,
    BoomBeamCrashWall1 = 0xFAE7,
    BoomBeamCrashWall2 = 0xFAE8,
    BoomBeamCrashWall3 = 0xFAE9,
    BoomBeamCrashWall4 = 0xFAEA,

    RobotHealthFillSpeed = 0x02C142,
    CastleHealthFillSpeed = 0x02E12B,
    PlayerHealthFillSpeedPaused = 0x0352B2,
    PlayerHealthFillSpeed = 0x03831B,
    PlayerWeaponFillSpeed = 0x03835A,

    MaxETanks = 0x038382,

    HeatStageWeapon = 0x03C289,
    AirStageWeapon = 0x03C28A,
    WoodStageWeapon = 0x03C28B,
    BubbleStageWeapon = 0x03C28C,
    QuickStageWeapon = 0x03C28D,
    FlashStageWeapon = 0x03C28E,
    MetalStageWeapon = 0x03C28F,
    CrashStageWeapon = 0x03C290,

    HeatStageItem = 0x03C291,
    AirStageItem = 0x03C292,
    WoodStageItem = 0x03C293,
    BubbleStageItem = 0x03C294,
    QuickStageItem = 0x03C295,
    FlashStageItem = 0x03C296,
    MetalStageItem = 0x03C297,
    CrashStageItem = 0x03C298,

    BubbleStagePtr = 0x034670,
    AirStagePtr = 0x034671,
    QuickStagePtr = 0x034672,
    WoodStagePtr = 0x034673,
    CrashStagePtr = 0x034674,
    FlashStagePtr = 0x034675,
    MetalStagePtr = 0x034676,
    HeatStagePtr = 0x034677,

    WilyStage1Ptr = 0x0340E3,

    WilyMapTime = 0x035994,

    WeaponGetTime = 0x037B95,
    MenuFlashTime = 0x037C8C,
    ItemGetTime = 0x037D07,
    TextPrintSpeed = 0x037D4A,
    PausePrintTime = 0x037DBC,

    LevelCheckRoutine1 = 0x0340D8,
    LevelCheckRoutine2First = 0x0340EC,
    LevelCheckRoutine2MemAddress = 0x0340ED,
    LevelCheckRoutine2Last = 0x0340EF,

    WilyCheckRoutine1First = 0x038076,
    StagesRequiredForWily1 = 0x038079,
    WilyCheckRoutine1Last = 0x03807D,

    WilyCheckRoutine2First = 0x03C264,
    StagesRequiredForWily2 = 0x03C267,
    WilyCheckRoutine2Last = 0x03C269,
}