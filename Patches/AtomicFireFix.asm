; Gaps in code are indicated by a line of periods -> '.'

; Instructions JP ; Bytes JP    ; Instructions NA   ; Bytes NA    ; File Addr JP ; File Addr NA ; Mapped Addr JP ; Mapped Addr NA ; Comments
; ------------------------------------------------------------------------------------------------------------------------------------------
LDA $A931,Y       ; B9 31 A9    ; LDA $A950,Y       ; B9 50 A9    ; 0x02_E679    ; 0x02_E67C    ; $A669          ; $A66C           ; load from atomice fire damage values
BEQ $44           ; F0 44       ; BEQ $47           ; F0 47       ; 0x02_E67C    ; 0x02_E67F    ; $A66C          ; $A66F           ; branch to $A6B2
LDA $04E0,X       ; BD E0 04    ;                   ;             ; 0x02_E67E    ; 0x02_E681    ; $A66E          ; $A671           ;
CMP #$02          ; C9 02       ;                   ;             ; 0x02_E681    ; 0x02_E684    ; $A671          ; $A674           ;
BCC $12           ; 90 12       ;                   ;             ; 0x02_E683    ; 0x02_E686    ; $A673          ; $A676           ; branch to $A687/$A68A
BEQ $05           ; F0 05       ;                   ;             ; 0x02_E685    ; 0x02_E688    ; $A675          ; $A678           ; branch to $A67C/$A67F
LDA $A931,Y       ; B9 31 A9    ; LDA $A950,Y       ; B9 50 A9    ; 0x02_E687    ; 0x02_E68A    ; $A677          ; $A67A           ; load from atomice fire damage values (fully charged projectile)
BNE $0E           ; D0 0E       ;                   ;             ; 0x02_E68A    ; 0x02_E68D    ; $A67A          ; $A67D           ; branch to $A68A/$A68D
CLC               ; 18          ;                   ;             ; 0x02_E68C    ; 0x02_E68F    ; $A67C          ; $A67F           ;
LDA $A923,Y       ; B9 23 A9    ; LDA $A942,Y       ; B9 42 A9    ; 0x02_E68D    ; 0x02_E690    ; $A67D          ; $A680           ; load from mega buster damage values (half charged projectile)
ASL A             ; 0A          ;                   ;             ; 0x02_E690    ; 0x02_E693    ; $A680          ; $A683           ; left shift to multiply by 2
ADC $A923,Y       ; 79 23 A9    ; ADC $A942,Y       ; 79 42 A9    ; 0x02_E691    ; 0x02_E694    ; $A681          ; $A684           ; add with original value to make it multiplied by 3
JMP $A68A         ; 4C 8A A6    ; JMP $A68D         ; 4C 8D A6    ; 0x02_E694    ; 0x02_E697    ; $A684          ; $A687           ;
LDA $A923,Y       ; B9 23 A9    ; LDA $A942,Y       ; B9 42 A9    ; 0x02_E697    ; 0x02_E69A    ; $A687          ; $A68A           ; load from mega buster damage values (uncharged projectile)
STA $00           ; 85 00       ;                   ;             ; 0x02_E69A    ; 0x02_E69D    ; $A68A          ; $A68D           ;


; New Instructions
; ------------------------------------------------------------------------------------------------------------------------------------------------
BCC $0F           ; 90 0F       ;                   ;             ; 0x02_E683    ; 0x02_E686    ; $A673          ; $A676           ; branch to $A684/$A687
; ..................................................................................................................................
LDA $A931,Y       ; B9 31 A9    ; LDA $A950,Y       ; B9 50 A9    ; 0x02_E68D    ; 0x02_E690    ; $A67D          ; $A680           ; load from atomic fire damage values instead (half charged projectile)
LSR A             ; 4A          ;                   ;             ; 0x02_E690    ; 0x02_E693    ; $A680          ; $A683           ; right shift to divide by 2
JMP $A68A         ; 4C 8A A6    ; JMP $A68D         ; 4C 8D A6    ; 0x02_E691    ; 0x02_E694    ; $A681          ; $A684           ;

LDA $A931,Y       ; B9 31 A9    ; LDA $A950,Y       ; B9 50 A9    ; 0x02_E694    ; 0x02_E697    ; $A684          ; $A687           ; load from atomic fire damage values instead (uncharged projectile)
LSR A             ; 4A          ;                   ;             ; 0x02_E695    ; 0x02_E69A    ; $A685          ; $A68A           ; right shift to divide by 2
LSR A             ; 4A          ;                   ;             ; 0x02_E696    ; 0x02_E69B    ; $A686          ; $A69B           ; right shift again to make it divided by 4

NOP               ; EA          ;                   ;             ; 0x02_E697    ; 0x02_E69C    ; $A687          ; $A68C           ; NOP to fill empty byte