; Just fyi idk if this will work in an assembler, it was hand assembled/disassembled

; Gaps in code are indicated by a line of periods -> '.'
Instructions JP ; Bytes JP ; Instructions NA ; Bytes NA ; File Addr JP ; File Addr NA ; Replacement ; Bytes    ; Comments
-------------------------------------------------------------------------------------------------------------------------
JSR $F175       ; 20 75 F1 ; JSR $F197       ; 20 97 F1 ; 0x03_BB_7F   ;              ;             ;          ; moves boobeam projectiles
PLA             ; 68       ;                 ;          ;              ;              ;             ;          ;
TAX             ; AA       ;                 ;          ;              ;              ;             ;          ;
STX $2B         ; 86 2B    ;                 ;          ;              ;              ;             ;          ;
LDA $06A0,X     ; BD A0 06 ;                 ;          ;              ;              ;             ;          ;
CMP #$04        ; C9 04    ;                 ;          ;              ;              ;             ;          ;
BNE $05         ; D0 05    ;                 ;          ;              ;              ;             ;          ;
LDA #$00        ; A9 00    ;                 ;          ;              ;              ;             ;          ;
STA $06A0,X     ; 9D A0 06 ;                 ;          ;              ;              ;             ;          ;
JSR $EF91       ; 20 91 EF ; JSR $EFB3       ; 20 B3 EF ; 0x03_BB_92   ;              ; NOP NOP NOP ; EA EA EA ; sets carry based on whether any boobeams have died
BCC $10         ; 90 10    ;                 ;          ;              ;              ; NOP NOP     ; EA EA    ;
SEC             ; 38       ;                 ;          ;              ;              ; NOP         ; EA       ;
LDA $06C1       ; AD C1 06 ;                 ;          ;              ;              ; NOP NOP NOP ; EA EA EA ;
SBC #$06        ; E9 06    ;                 ;          ; 0x03_BB_9B   ;              ; LDA #$00    ; A9 00    ;
STA $06C1       ; 8D C1 06 ;                 ;          ;              ;              ;             ;          ;
BCS $05         ; B0 05    ;                 ;          ;              ;              ;             ;          ;
LDA #$00        ; A9 00    ;                 ;          ;              ;              ;             ;          ;
STA $06C1       ; 8D C1 06 ;                 ;          ;              ;              ;             ;          ;
RTS             ; 60       ;                 ;          ;              ;              ;             ;          ;
.........................................................................................................................
CPX #$10        ; E0 10    ;                 ;          ; 0x03_EF_7D   ; 0x03_EF_9F   ;             ;          ; $EF8F what was this?
BCC $09         ; 90 09    ;                 ;          ;              ;              ;             ;          ;
LDA $4E         ; A5 4E    ;                 ;          ;              ;              ;             ;          ;
BNE $07         ; D0 07    ;                 ;          ;              ;              ;             ;          ;
LDA #$FF        ; A9 FF    ;                 ;          ;              ;              ;             ;          ;
STA $00F0,X     ; 9D F0 00 ;                 ;          ;              ;              ;             ;          ;
SEC             ; 38       ;                 ;          ;              ;              ;             ;          ;
RTS             ; 60       ;                 ;          ;              ;              ;             ;          ;
LDA #$FF        ; A9 FF    ;                 ;          ;              ;              ;             ;          ;
STA $0120,X     ; 9D 20 01 ;                 ;          ;              ;              ;             ;          ;
LDA $0110,X     ; BD 10 01 ;                 ;          ;              ;              ;             ;          ;
TAY             ; A8       ;                 ;          ;              ;              ;             ;          ;
LDA $06C0,X     ; BD C0 06 ;                 ;          ;              ;              ;             ;          ;
STA $0140,Y     ; 99 40 01 ;                 ;          ;              ;              ;             ;          ;
SEC             ; 38       ;                 ;          ;              ;              ;             ;          ;
RTS             ; 60       ;                 ;          ;              ;              ;             ;          ;
.........................................................................................................................
LDA #$00        ; A9 00    ;                 ;          ; 0x03_EF_A1   ; 0x03_EF_C3   ;             ;          ; $EFB3 boobeam check routine
STA $4E         ; 85 4E    ;                 ;          ;              ;              ;             ;          ;
LDA $0420,X     ; BD 20 04 ;                 ;          ;              ;              ;             ;          ;
AND #$03        ; 29 03    ;                 ;          ;              ;              ;             ;          ;
BEQ $2A         ; F0 2A    ;                 ;          ;              ;              ;             ;          ;
PHA             ; 48       ;                 ;          ;              ;              ;             ;          ;
AND #$01        ; 29 01    ;                 ;          ;              ;              ;             ;          ;
BEQ $03         ; F0 03    ;                 ;          ;              ;              ;             ;          ;
JSR $E557       ; 20 57 E5 ; JSR $E55A       ; 20 5A E5 ;              ;              ;             ;          ;
PLA             ; 68       ;                 ;          ;              ;              ;             ;          ;
AND #$02        ; 29 02    ;                 ;          ;              ;              ;             ;          ;
BEQ $1D         ; F0 1D    ;                 ;          ;              ;              ;             ;          ;
JSR $E5E9       ; 20 E9 E5 ; JSR $E5EC       ; 20 EC E5 ;              ;              ;             ;          ;
BCC $18         ; 90 18    ;                 ;          ;              ;              ;             ;          ;
JSR $F238       ; 20 38 F2 ; JSR $F25A       ; 20 5A F2 ;              ;              ;             ;          ;
LDA #$06        ; A9 06    ;                 ;          ;              ;              ;             ;          ;
STA $0400,X     ; 9D 00 04 ;                 ;          ;              ;              ;             ;          ;
LDA #$80        ; A9 80    ;                 ;          ;              ;              ;             ;          ;
STA $0420,X     ; 9D 20 04 ;                 ;          ;              ;              ;             ;          ;
LDA #$00        ; A9 00    ;                 ;          ;              ;              ;             ;          ;
STA $0680,X     ; 9D 80 06 ;                 ;          ;              ;              ;             ;          ;
STA $06A0,X     ; 9D A0 06 ;                 ;          ;              ;              ;             ;          ;
JMP $EF6D       ; 4C 6D EF ; JMP $EF8F       ; 4C 8F EF ;              ;              ;             ;          ;
LDA $2F         ; A5 2F    ;                 ;          ;              ;              ;             ;          ;
BNE $A0         ; D0 A0    ;                 ;          ;              ;              ;             ;          ;
CLC             ; 18       ;                 ;          ;              ;              ;             ;          ;
RTS             ; 60       ;                 ;          ;              ;              ;             ;          ;