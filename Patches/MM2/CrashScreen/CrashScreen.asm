; change reset address too?


; nametable clear routine
; -----------------------
LDA #$20     ; 
STA $PPUADDR ;
LDA #$00     ;
STA $PPUADDR ;
LDA #$00     ;
LDX #$00     ;
LDY #$00     ;
STA $PPUDATA ;
INX          ;
BVC $FA      ; (-6) repeat until x overflows
LDX #$00     ; would x already be zero if it overflows?
INY          ;
CPY #$04     ;
BNE $F3      ; (-13) repeat until y equals 4
RTS          ; jump instead?


; copy to ppu routine, to use first set ppu destination address, then set x to start index and set $99 to last index +1
; -------------------
LDA $????,X  ; no address decided yet
STA $PPUDATA ;
INX          ;
CPX $99      ;
BNE $F5      ; branch to beginning
RTS          ; jump instead?


; crash screen routine
; --------------------
PHP          ; 08          ; $F320 ; 0x03_F330 ; write registers to unused memory
STA $07F0    ; 8D F0 07    ; $F321
STX $07F1    ; 8E F1 07    ; $F324
STY $07F2    ; 8C F2 07    ; $F327
TSX          ; BA          ; $F32A
STX $07F3    ; 8E F3 07    ; $F32B

; should probably turn off apu

; JSR $Clear ;             ; over write nametable

LDA #$20     ; A9 20       ; $F32E
STA $PPUADDR ; 8D 06 20    ; $F330
LDA #$00     ; A9 00       ; $F333
STA $PPUADDR ; 8D 06 20    ; $F335
LDA #$DE     ; A9 DE       ; $F338
STA $PPUDATA ; 8D 07 20    ; $F33A
LDA #$AD     ; A9 AD       ; $F33D
STA $PPUDATA ; 8D 07 20    ; $F33F
LDA #$FE     ; A9 FE       ; $F342
STA $PPUDATA ; 8D 07 20    ; $F344
LDA #$ED     ; A9 ED       ; $F347
STA $PPUDATA ; 8D 07 20    ; $F349

NOP          ; EA          ; $F34C ; enter endless loop
NOP          ; EA          ; $F34D
NOP          ; EA          ; $F34E
NOP          ; EA          ; $F34F
NOP          ; EA          ; $F350
JMP $F34C    ; 4C 4C F3    ; $F351 ; restart loop