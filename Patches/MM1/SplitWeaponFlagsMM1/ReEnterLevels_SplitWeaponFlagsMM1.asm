; i think these mapped addresses are incorrect because the disassembler assumed them to always be $8000-$BFFF
; i don't think this is true anymore since $C000-$FFFF is fixed on unrom and that bank is definitely mapped to 0x01_C000-0x01_FFFF

RobotBitField =  $5D
WeaponBitField = $FB ; new bitfield for storing weapon flags separately from robot flags

RobotBitMasks =  $C148
WeaponBitMasks = $FF00 ; (0x01_FF10) new bitmasks used for shuffled weapons

SetWeaponBitField = $FF06
SetMagnetFields =   $FF13



; New Instructions
; -----------------------------------------------------
  ; replace bitmask loading to be like mm2
JMP SetWeaponBitField ; 4C 06 FF    ; $C125 ; 0x01_C135
ORA RobotBitfield     ; 05 5D       ; $C128 ; 0x01_C138
; .....................................................
  ; replace magnet beam 5D address
JMP SetMagnetFields   ; 4C 13 FF    ; $C873 ; 0x01_C883 ; ORA WeaponBitField    ; 05 FB       ; $C875 ; 0x01_C885 ; old
NOP                   ; EA          ; $C876 ; 0x01_C886 ; STA WeaponBitField    ; 85 FB       ; $C877 ; 0x01_C887
; .....................................................
  ; new code to jump to
LDA WeaponBitMask,X   ; BD 00 FF    ; $FF06 ; 0x01_FF16
ORA WeaponBitField    ; 05 FB       ; $FF09 ; 0x01_FF19
STA WeaponBitField    ; 85 FB       ; $FF0B ; 0x01_FF1B
LDA RobotBitMasks,X   ; BD 48 C1    ; $FF0D ; 0x01_FF1D
JMP $C128             ; 4C 28 C1    ; $FF10 ; 0x01_FF20

LDA #$80              ; A9 80       ; $FF13 ; 0x01_FF23
ORA WeaponBitField    ; 05 FB       ; $FF15 ; 0x01_FF25
STA WeaponBitField    ; 85 FB       ; $FF17 ; 0x01_FF27
LDA #$80              ; A9 80       ; $FF19 ; 0x01_FF29
ORA RobotBitField     ; 05 5D       ; $FF1B ; 0x01_FF2B
JMP $C877             ; 4C 77 C8    ; $FF1D ; 0x01_FF2D



