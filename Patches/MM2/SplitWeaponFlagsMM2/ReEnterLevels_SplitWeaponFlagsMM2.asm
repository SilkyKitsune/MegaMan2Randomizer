; Just fyi idk if this will work in an assembler, it was hand assembled/disassembled

; This includes all the times a LDA/STA opcode is called for the address $009A
; Gaps in code are indicated by a line of periods -> '.'
Instructions JP      ; Bytes JP ; File Addr JP ; Comments
--------------------------------------------------------------------------------------------------------------------------------------------
LDA $9A              ; A5 9A    ; 0x03_403B    ; load boss bitfield, ???
STA $01              ; 85 01    ;              ;
STX $00              ; 86 00    ;              ;
LSR $01              ; 46 01    ;              ;
BCC $2C              ; 90 2C    ;              ;
LDA $8531,X          ; BD 31 85 ;              ;
STA $09              ; 85 09    ;              ;
LDA $8539,X          ; BD 39 85 ;              ;
STA $08              ; 85 08    ;              ;
LDX #$04             ; A2 04    ;              ;
LDA #$00             ; A9 00    ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_4082    ; load boss bitfield, every stage select load
STA $02              ; 85 02    ;              ;
LDY #$00             ; A0 00    ;              ;
STX $01              ; 86 01    ;              ;
LSR $02              ; 46 02    ;              ;
BCS $15              ; B0 15    ;              ;
LDA $8605,X          ; BD 05 86 ;              ;
STA $00              ; 85 00    ;              ;
LDA $85FD,X          ; BD FD 85 ;              ;
............................................................................................................................................
LDX $2A              ; A6 2A    ; 0x03_40D8    ;
BNE $0D              ; D0 0D    ;              ;
LDA $9A              ; A5 9A    ; 0x03_40DC    ; load boss bitfield, first stage select load, maybe others
CMP #$FF             ; C9 FF    ;              ;
BNE $ED              ; D0 ED    ;              ;
LDA #$08             ; A9 08    ;              ; index of wily stage 1, this might actually be the placement of the cursor
STA $2A              ; 85 2A    ;              ;
JMP $829A            ; 4C 9A 82 ;              ;
LDY $865F,X          ; BC 5F 86 ;              ;
LDA $9A              ; A5 9A    ; 0x03_40EC    ; load boss bitfield, stage chosen (ReEnterLevels.ips)
AND $86D1,Y          ; 39 D1 86 ;              ;
BNE $DC	             ; D0 DC    ;              ;
STY $2A	             ; 84 2A    ;              ;
LDA #$3A             ; A9 3A    ;              ;
JSR $C051            ; 20 51 C0 ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_51FF    ; load boss bitfield, pause menu close (SplitWeaponFlags.ips)
ASL A                ; 0A       ;              ;
ORA #$41             ; 09 41    ;              ;
STA $07              ; 85 07    ;              ;
LDA $FE              ; A5 FE    ;              ;
BEQ $11              ; F0 11    ;              ;
LDA $9A              ; A5 9A    ; 0x03_520A    ; load boss bitfield, pause menu page 2, run continuously (SplitWeaponFlags.ips)
STA $07              ; 85 07    ;              ;
LDA $9B              ; A5 9B    ;              ; load item bitfield
ASL $07              ; 06 07    ;              ;
ROL A                ; 2A       ;              ;
ASL $07              ; 06 07    ;              ;
ROL A                ; 2A       ;              ;
STA $07              ; 85 07    ;              ;
LDA $27              ; A5 27    ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_53BF    ; load boss bitfield, pause menu page 1, run continuously (SplitWeaponFlags.ips)
ASL A                ; 0A       ;              ;
ORA #$01             ; 09 01    ;              ;
STA $07              ; 85 07    ;              ;
LDA #$05             ; A9 05    ;              ;
STA $01              ; 85 01    ;              ;
LDX #$00             ; A2 00    ;              ;
LDA $FE              ; A5 FE    ;              ;
BEQ $13              ; F0 13    ;              ;
LDX #$06             ; A2 06    ;              ;
LDA $9A              ; A5 9A    ; 0x03_53D2    ; load boss bitfield, pause menu page 2, run continuously (SplitWeaponFlags.ips)
STA $07              ; 85 07    ;              ;
LDA $9B              ; A5 9B    ;              ; load item bitfield
ASL $07              ; 06 07    ;              ;
ROL A                ; 2A       ;              ;
ASL $07              ; 06 07    ;              ;
ROL A                ; 2A       ;              ;
ASL $07              ; 06 07    ;              ;
ROL A                ; 2A       ;              ;
STA $07              ; 85 07    ;              ;
LDA $07              ; A5 07    ;              ;
............................................................................................................................................
JSR $A974            ; 20 74 A9 ; 0x03_62EC    ;
LDA #$00             ; A9 00    ;              ;
STA $FD              ; 85 FD    ;              ;
STA $9A              ; 85 9A    ; 0x03_62F3    ; write boss bitfield, I think is set at start/password screen
STA $9B              ; 85 9B    ;              ; write to item bitfield
LDX #$03             ; A2 03    ;              ;
LDA $AEE0,X          ; BD E0 AE ;              ;
STA $0200,X          ; 9D 00 02 ;              ;
DEX                  ; CA       ;              ;
BPL $F7              ; 10 F7    ;              ;
LDA $1C              ; A5 1C    ;              ;
AND #$08             ; 29 08    ;              ;
............................................................................................................................................
LDA $02              ; A5 02    ;              ;
STA $9A              ; 85 9A    ; 0x03_648D    ;  write boss bitfield, ???
AND #$03             ; 29 03    ;              ;
STA $9B              ; 85 9B    ;              ; write to item bitfield
LDA $9A              ; A5 9A    ; 0x03_6493    ; load boss bitfield, ???
AND #$20             ; 29 20    ;              ;
LSR A                ; 4A       ;              ;
LSR A                ; 4A       ;              ;
LSR A                ; 4A       ;              ;
ORA $9B              ; 05 9B    ;              ; OR with item bitfield
STA $9B              ; 85 9B    ;              ; write to item bitfield
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_64C1    ; load boss bitfield, ???
STA $01              ; 85 01    ;              ;
LDA $9B              ; A5 9B    ;              ; load item bitfield
STA $02              ; 85 02    ;              ;
LDX #$00             ; A2 00    ;              ;
BEQ $0C              ; F0 0C    ;              ;
LSR $02              ; 46 02    ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_7160    ; load boss bitfield, ???
STA $00              ; 85 00    ;              ;
EOR #$FF             ; 49 FF    ;              ;
STA $01              ; 85 01    ;              ;
CLC                  ; 18       ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_71BF    ; load boss bitfield, password screen after weapon get
ASL A                ; 0A       ;              ;
ORA #$01             ; 09 01    ;              ;
STA $00              ; 85 00    ;              ;
LDA $9B              ; A5 9B    ;              ; load item bitfield
ROL A                ; 2A       ;              ;
............................................................................................................................................
LDA $9A              ; A5 9A    ; 0x03_8076    ; load boss bitfield, ???
CMP #$FF             ; C9 FF    ;              ;
BNE $06              ; D0 06    ;              ;
LDA #$08             ; A9 08    ;              ;
STA $2A              ; 85 2A    ;              ;
............................................................................................................................................
LDA $C279,X          ; BD 79 C2 ; 0x03_C249    ; load boss bitflag, called just before the weapon get screen (SplitWeaponFlags.ips)
ORA $9A              ; 05 9A    ;              ; OR with boss bitfield
STA $9A              ; 85 9A    ; 0x03_C24E    ; write to boss bitfield
LDA $C281,X          ; BD 81 C2 ;              ; load item bitflag
ORA $9B              ; 05 9B    ;              ; OR with item bitfield
STA $9B              ; 85 9B    ;              ; write to item bitfield
LDA #$0D             ; A9 0D    ;              ;
JSR $C000            ; 20 00 C0 ;              ;
JSR $8012            ; 20 12 80 ;              ;
LDA #$0E             ; A9 0E    ;              ;
JSR $C000            ; 20 00 C0 ;              ;
LDA $9A              ; A5 9A    ; 0x03_C264    ; load boss bitfield, load stage select after weapon get
CMP #$FF             ; C9 FF    ;              ;
BEQ $03              ; F0 03    ;              ;
JMP $8076            ; 4C 76 80 ;              ;
LDA #$07             ; A9 07    ;              ;
STA $2A              ; 85 2A    ;              ;
INC $2A              ; E6 2A    ;              ;
LDA $2A              ; A5 2A    ;              ;
CMP $0E              ; C9 0E    ;              ;
BNE $0D              ; D0 0D    ;              ;
LDA #$0D             ; A9 0D    ;              ;
JSR $C000            ; 20 00 C0 ;              ;
JSR $800F            ; 20 0F 80 ;              ;



