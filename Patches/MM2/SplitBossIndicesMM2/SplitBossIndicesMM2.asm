; Large gaps between addresses are indicated by a line of periods -> '.'

; JP Version                                                                              ; NA Differences
;                 ;             ; Mapped  ; File      ;                                   ;                 ;             ; Mapped  ; File      ;
; Instructions    ; Bytes       ; Address ; Address   ; Comments                          ; Instructions    ; Bytes       ; Address ; Address   ; Comments
; --------------------------------------------------------------                          ; --------------------------------------------------------------
JSR $83DF         ; 20 DF 83    ; $838B   ; 0x03_839B                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $838E   ; 0x03_839E                                                       ;             ;         ;
STA $FD           ; 85 FD       ; $8390   ; 0x03_83A0                                                       ;             ;         ;
LDX $BA           ; A6 BA       ; $8392   ; 0x03_83A2 ; load teleporter index?                              ;             ;         ;
LDA $83D6,X       ; BD D6 83    ; $8394   ; 0x03_83A4                                                       ;             ;         ;
STA $FE           ; 85 FE       ; $8397   ; 0x03_83A7                                                       ;             ;         ;
DEX               ; CA          ; $8399   ; 0x03_83A9                                                       ;             ;         ;
STX $2A           ; 86 2A       ; $839A   ; 0x03_83AA                                                       ;             ;         ;
JSR $8416         ; 20 16 84    ; $839C   ; 0x03_83AC                                                       ;             ;         ;
LDA #$0C          ; A9 0C       ; $839F   ; 0x03_83AF                                                       ;             ;         ;
STA $2A           ; 85 2A       ; $83A1   ; 0x03_83B1                                                       ;             ;         ;
LDX #$05          ; A2 05       ; $83A3   ; 0x03_83B3                                                       ;             ;         ;
LDA $BA           ; A5 BA       ; $83A5   ; 0x03_83B5                                                       ;             ;         ;
CMP #$04          ; C9 04       ; $83A7   ; 0x03_83B7                                                       ;             ;         ;
BNE $02           ; D0 02       ; $83A9   ; 0x03_83B9 ; branch to $83AD                                     ;             ;         ;
LDX #$02          ; A2 02       ; $83AB   ; 0x03_83BB                                                       ;             ;         ;
JSR $8481         ; 20 81 84    ; $83AD   ; 0x03_83BD                                                       ;             ;         ;
INC $20           ; E6 20       ; $83B0   ; 0x03_83C0                                                       ;             ;         ;
INC $0440         ; EE 40 04    ; $83B2   ; 0x03_83C2                                                       ;             ;         ;
INC $38           ; E6 38       ; $83B5   ; 0x03_83C5                                                       ;             ;         ;
INC $14           ; E6 14       ; $83B7   ; 0x03_83C7                                                       ;             ;         ;
INC $15           ; E6 15       ; $83B9   ; 0x03_83C9                                                       ;             ;         ;
LDA #$20          ; A9 20       ; $83BB   ; 0x03_83CB                                                       ;             ;         ;
STA $0460         ; 8D 60 04    ; $83BD   ; 0x03_83CD                                                       ;             ;         ;
LDA #$B4          ; A9 B4       ; $83C0   ; 0x03_83D0                                                       ;             ;         ;
STA $04A0         ; 8D A0 04    ; $83C2   ; 0x03_83D2                                                       ;             ;         ;
JSR $8407         ; 20 07 84    ; $83C5   ; 0x03_83D5                                                       ;             ;         ;
LDA #$0B          ; A9 0B       ; $83C8   ; 0x03_83D8                                                       ;             ;         ;
JSR $C051         ; 20 51 C0    ; $83CA   ; 0x03_83DA                                                       ;             ;         ;
LDA $BA           ; A5 BA       ; $83CD   ; 0x03_83DD ; load teleporter index?                              ;             ;         ;
STA $B3           ; 85 B3       ; $83CF   ; 0x03_83DF ; write to boss index                                 ;             ;         ;
DEC $B3           ; C6 B3       ; $83D1   ; 0x03_83E1 ; decrement boss index                                ;             ;         ;
JSR $C809         ; 20 09 C8    ; $83D3   ; 0x03_83E3                                     JSR $C80C         ; 20 0C C8    ;         ;
RTS               ; 60          ; $83D6   ; 0x03_83E6                                                       ;             ;         ;

