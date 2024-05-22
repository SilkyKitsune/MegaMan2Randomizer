; Just fyi idk if this will work in an assembler, it was hand assembled/disassembled

Instructions ; Bytes    ; File Addr  ; Replacement ; Bytes    ; Comments
-------------------------------------------------------------------------
LDA #$0E     ; A9 0E    ;            ;             ;          ;
JSR $C000    ; 20 00 C0 ;            ;             ;          ;
DEC $A8      ; C6 A8    ;            ;             ;          ;
BNE $1B      ; D0 1B    ;            ;             ;          ;
LDA #$00     ; A9 00    ; 0x03_C1_CA ; NOP NOP     ; EA EA    ; 
STA $A7      ; 85 A7    ;            ; NOP NOP     ; EA EA    ;
LDA #$0D     ; A9 0D    ;            ;             ;          ;
JSR $C000    ; 20 00 C0 ;            ;             ;          ;