; New Instructions
; --------------------------------------------------------------                          ; --------------------------------------------------------------
LDA #$00          ; A9 00       ; $80DC   ; 0x03_40EC ; this one is ReEnterLevels.ips

;......................................................                                   ;......................................................

LDA $99           ; A5 99       ; $91EF   ; 0x03_51FF ; load new weapon bitfield

;......................................................                                   ;......................................................

LDA $99           ; A5 99       ; $91FA   ; 0x03_520A ; load new weapon bitfield

;......................................................                                   ;......................................................

LDA $99           ; A5 99       ; $93AF   ; 0x03_53BF ; load new weapon bitfield

;......................................................                                   ;......................................................

LDA $99           ; A5 99       ; $93C2   ; 0x03_53D2 ; load new weapon bitfield

;......................................................                                   ;......................................................

JMP $F2F0         ; 4C F0 F2    ; $C239   ; 0x03_C249 ; jump to new instructions

;......................................................                                   ;......................................................

LDA $F2E8,X       ; BD E8 F2    ; $F2F0   ; 0x03_F300 ; load new weapon bitflag
ORA $99           ; 05 99       ; $F2F3   ; 0x03_F303 ; OR with new weapon bitfield
STA $99           ; 85 99       ; $F2F5   ; 0x03_F305 ; write to new weapon bitfield
LDA $C279,X       ; BD 79 C2    ; $F2F7   ; 0x03_F307 ; load boss bitflag
JMP $C23C         ; 4C 3C C2    ; $F2F9   ; 0x03_F309