; Instructions JP   ; Bytes JP    ; Mapped Addr JP ; File Addr JP ; Comments
; -------------------------------------------------
LDA RobotBitField   ; A5 5D       ; $B11F          ; 0x01_B12F    ; pause menu
STA $5A             ; 85 5A       ; $B121          ; 0x01_B131
LDX #$00            ; A2 00       ; $B123          ; 0x01_B133
STX $59             ; 86 59       ; $B125          ; 0x01_B135
LDA #$00            ; A9 00       ; $B127          ; 0x01_B137
STA $0D             ; 85 0D       ; $B129          ; 0x01_B139
JSR $CE9A           ; 20 9A CE    ; $B12B          ; 0x01_B13B
LDX #$12            ; A2 12       ; $B12E          ; 0x01_B13E
JSR $CF06           ; 20 06 CF    ; $B130          ; 0x01_B140
LDY $31             ; A4 31       ; $B133          ; 0x01_B143
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B193          ; 0x01_B1A3    ; pause menu
AND $B50D,X         ; 3D 0D B5    ; $B195          ; 0x01_B1A5
BEQ $52             ; F0 52       ; $B198          ; 0x01_B1A8    ; branch to $B1EC
TXA                 ; 8A          ; $B19A          ; 0x01_B1AA
ASL                 ; 0A          ; $B19B          ; 0x01_B1AB
TAX                 ; AA          ; $B19C          ; 0x01_B1AC
LDA $B4E7,X         ; BD E7 B4    ; $B19D          ; 0x01_B1AD
STA $0E             ; 85 0E       ; $B1A0          ; 0x01_B1B0
LDA $006A,Y         ; B9 6A 00    ; $B1A2          ; 0x01_B1B2
PHA                 ; 48          ; $B1A5          ; 0x01_B1B5
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B294          ; 0x01_B2A4    ; pause menu selection changed? up pressed
AND $B50D,Y         ; 39 0D B5    ; $B296          ; 0x01_B2A6
BEQ $EE             ; F0 EE       ; $B299          ; 0x01_B2A9    ; branch to $B289
BNE $12             ; D0 12       ; $B29B          ; 0x01_B2AB    ; branch to $B2AF
INC $5F             ; E6 5F       ; $B29D          ; 0x01_B2AD
LDA $5F             ; A5 5F       ; $B29F          ; 0x01_B2AF
AND #$07            ; 29 07       ; $B2A1          ; 0x01_B2B1
STA $5F             ; 85 5F       ; $B2A3          ; 0x01_B2B3
BEQ $08             ; F0 08       ; $B2A5          ; 0x01_B2B5    ; branch to $B2AF
TAY                 ; A8          ; $B2A7          ; 0x01_B2B7
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B2A8          ; 0x01_B2B8    ; pause menu selection changed? down pressed
AND $B50D,Y         ; 39 0D B5    ; $B2AA          ; 0x01_B2BA
BEQ $EE             ; F0 EE       ; $B2AD          ; 0x01_B2BD    ; branch to $B29D
LDA #$1F            ; A9 1F       ; $B2AF          ; 0x01_B2BF
JSR $C477           ; 20 77 C4    ; $B2B1          ; 0x01_B2C1
JMP $B248           ; 4C 48 B2    ; $B2B4          ; 0x01_B2C4
LDX $5F             ; A6 5F       ; $B2B7          ; 0x01_B2C7
LDA $B517,X         ; BD 17 B5    ; $B2B9          ; 0x01_B2C9
STA $5F             ; 85 5F       ; $B2BC          ; 0x01_B2CC
LDY #$04            ; A0 04       ; $B2BE          ; 0x01_B2CE
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B40B          ; 0x01_B41B    ; pause menu
ORA #$01            ; 09 01       ; $B40D          ; 0x01_B41D
AND $B50D,X         ; 3D 0D B5    ; $B40F          ; 0x01_B41F
BEQ $29             ; F0 29       ; $B412          ; 0x01_B422    ; branch to $B43D
LDA $0D             ; A5 0D       ; $B414          ; 0x01_B424
ASL                 ; 0A          ; $B416          ; 0x01_B426
TAY                 ; A8          ; $B417          ; 0x01_B427
LDA $B4FB,X         ; BD FB B4    ; $B418          ; 0x01_B428
TAX                 ; AA          ; $B41B          ; 0x01_B42B
LDA $B4E7,Y         ; B9 E7 B4    ; $B41C          ; 0x01_B42C
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B5B0          ; 0x01_B5C0    ; stage select
AND $BFC4,X         ; 3D C4 BF    ; $B5B2          ; 0x01_B5C2
STA $0E             ; 85 0E       ; $B5B5          ; 0x01_B5C5
LDY #$00            ; A0 00       ; $B5B7          ; 0x01_B5C7
LDA $05             ; A5 05       ; $B5B9          ; 0x01_B5C9
STA $2006           ; 8D 06 20    ; $B5BB          ; 0x01_B5CB
LDA $04             ; A5 04       ; $B5BE          ; 0x01_B5CE
STA $2006           ; 8D 06 20    ; $B5C0          ; 0x01_B5D0
LDX #$06            ; A2 06       ; $B5C3          ; 0x01_B5D3
LDA $0C             ; A5 0C       ; $B5C5          ; 0x01_B5D5
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B634          ; 0x01_B644    ; stage select
AND #$7E            ; 29 7E       ; $B636          ; 0x01_B646
CMP #$7E            ; C9 7E       ; $B638          ; 0x01_B648
BNE $08             ; D0 08       ; $B63A          ; 0x01_B64A    ; branch to $B644
LDA $0C             ; A5 0C       ; $B63C          ; 0x01_B64C
CMP #$07            ; C9 07       ; $B63E          ; 0x01_B64E
BEQ $0B             ; F0 0B       ; $B640          ; 0x01_B650    ; branch to $B64D
BNE $06             ; D0 06       ; $B642          ; 0x01_B652    ; branch to $B64A
LDA $0C             ; A5 0C       ; $B644          ; 0x01_B654
CMP #$06            ; C9 06       ; $B646          ; 0x01_B656
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B65D          ; 0x01_B66D    ; stage select
AND #$7E            ; 29 7E       ; $B65F          ; 0x01_B66F
CMP #$7E            ; C9 7E       ; $B661          ; 0x01_B671
BEQ $21             ; F0 21       ; $B663          ; 0x01_B673    ; branch to $B686
LDY #$04            ; A0 04       ; $B665          ; 0x01_B675
LDX #$00            ; A2 00       ; $B667          ; 0x01_B677
LDA $BFA4,X         ; BD A4 BF    ; $B669          ; 0x01_B679
STA $2006           ; 8D 06 20    ; $B66C          ; 0x01_B67C
INX                 ; E8          ; $B66F          ; 0x01_B67F
LDA $BFA4,X         ; BD A4 BF    ; $B670          ; 0x01_B680
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B693          ; 0x01_B6A3    ; stage select
AND #$08            ; 29 08       ; $B695          ; 0x01_B6A5
BEQ $0D             ; F0 0D       ; $B697          ; 0x01_B6A7    ; branch to $B6A6
LDA #$D3            ; A9 D3       ; $B699          ; 0x01_B6A9
STA $35             ; 85 35       ; $B69B          ; 0x01_B6AB
LDA #$BD            ; A9 BD       ; $B69D          ; 0x01_B6AD
STA $36             ; 85 36       ; $B69F          ; 0x01_B6AF
LDA #$10            ; A9 10       ; $B6A1          ; 0x01_B6B1
JSR $D647           ; 20 47 D6    ; $B6A3          ; 0x01_B6B3
LDY #$00            ; A0 00       ; $B6A6          ; 0x01_B6B6
; ...................................................
LDA RobotBitField   ; A5 5D       ; $B739          ; 0x01_B749    ; stage select
AND #$7E            ; 29 7E       ; $B73B          ; 0x01_B74B
CMP #$7E            ; C9 7E       ; $B73D          ; 0x01_B74D
BNE $05             ; D0 05       ; $B73F          ; 0x01_B74F    ; branch to $B746
CLC                 ; 18          ; $B741          ; 0x01_B751
TYA                 ; 98          ; $B742          ; 0x01_B752
ADC #$0C            ; 69 0C       ; $B743          ; 0x01_B753
TAY                 ; A8          ; $B745          ; 0x01_B755
LDA $BEA8,Y         ; B9 A8 BE    ; $B746          ; 0x01_B756
STA $31             ; 85 31       ; $B749          ; 0x01_B759
; ...................................................
LDA RobotBitField   ; A5 5D       ; $BB31          ; 0x01_BB41    ; stage select
AND #$7E            ; 29 7E       ; $BB33          ; 0x01_BB43
CMP #$7E            ; C9 7E       ; $BB35          ; 0x01_BB45
BNE $04             ; D0 04       ; $BB37          ; 0x01_BB47    ; branch to $BB3D
LDA #$86            ; A9 86       ; $BB39          ; 0x01_BB49
BNE $02             ; D0 02       ; $BB3B          ; 0x01_BB4B    ; branch to $BB3F
LDA #$8A            ; A9 8A       ; $BB3D          ; 0x01_BB4D
STA $1C             ; 85 1C       ; $BB3F          ; 0x01_BB4F
RTS                 ; 60          ; $BB41          ; 0x01_BB51
STA $0420           ; 8D 20 04    ; $BB42          ; 0x01_BB52

