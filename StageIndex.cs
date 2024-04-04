namespace MM2Randomizer;

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