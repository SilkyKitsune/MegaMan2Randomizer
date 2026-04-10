; Just fyi idk if this will work in an assembler, it was hand assembled/disassembled

WeaponBitField = $99 ; new bitfield for storing weapon flags
RobotBitField =  $9A
ItemBitField =   $9B

RobotBitMasks =  $C279
ItemBitMasks =   $C281
WeaponBitMasks = $F2E8          ; 0x03_F2_F8 ; new bitmasks used for shuffled weapons

SetWeaponBitField = $F2F0

; This includes all the times a LDA/STA opcode is called for the address $009A
; Gaps in code are indicated by a line of periods -> '.'
Instructions JP      ; Bytes JP ; Instructions NA     ; Bytes NA ; File Addr JP ; File Addr NA ;                       ;          ; Comments
--------------------------------------------------------------------------------------------------------------------------------------------
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_403B    ;              ;                       ;          ; ???
STA $01              ; 85 01    ;                     ;          ;              ;              ;                       ;          ;
STX $00              ; 86 00    ;                     ;          ;              ;              ;                       ;          ;
LSR $01              ; 46 01    ;                     ;          ;              ;              ;                       ;          ;
BCC $2C              ; 90 2C    ;                     ;          ;              ;              ;                       ;          ;
LDA $8531,X          ; BD 31 85 ;                     ;          ;              ;              ;                       ;          ;
STA $09              ; 85 09    ;                     ;          ;              ;              ;                       ;          ;
LDA $8539,X          ; BD 39 85 ;                     ;          ;              ;              ;                       ;          ;
STA $08              ; 85 08    ;                     ;          ;              ;              ;                       ;          ;
LDX #$04             ; A2 04    ;                     ;          ;              ;              ;                       ;          ;
LDA #$00             ; A9 00    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_4082    ;              ;                       ;          ; every stage select load
STA $02              ; 85 02    ;                     ;          ;              ;              ;                       ;          ;
LDY #$00             ; A0 00    ;                     ;          ;              ;              ;                       ;          ;
STX $01              ; 86 01    ;                     ;          ;              ;              ;                       ;          ;
LSR $02              ; 46 02    ;                     ;          ;              ;              ;                       ;          ;
BCS $15              ; B0 15    ;                     ;          ;              ;              ;                       ;          ;
LDA $8605,X          ; BD 05 86 ;                     ;          ;              ;              ;                       ;          ;
STA $00              ; 85 00    ;                     ;          ;              ;              ;                       ;          ;
LDA $85FD,X          ; BD FD 85 ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDX $2A              ; A6 2A    ;                     ;          ; 0x03_40D8    ;              ;                       ;          ;
BNE $0D              ; D0 0D    ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_40DC    ;              ;                       ;          ; first stage select load, maybe others
CMP #$FF             ; C9 FF    ;                     ;          ;              ;              ;                       ;          ;
BNE $ED              ; D0 ED    ;                     ;          ;              ;              ;                       ;          ;
LDA #$08             ; A9 08    ;                     ;          ;              ;              ;                       ;          ; index of wily stage 1, this might actually be the placement of the cursor
STA $2A              ; 85 2A    ;                     ;          ;              ;              ;                       ;          ;
JMP $829A            ; 4C 9A 82 ;                     ;          ;              ;              ;                       ;          ;
LDY $865F,X          ; BC 5F 86 ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_40EC    ;              ;                       ;          ; stage chosen (ReEnterLevels.ips)
AND $86D1,Y          ; 39 D1 86 ;                     ;          ;              ;              ;                       ;          ;
BNE $DC	             ; D0 DC    ;                     ;          ;              ;              ;                       ;          ;
STY $2A	             ; 84 2A    ;                     ;          ;              ;              ;                       ;          ;
LDA #$3A             ; A9 3A    ;                     ;          ;              ;              ;                       ;          ;
JSR $C051            ; 20 51 C0 ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_51FF    ;              ;                       ;          ; pause menu close (SplitWeaponFlags.ips)
ASL A                ; 0A       ;                     ;          ;              ;              ;                       ;          ;
ORA #$41             ; 09 41    ;                     ;          ;              ;              ;                       ;          ;
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA $FE              ; A5 FE    ;                     ;          ;              ;              ;                       ;          ;
BEQ $11              ; F0 11    ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_520A    ;              ;                       ;          ; pause menu page 2, run continuously (SplitWeaponFlags.ips)
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA ItemBitField     ; A5 9B    ;                     ;          ;              ;              ;                       ;          ;
ASL $07              ; 06 07    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
ASL $07              ; 06 07    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA $27              ; A5 27    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_53BF    ;              ;                       ;          ; pause menu page 1, run continuously (SplitWeaponFlags.ips)
ASL A                ; 0A       ;                     ;          ;              ;              ;                       ;          ;
ORA #$01             ; 09 01    ;                     ;          ;              ;              ;                       ;          ;
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA #$05             ; A9 05    ;                     ;          ;              ;              ;                       ;          ;
STA $01              ; 85 01    ;                     ;          ;              ;              ;                       ;          ;
LDX #$00             ; A2 00    ;                     ;          ;              ;              ;                       ;          ;
LDA $FE              ; A5 FE    ;                     ;          ;              ;              ;                       ;          ;
BEQ $13              ; F0 13    ;                     ;          ;              ;              ;                       ;          ;
LDX #$06             ; A2 06    ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_53D2    ;              ;                       ;          ; pause menu page 2, run continuously (SplitWeaponFlags.ips)
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA ItemBitField     ; A5 9B    ;                     ;          ;              ;              ;                       ;          ;
ASL $07              ; 06 07    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
ASL $07              ; 06 07    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
ASL $07              ; 06 07    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
STA $07              ; 85 07    ;                     ;          ;              ;              ;                       ;          ;
LDA $07              ; A5 07    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
JSR $A974            ; 20 74 A9 ; JSR $A9B2           ; 20 B2 A9 ; 0x03_62EC    ;              ;                       ;          ;
LDA #$00             ; A9 00    ;                     ;          ;              ;              ;                       ;          ;
STA $FD              ; 85 FD    ;                     ;          ;              ;              ;                       ;          ;
STA RobotBitField    ; 85 9A    ;                     ;          ; 0x03_62F3    ; 0x03_6325    ;                       ;          ; I think is set at start/password screen
STA ItemBitField     ; 85 9B    ;                     ;          ;              ;              ;                       ;          ;
LDX #$03             ; A2 03    ;                     ;          ;              ;              ;                       ;          ;
LDA $AEE0,X          ; BD E0 AE ; LDA $AFC7,X         ; BD C7 AF ;              ;              ;                       ;          ;
STA $0200,X          ; 9D 00 02 ;                     ;          ;              ;              ;                       ;          ;
DEX                  ; CA       ;                     ;          ;              ;              ;                       ;          ;
BPL $F7              ; 10 F7    ;                     ;          ;              ;              ;                       ;          ;
LDA $1C              ; A5 1C    ;                     ;          ;              ;              ;                       ;          ;
AND #$08             ; 29 08    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA $02              ; A5 02    ;                     ;          ;              ;              ;                       ;          ;
STA RobotBitField    ; 85 9A    ;                     ;          ; 0x03_648D    ; 0x03_64BF    ;                       ;          ; ???
AND #$03             ; 29 03    ;                     ;          ;              ;              ;                       ;          ;
STA ItemBitField     ; 85 9B    ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_6493    ; 0x03_64C5    ;                       ;          ; ???
AND #$20             ; 29 20    ;                     ;          ;              ;              ;                       ;          ;
LSR A                ; 4A       ;                     ;          ;              ;              ;                       ;          ;
LSR A                ; 4A       ;                     ;          ;              ;              ;                       ;          ;
LSR A                ; 4A       ;                     ;          ;              ;              ;                       ;          ;
ORA ItemBitField     ; 05 9B    ;                     ;          ;              ;              ;                       ;          ;
STA ItemBitField     ; 85 9B    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_64C1    ; 0x03_64F3    ;                       ;          ; ???
STA $01              ; 85 01    ;                     ;          ;              ;              ;                       ;          ;
LDA ItemBitField     ; A5 9B    ;                     ;          ;              ;              ;                       ;          ;
STA $02              ; 85 02    ;                     ;          ;              ;              ;                       ;          ;
LDX #$00             ; A2 00    ;                     ;          ;              ;              ;                       ;          ;
BEQ $0C              ; F0 0C    ;                     ;          ;              ;              ;                       ;          ;
LSR $02              ; 46 02    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_7160    ; 0x03_7247    ;                       ;          ; ???
STA $00              ; 85 00    ;                     ;          ;              ;              ;                       ;          ;
EOR #$FF             ; 49 FF    ;                     ;          ;              ;              ;                       ;          ;
STA $01              ; 85 01    ;                     ;          ;              ;              ;                       ;          ;
CLC                  ; 18       ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_71BF    ; 0x03_72A6    ;                       ;          ; password screen after weapon get
ASL A                ; 0A       ;                     ;          ;              ;              ;                       ;          ;
ORA #$01             ; 09 01    ;                     ;          ;              ;              ;                       ;          ;
STA $00              ; 85 00    ;                     ;          ;              ;              ;                       ;          ;
LDA ItemBitField     ; A5 9B    ;                     ;          ;              ;              ;                       ;          ;
ROL A                ; 2A       ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_8076    ;              ;                       ;          ; ???
CMP #$FF             ; C9 FF    ;                     ;          ;              ;              ;                       ;          ;
BNE $06              ; D0 06    ;                     ;          ;              ;              ;                       ;          ;
LDA #$08             ; A9 08    ;                     ;          ;              ;              ;                       ;          ;
STA $2A              ; 85 2A    ;                     ;          ;              ;              ;                       ;          ;
............................................................................................................................................
LDA RobotBitMasks,X  ; BD 79 C2 ;                     ;          ; 0x03_C249    ;              ;                       ;          ; called just before the weapon get screen (SplitWeaponFlags.ips)
ORA RobotBitField    ; 05 9A    ;                     ;          ;              ;              ;                       ;          ;
STA RobotBitField    ; 85 9A    ;                     ;          ; 0x03_C24E    ;              ;                       ;          ;
LDA ItemBitMasks,X   ; BD 81 C2 ;                     ;          ;              ;              ;                       ;          ;
ORA ItemBitField     ; 05 9B    ;                     ;          ;              ;              ;                       ;          ;
STA ItemBitField     ; 85 9B    ;                     ;          ;              ;              ;                       ;          ;
LDA #$0D             ; A9 0D    ;                     ;          ;              ;              ;                       ;          ;
JSR $C000            ; 20 00 C0 ;                     ;          ;              ;              ;                       ;          ;
JSR $8012            ; 20 12 80 ;                     ;          ;              ;              ;                       ;          ;
LDA #$0E             ; A9 0E    ;                     ;          ;              ;              ;                       ;          ;
JSR $C000            ; 20 00 C0 ;                     ;          ;              ;              ;                       ;          ;
LDA RobotBitField    ; A5 9A    ;                     ;          ; 0x03_C264    ;              ;                       ;          ; load stage select after weapon get
CMP #$FF             ; C9 FF    ;                     ;          ;              ;              ;                       ;          ;
BEQ $03              ; F0 03    ;                     ;          ;              ;              ;                       ;          ;
JMP $8076            ; 4C 76 80 ;                     ;          ;              ;              ;                       ;          ;
LDA #$07             ; A9 07    ;                     ;          ;              ;              ;                       ;          ;
STA $2A              ; 85 2A    ;                     ;          ;              ;              ;                       ;          ;
INC $2A              ; E6 2A    ;                     ;          ;              ;              ;                       ;          ;
LDA $2A              ; A5 2A    ;                     ;          ;              ;              ;                       ;          ;
CMP $0E              ; C9 0E    ;                     ;          ;              ;              ;                       ;          ;
BNE $0D              ; D0 0D    ;                     ;          ;              ;              ;                       ;          ;
LDA #$0D             ; A9 0D    ;                     ;          ;              ;              ;                       ;          ;
JSR $C000            ; 20 00 C0 ;                     ;          ;              ;              ;                       ;          ;
JSR $800F            ; 20 0F 80 ;                     ;          ;              ;              ;                       ;          ;