;......................................................                                   ;......................................................

JSR $83DF         ; 20 DF 83    ; $8423   ; 0x03_8433                                                       ;             ;         ;
LDX $B3           ; A6 B3       ; $8426   ; 0x03_8436 ; load boss index                                     ;             ;         ;
LDA $BC           ; A5 BC       ; $8428   ; 0x03_8438                                                       ;             ;         ;
ORA $C279,X       ; 1D 79 C2    ; $842A   ; 0x03_843A                                                       ;             ;         ;
STA $BC           ; 85 BC       ; $842D   ; 0x03_843D                                                       ;             ;         ;
CMP #$FF          ; C9 FF       ; $842F   ; 0x03_843F                                                       ;             ;         ;
BNE $1D           ; D0 1D       ; $8431   ; 0x03_8441 ; branch to $8450                                     ;             ;         ;
LDA #$00          ; A9 00       ; $8433   ; 0x03_8443                                                       ;             ;         ;
STA $FD           ; 85 FD       ; $8435   ; 0x03_8445                                                       ;             ;         ;
LDA #$14          ; A9 14       ; $8437   ; 0x03_8447                                                       ;             ;         ;
STA $FE           ; 85 FE       ; $8439   ; 0x03_8449                                                       ;             ;         ;
JSR $8416         ; 20 16 84    ; $843B   ; 0x03_844B                                                       ;             ;         ;
LDA #$28          ; A9 28       ; $843E   ; 0x03_844E                                                       ;             ;         ;
JSR $907D         ; 20 7D 90    ; $8440   ; 0x03_8450                                                       ;             ;         ;
LDA #$28          ; A9 28       ; $8443   ; 0x03_8453                                                       ;             ;         ;
STA $20           ; 85 20       ; $8445   ; 0x03_8455                                                       ;             ;         ;
STA $0440         ; 8D 40 04    ; $8447   ; 0x03_8457                                                       ;             ;         ;
STA $14           ; 85 14       ; $844A   ; 0x03_845A                                                       ;             ;         ;
STA $15           ; 85 15       ; $844C   ; 0x03_845C                                                       ;             ;         ;
BNE $0B           ; D0 0B       ; $844E   ; 0x03_845E ; branch to $845B                                     ;             ;         ;
DEC $20           ; C6 20       ; $8450   ; 0x03_8460                                                       ;             ;         ;
DEC $0440         ; CE 40 04    ; $8452   ; 0x03_8462                                                       ;             ;         ;
DEC $38           ; C6 38       ; $8455   ; 0x03_8465                                                       ;             ;         ;
DEC $14           ; C6 14       ; $8457   ; 0x03_8467                                                       ;             ;         ;
DEC $15           ; C6 15       ; $8459   ; 0x03_8469                                                       ;             ;         ;
LDX #$08          ; A2 08       ; $845B   ; 0x03_846B                                                       ;             ;         ;
JSR $8481         ; 20 81 84    ; $845D   ; 0x03_846D                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $8460   ; 0x03_8470                                                       ;             ;         ;
STA $B1           ; 85 B1       ; $8462   ; 0x03_8472                                                       ;             ;         ;
LDX $B3           ; A6 B3       ; $8464   ; 0x03_8474 ; load boss index                                     ;             ;         ;
CLC               ; 18          ; $8466   ; 0x03_8476                                                       ;             ;         ;
LDA $8268,X       ; BD 68 82    ; $8467   ; 0x03_8477                                                       ;             ;         ;
ADC #$07          ; 69 07       ; $846A   ; 0x03_847A                                                       ;             ;         ;
STA $04A0         ; 8D A0 04    ; $846C   ; 0x03_847C                                                       ;             ;         ;
LDA $8270,X       ; BD 70 82    ; $846F   ; 0x03_847F                                                       ;             ;         ;
STA $0460         ; 8D 60 04    ; $8472   ; 0x03_8482                                                       ;             ;         ;
JSR $8407         ; 20 07 84    ; $8475   ; 0x03_8485                                                       ;             ;         ;
LDA #$09          ; A9 09       ; $8478   ; 0x03_8488                                                       ;             ;         ;
JSR $C051         ; 20 51 C0    ; $847A   ; 0x03_848A                                                       ;             ;         ;
JSR $81DE         ; 20 DE 81    ; $847D   ; 0x03_848D                                                       ;             ;         ;
RTS               ; 60          ; $8480   ; 0x03_8490                                                       ;             ;         ;

