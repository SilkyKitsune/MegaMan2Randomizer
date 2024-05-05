; Just fyi idk if this will work in an assembler, it was hand assembled/disassembled

???
LDX $2A     ; A6 2A    ; 0x03_40_D8
BNE $0D     ; D0 0D
LDA $9A     ; A5 9A    ; LDA #$00 ; A9 00 ; 0x03_40_DC
CMP #$FF    ; C9 FF
BNE $ED     ; D0 ED
LDA #$08    ; A9 08
STA $2A     ; 85 2A
JMP $829A   ; 4C 9A 82
LDY $865F,X ; BC 5F 86

LDA $9A     ; A5 9A    ; LDA #$00 ; A9 00 ; 0x03_40_EC
AND $86D1,Y ; 39 D1 86
BNE $DC     ; D0 DC
STY $84     ; 84
ROL A       ; 2A 
LDA #$3A    ; A9 3A
JSR $C051   ; 20 51 C0
???