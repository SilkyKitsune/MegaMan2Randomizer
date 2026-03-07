; Gaps in code are indicated by a line of periods -> '.'

; JP Version                                                                              NA Differences
;                 ;             ; Mapped  ; File      ;                                                     ;             ; Mapped  ; File      ;
; Instructions    ; Bytes       ; Address ; Address   ; Comments                          Instructions      ; Bytes       ; Address ; Address   ; Comments
; --------------------------------------------------------------                          ----------------------------------------------------------------
LDA $2A           ; A5 2A       ; $C805   ; 0x03_C815 ; load stage index                                    ;             ; $C808   ; 0x03_C818
STA $B3           ; 85 B3       ; $C807   ; 0x03_C817 ; write to boss index                                 ;             ; $C80A   ; 0x03_C81A
LDA #$0B          ; A9 0B       ; $C809   ; 0x03_C819                                                       ;             ; $C80C   ; 0x03_C81C
JSR $C000         ; 20 00 C0    ; $C80B   ; 0x03_C81B                                                       ;             ; $C80E   ; 0x03_C81E
JSR $8000         ; 20 00 80    ; $C80E   ; 0x03_C81E                                                       ;             ; $C811   ; 0x03_C821
LDA #$0E          ; A9 0E       ; $C811   ; 0x03_C821                                                       ;             ; $C814   ; 0x03_C824
JSR $C000         ; 20 00 C0    ; $C813   ; 0x03_C823                                                       ;             ; $C816   ; 0x03_C826
LDA #$00          ; A9 00       ; $C816   ; 0x03_C826                                                       ;             ; $C819   ; 0x03_C829
STA $23           ; 85 23       ; $C818   ; 0x03_C828                                                       ;             ; $C81B   ; 0x03_C82B
STA $27           ; 85 27       ; $C81A   ; 0x03_C82A                                                       ;             ; $C81D   ; 0x03_C82D
JSR $84EE         ; 20 EE 84    ; $C81C   ; 0x03_C82C                                                       ;             ; $C81F   ; 0x03_C82F
JSR $DCCD         ; 20 CD DC    ; $C81F   ; 0x03_C82F                                     JSR $DCD0         ; 20 D0 DC    ; $C822   ; 0x03_C832
JSR $D655         ; 20 55 D6    ; $C822   ; 0x03_C832                                     JSR $D658         ; 20 58 D6    ; $C825   ; 0x03_C835
JSR $C5A9         ; 20 A9 C5    ; $C825   ; 0x03_C835                                                       ;             ; $C828   ; 0x03_C838
JSR $925B         ; 20 5B 92    ; $C828   ; 0x03_C838                                                       ;             ; $C82B   ; 0x03_C83B
JSR $CC74         ; 20 74 CC    ; $C82B   ; 0x03_C83B                                     JSR $CC77         ; 20 77 CC    ; $C82E   ; 0x03_C83E
LDA $FB           ; A5 FB       ; $C82E   ; 0x03_C83E                                                       ;             ; $C831   ; 0x03_C841
BEQ $0F           ; F0 0F       ; $C830   ; 0x03_C840 ; branch to $C841                                     ;             ; $C833   ; 0x03_C843 ; branch to $C844
INC $FC           ; E6 FC       ; $C832   ; 0x03_C842                                                       ;             ; $C835   ; 0x03_C845
CMP $FC           ; C5 FC       ; $C834   ; 0x03_C844                                                       ;             ; $C837   ; 0x03_C847
BEQ $02           ; F0 02       ; $C836   ; 0x03_C846 ; branch to $C83A                                     ;             ; $C839   ; 0x03_C849 ; branch to $C83D
BCS $07           ; B0 07       ; $C838   ; 0x03_C848 ; branch to $C841                                     ;             ; $C83B   ; 0x03_C84B ; branch to $C844
JSR $C0D7         ; 20 D7 C0    ; $C83A   ; 0x03_C84A                                                       ;             ; $C83D   ; 0x03_C84D
LDA #$00          ; A9 00       ; $C83D   ; 0x03_C84D                                                       ;             ; $C840   ; 0x03_C850
STA $FC           ; 85 FC       ; $C83F   ; 0x03_C84F                                                       ;             ; $C842   ; 0x03_C852
JSR $C07F         ; 20 7F C0    ; $C841   ; 0x03_C851                                                       ;             ; $C844   ; 0x03_C854
LDA $B1           ; A5 B1       ; $C844   ; 0x03_C854                                                       ;             ; $C847   ; 0x03_C857
CMP #$02          ; C9 02       ; $C846   ; 0x03_C856                                                       ;             ; $C849   ; 0x03_C859
BCC $CC           ; 90 CC       ; $C848   ; 0x03_C858 ; branch to $C816                                     ;             ; $C84B   ; 0x03_C85B ; branch to $C819
RTS               ; 60          ; $C84A   ; 0x03_C85A                                                       ;             ; $C84D   ; 0x03_C85D



; New Instructions
; -----------------------------------------------------
JMP $F320         ; 4C 20 F3    ; $C805   ; 0x03_C815 ; jump to new instructions                            ;             ; $C808   ; 0x03_C818
NOP               ; EA          ; $C808   ; 0x03_C818 ; NOP to fill unused byte                             ;             ; $C80B   ; 0x03_C81B
;......................................................
PHX               ; DA          ; $F320   ; 0x03_F330                                                       ;             ;         ;
LDX $2A           ; A6 2A       ; $F321   ; 0x03_F331 ; load stage index                                    ;             ;         ;
LDA $F310,X       ; BD 10 F3    ; $F323   ; 0x03_F333 ; load new boss index                                 ;             ;         ;
STA $B3           ; 85 B3       ; $F326   ; 0x03_F336 ; write to boss index                                 ;             ;         ;
PLX               ; FA          ; $F328   ; 0x03_F338                                                       ;             ;         ;
JMP $C809         ; 4C 09 C8    ; $F329   ; 0x03_F339                                     JMP $C80C         ; 4C 0C C8    ;         ;