;......................................................                                   ;......................................................

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
JMP $F32C         ; 4C 2C F3    ; $8394   ; 0x03_83A4 ; jump to new instructions                            ;             ;         ;

;......................................................                                   ;......................................................

NOP               ; EA          ; $83CD   ; 0x03_83DD ; NOP to fill unused bytes                            ;             ;         ;
NOP               ; EA          ; $83CE   ; 0x03_83DE ;                                                     ;             ;         ;
NOP               ; EA          ; $83CF   ; 0x03_83DF ;                                                     ;             ;         ;
NOP               ; EA          ; $83D0   ; 0x03_83E0 ;                                                     ;             ;         ;
NOP               ; EA          ; $83D1   ; 0x03_83E1 ;                                                     ;             ;         ;
NOP               ; EA          ; $83D2   ; 0x03_83E2 ;                                                     ;             ;         ;

;......................................................                                   ;......................................................

LDX $C3           ; A6 C3       ; $8426   ; 0x03_8436 ; load original boss index                            ;             ;         ;

;......................................................                                   ;......................................................

LDX $C3           ; A6 C3       ; $8464   ; 0x03_8474 ; load original boss index                            ;             ;         ;

;......................................................                                   ;......................................................

JMP $F320         ; 4C 20 F3    ; $C805   ; 0x03_C815 ; jump to new instructions                            ;             ; $C808   ; 0x03_C818
NOP               ; EA          ; $C808   ; 0x03_C818 ; NOP to fill unused byte                             ;             ; $C80B   ; 0x03_C81B

;......................................................                                   ;......................................................

PHX               ; DA          ; $F320   ; 0x03_F330                                                       ;             ;         ;
LDX $2A           ; A6 2A       ; $F321   ; 0x03_F331 ; load stage index                                    ;             ;         ;
LDA $F310,X       ; BD 10 F3    ; $F323   ; 0x03_F333 ; load new boss index                                 ;             ;         ;
STA $B3           ; 85 B3       ; $F326   ; 0x03_F336 ; write to boss index                                 ;             ;         ;
PLX               ; FA          ; $F328   ; 0x03_F338                                                       ;             ;         ;
JMP $C809         ; 4C 09 C8    ; $F329   ; 0x03_F339                                     JMP $C80C         ; 4C 0C C8    ;         ;

LDX $BA           ; A6 BA       ; $F32C   ; 0x03_F33C ; load teleporter index?                              ;             ;         ;
STX $C3           ; 86 C3       ; $F32E   ; 0x03_F33E ; store original boss index                           ;             ;         ;
DEC $C3           ; C6 C3       ; $F330   ; 0x03_F340                                                       ;             ;         ;
LDA $F30F,X       ; BD 0F F3    ; $F332   ; 0x03_F342 ; load new boss index                                 ;             ;         ;
STA $B3           ; 85 B3       ; $F335   ; 0x03_F345 ; write to boss index                                 ;             ;         ;
LDA $83D6,X       ; BD D6 83    ; $F337   ; 0x03_F347                                                       ;             ;         ;
JMP $8397         ; 4C 97 83    ; $F33A   ; 0x03_F34A                                                       ;             ;         ;