; ...................................................

LDA RobotBitField   ; A5 5D       ; $C125          ; 0x01_C135    ; Load robot bitfield
ORA RobotBitMasks,X ; 1D 48 C1    ; $C127          ; 0x01_C137    ; Or with robot bitmask at X
STA RobotBitField   ; 85 5D       ; $C12A          ; 0x01_C13A    ; Write new value to robot bitfield
LDA #$00            ; A9 00       ; $C12C          ; 0x01_C13C
STA $BC             ; 85 BC       ; $C12E          ; 0x01_C13E
STA $55             ; 85 55       ; $C130          ; 0x01_C140
STA $68             ; 85 68       ; $C132          ; 0x01_C142
JMP $905A           ; 4C 5A 90    ; $C134          ; 0x01_C144
INC $31             ; E6 31       ; $C137          ; 0x01_C147
DEC $BB             ; C6 BB       ; $C139          ; 0x01_C149
LDA #$00            ; A9 00       ; $C13B          ; 0x01_C14B
STA $B4             ; 85 B4       ; $C13D          ; 0x01_C14D
; ...................................................
LDA #$80            ; A9 80       ; $C873          ; 0x01_C883    ; Load magnet beam bitmask
ORA RobotBitField   ; 05 5D       ; $C875          ; 0x01_C885    ; Or with robot bitfield
STA RobotBitField   ; 85 5D       ; $C877          ; 0x01_C887    ; Write new value to robot bitfield
LDA #$1C            ; A9 1C       ; $C879          ; 0x01_C889
STA $71             ; 85 71       ; $C87B          ; 0x01_C88B
LDA #$1A            ; A9 1A       ; $C87D          ; 0x01_C88D
JSR $C477           ; 20 77 C4    ; $C87F          ; 0x01_C88F
RTS                 ; 60          ; $C882          ; 0x01_C892