; New Instructions
; --------------------------------------------------------------                          ; --------------------------------------------------------------
LDA #$00             ; A9 00       ; $80DC   ; 0x03_40EC ; this one is ReEnterLevels.ips

;......................................................                                   ;......................................................

LDA WeaponBitField   ; A5 99       ; $91EF   ; 0x03_51FF ;

;......................................................                                   ;......................................................

LDA WeaponBitField   ; A5 99       ; $91FA   ; 0x03_520A ;

;......................................................                                   ;......................................................

LDA WeaponBitField   ; A5 99       ; $93AF   ; 0x03_53BF ;

;......................................................                                   ;......................................................

LDA WeaponBitField   ; A5 99       ; $93C2   ; 0x03_53D2 ;

;......................................................                                   ;......................................................

JMP SetWeaponBitField; 4C F0 F2    ; $C239   ; 0x03_C249 ;

;......................................................                                   ;......................................................

LDA WeaponBitMasks,X ; BD E8 F2    ; $F2F0   ; 0x03_F300 ; load new weapon bitflag
ORA WeaponBitField   ; 05 99       ; $F2F3   ; 0x03_F303 ; OR with new weapon bitfield
STA WeaponBitField   ; 85 99       ; $F2F5   ; 0x03_F305 ; write to new weapon bitfield
LDA RobotBitMasks,X  ; BD 79 C2    ; $F2F7   ; 0x03_F307 ; load boss bitflag
JMP $C23C            ; 4C 3C C2    ; $F2F9   ; 0x03_F309