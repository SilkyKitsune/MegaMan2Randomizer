; Large gaps between addresses are indicated by a line of periods -> '.'

; JP Version                                                                              ; NA Differences
;                 ;             ; Mapped  ; File      ;                                   ;                 ;             ; Mapped  ; File      ;
; Instructions    ; Bytes       ; Address ; Address   ; Comments                          ; Instructions    ; Bytes       ; Address ; Address   ; Comments
; --------------------------------------------------------------                          ; --------------------------------------------------------------
LDA $9A           ; A5 9A       ; $802B   ; 0x03_403B ; load boss bitfield, ???                             ;             ;         ;
STA $01           ; 85 01       ; $802D   ; 0x03_403D                                                       ;             ;         ;
STX $00           ; 86 00       ; $802F   ; 0x03_403F                                                       ;             ;         ;
LSR $01           ; 46 01       ; $8031   ; 0x03_4041                                                       ;             ;         ;
BCC $2C           ; 90 2C       ; $8033   ; 0x03_4043 ; branch to $8061                                     ;             ;         ;
LDA $8531,X       ; BD 31 85    ; $8035   ; 0x03_4045                                                       ;             ;         ;
STA $09           ; 85 09       ; $8038   ; 0x03_4048                                                       ;             ;         ;
LDA $8539,X       ; BD 39 85    ; $803A   ; 0x03_404A                                                       ;             ;         ;
STA $08           ; 85 08       ; $803D   ; 0x03_404D                                                       ;             ;         ;
LDX #$04          ; A2 04       ; $803F   ; 0x03_404F                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $8041   ; 0x03_4051                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $8072   ; 0x03_4082 ; load boss bitfield, every stage select load         ;             ;         ;
STA $02           ; 85 02       ; $8074   ; 0x03_4084                                                       ;             ;         ;
LDY #$00          ; A0 00       ; $8076   ; 0x03_4086                                                       ;             ;         ;
STX $01           ; 86 01       ; $8078   ; 0x03_4088                                                       ;             ;         ;
LSR $02           ; 46 02       ; $807A   ; 0x03_408A                                                       ;             ;         ;
BCS $15           ; B0 15       ; $807C   ; 0x03_408C ; branch to $8093                                     ;             ;         ;
LDA $8605,X       ; BD 05 86    ; $807E   ; 0x03_408E                                                       ;             ;         ;
STA $00           ; 85 00       ; $8081   ; 0x03_4091                                                       ;             ;         ;
LDA $85FD,X       ; BD FD 85    ; $8083   ; 0x03_4093                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDX $2A           ; A6 2A       ; $80C8   ; 0x03_40D8                                                       ;             ;         ;
BNE $0D           ; D0 0D       ; $80CA   ; 0x03_40DA ; branch to $80D9                                     ;             ;         ;
LDA $9A           ; A5 9A       ; $80CC   ; 0x03_40DC ; load boss bitfield,                                 ;             ;         ;
CMP #$FF          ; C9 FF       ; $80CE   ; 0x03_40DE   ; first stage select load, maybe others             ;             ;         ;
BNE $ED           ; D0 ED       ; $80D0   ; 0x03_40E0 ; branch to $80BF                                     ;             ;         ;
LDA #$08          ; A9 08       ; $80D2   ; 0x03_40E2 ; index of wily stage 1,                              ;             ;         ;
STA $2A           ; 85 2A       ; $80D4   ; 0x03_40E4   ; this might actually be the placement of the cursor;             ;         ;
JMP $829A         ; 4C 9A 82    ; $80D6   ; 0x03_40E6                                                       ;             ;         ;
LDY $865F,X       ; BC 5F 86    ; $80D9   ; 0x03_40E9                                                       ;             ;         ;
LDA $9A           ; A5 9A       ; $80DC   ; 0x03_40EC ; load boss bitfield, stage chosen                    ;             ;         ;
AND $86D1,Y       ; 39 D1 86    ; $80DE   ; 0x03_40EE                                                       ;             ;         ;
BNE $DC           ; D0 DC       ; $80E1   ; 0x03_40F1 ; branch to $80BF                                     ;             ;         ;
STY $2A           ; 84 2A       ; $80E3   ; 0x03_40F3                                                       ;             ;         ;
LDA #$3A          ; A9 3A       ; $80E5   ; 0x03_40F5                                                       ;             ;         ;
JSR $C051         ; 20 51 C0    ; $80E7   ; 0x03_40F7                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $91EF   ; 0x03_51FF ; load boss bitfield, pause menu close                ;             ;         ;
ASL               ; 0A          ; $91F1   ; 0x03_5201                                                       ;             ;         ;
ORA #$41          ; 09 41       ; $91F2   ; 0x03_5202                                                       ;             ;         ;
STA $07           ; 85 07       ; $91F4   ; 0x03_5204                                                       ;             ;         ;
LDA $FE           ; A5 FE       ; $91F6   ; 0x03_5206                                                       ;             ;         ;
BEQ $11           ; F0 11       ; $91F8   ; 0x03_5208 ; branch to $920B                                     ;             ;         ;
LDA $9A           ; A5 9A       ; $91FA   ; 0x03_520A ; load boss bitfield,                                 ;             ;         ;
STA $07           ; 85 07       ; $91FC   ; 0x03_520C   ; pause menu page 2, run continuously               ;             ;         ;
LDA $9B           ; A5 9B       ; $91FE   ; 0x03_520E ; load item bitfield                                  ;             ;         ;
ASL $07           ; 06 07       ; $9200   ; 0x03_5210                                                       ;             ;         ;
ROL               ; 2A          ; $9202   ; 0x03_5212                                                       ;             ;         ;
ASL $07           ; 06 07       ; $9203   ; 0x03_5213                                                       ;             ;         ;
ROL               ; 2A          ; $9205   ; 0x03_5215                                                       ;             ;         ;
ASL $07           ; 06 07       ; $9206   ; 0x03_5216                                                       ;             ;         ;
ROL               ; 2A          ; $9208   ; 0x03_5218                                                       ;             ;         ;
STA $07           ; 85 07       ; $9209   ; 0x03_5219                                                       ;             ;         ;
LDA $27           ; A5 27       ; $920B   ; 0x03_521B                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $93AF   ; 0x03_53BF ; load boss bitfield,                                 ;             ;         ;
ASL               ; 0A          ; $93B1   ; 0x03_53C1   ; pause menu page 1, run continuously               ;             ;         ;
ORA #$01          ; 09 01       ; $93B2   ; 0x03_53C2                                                       ;             ;         ;
STA $07           ; 85 07       ; $93B4   ; 0x03_53C4                                                       ;             ;         ;
LDA #$05          ; A9 05       ; $93B6   ; 0x03_53C6                                                       ;             ;         ;
STA $01           ; 85 01       ; $93B8   ; 0x03_53C8                                                       ;             ;         ;
LDX #$00          ; A2 00       ; $93BA   ; 0x03_53CA                                                       ;             ;         ;
LDA $FE           ; A5 FE       ; $93BC   ; 0x03_53CC                                                       ;             ;         ;
BEQ $13           ; F0 13       ; $93BE   ; 0x03_53CE ; branch to $93D3                                     ;             ;         ;
LDX #$06          ; A2 06       ; $93C0   ; 0x03_53D0                                                       ;             ;         ;
LDA $9A           ; A5 9A       ; $93C2   ; 0x03_53D2 ; load boss bitfield,                                 ;             ;         ;
STA $07           ; 85 07       ; $93C4   ; 0x03_53D4   ; pause menu page 2, run continuously               ;             ;         ;
LDA $9B           ; A5 9B       ; $93C6   ; 0x03_53D6 ; load item bitfield                                  ;             ;         ;
ASL $07           ; 06 07       ; $93C8   ; 0x03_53D8                                                       ;             ;         ;
ROL               ; 2A          ; $93CA   ; 0x03_53DA                                                       ;             ;         ;
ASL $07           ; 06 07       ; $93CB   ; 0x03_53DB                                                       ;             ;         ;
ROL               ; 2A          ; $93CD   ; 0x03_53DD                                                       ;             ;         ;
ASL $07           ; 06 07       ; $93CE   ; 0x03_53DE                                                       ;             ;         ;
ROL               ; 2A          ; $93D0   ; 0x03_53E0                                                       ;             ;         ;
STA $07           ; 85 07       ; $93D1   ; 0x03_53E1                                                       ;             ;         ;
LDA $07           ; A5 07       ; $93D3   ; 0x03_53E3                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

JSR $A974         ; 20 74 A9    ; $A2DC   ; 0x03_62EC                                       JSR $A9B2       ; 20 B2 A9    ; $A30E   ; 0x03_631E
LDA #$00          ; A9 00       ; $A2DF   ; 0x03_62EF                                                       ;             ; $A311   ; 0x03_6321
STA $FD           ; 85 FD       ; $A2E1   ; 0x03_62F1                                                       ;             ; $A313   ; 0x03_6323
STA $9A           ; 85 9A       ; $A2E3   ; 0x03_62F3 ; write boss bitfield, I think is set at start/password screen        ;             ; $A315   ; 0x03_6325
STA $9B           ; 85 9B       ; $A2E5   ; 0x03_62F5 ; write to item bitfield                              ;             ; $A317   ; 0x03_6327
LDX #$03          ; A2 03       ; $A2E7   ; 0x03_62F7                                                       ;             ; $A319   ; 0x03_6329
LDA $AEE0,X       ; BD E0 AE    ; $A2E9   ; 0x03_62F9                                       LDA $AFC7,X     ; BD C7 AF    ; $A31B   ; 0x03_632B
STA $0200,X       ; 9D 00 02    ; $A2EC   ; 0x03_62FC                                                       ;             ; $A31E   ; 0x03_632E
DEX               ; CA          ; $A2EF   ; 0x03_62FF                                                       ;             ; $A321   ; 0x03_6331
BPL $F7           ; 10 F7       ; $A2F0   ; 0x03_6300 ; branch to $A2E9                                     ;             ; $A322   ; 0x03_6332 ; branch to $A31B
LDA $1C           ; A5 1C       ; $A2F2   ; 0x03_6302                                                       ;             ; $A324   ; 0x03_6334
AND #$08          ; 29 08       ; $A2F4   ; 0x03_6304                                                       ;             ; $A326   ; 0x03_6336

; ...................................................                                     ; ...................................................

LDA $02           ; A5 02       ; $A47B   ; 0x03_648B                                                       ;             ; $A4AD   ; 0x03_64BD
STA $9A           ; 85 9A       ; $A47D   ; 0x03_648D ; write boss bitfield, ???                            ;             ; $A4AF   ; 0x03_64BF
AND #$03          ; 29 03       ; $A47F   ; 0x03_648F                                                       ;             ; $A4B1   ; 0x03_64C1
STA $9B           ; 85 9B       ; $A481   ; 0x03_6491 ; write to item bitfield                              ;             ; $A4B3   ; 0x03_64C3
LDA $9A           ; A5 9A       ; $A483   ; 0x03_6493 ; load boss bitfield, ???                             ;             ; $A4B5   ; 0x03_64C5
AND #$20          ; 29 20       ; $A485   ; 0x03_6495                                                       ;             ; $A4B7   ; 0x03_64C7
LSR               ; 4A          ; $A487   ; 0x03_6497                                                       ;             ; $A4B9   ; 0x03_64C9
LSR               ; 4A          ; $A488   ; 0x03_6498                                                       ;             ; $A4BA   ; 0x03_64CA
LSR               ; 4A          ; $A489   ; 0x03_6499                                                       ;             ; $A4BB   ; 0x03_64CB
ORA $9B           ; 05 9B       ; $A48A   ; 0x03_649A ; OR with item bitfield                               ;             ; $A4BC   ; 0x03_64CC
STA $9B           ; 85 9B       ; $A48C   ; 0x03_649C ; write to item bitfield                              ;             ; $A4BE   ; 0x03_64CE

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $A4B1   ; 0x03_64C1 ; load boss bitfield, ???                             ;             ; $A4E3   ; 0x03_64F3
STA $01           ; 85 01       ; $A4B3   ; 0x03_64C3                                                       ;             ; $A4E5   ; 0x03_64F5
LDA $9B           ; A5 9B       ; $A4B5   ; 0x03_64C5 ; load item bitfield                                  ;             ; $A4E7   ; 0x03_64F7
STA $02           ; 85 02       ; $A4B7   ; 0x03_64C7                                                       ;             ; $A4E9   ; 0x03_64F9
LDX #$00          ; A2 00       ; $A4B9   ; 0x03_64C9                                                       ;             ; $A4EB   ; 0x03_64FB
BEQ $0C           ; F0 0C       ; $A4BB   ; 0x03_64CB ; branch to $A4C9                                     ;             ; $A4ED   ; 0x03_64FD ; branch to $A4FB
LSR $02           ; 46 02       ; $A4BD   ; 0x03_64CD                                                       ;             ; $A4EF   ; 0x03_64FF

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $B150   ; 0x03_7160 ; load boss bitfield, ???                             ;             ; $B237   ; 0x03_7247
STA $00           ; 85 00       ; $B152   ; 0x03_7162                                                       ;             ; $B239   ; 0x03_7249
EOR #$FF          ; 49 FF       ; $B154   ; 0x03_7164                                                       ;             ; $B23B   ; 0x03_724B
STA $01           ; 85 01       ; $B156   ; 0x03_7166                                                       ;             ; $B23D   ; 0x03_724D
CLC               ; 18          ; $B158   ; 0x03_7168                                                       ;             ; $B23F   ; 0x03_724F

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $B1AF   ; 0x03_71BF ; load boss bitfield,                                 ;             ; $B296   ; 0x03_72A6
ASL               ; 0A          ; $B1B1   ; 0x03_71C1   ; password screen after weapon get                  ;             ; $B298   ; 0x03_72A8
ORA #$01          ; 09 01       ; $B1B2   ; 0x03_71C2                                                       ;             ; $B299   ; 0x03_72A9
STA $00           ; 85 00       ; $B1B4   ; 0x03_71C4                                                       ;             ; $B29B   ; 0x03_72AB
LDA $9B           ; A5 9B       ; $B1B6   ; 0x03_71C6 ; load item bitfield                                  ;             ; $B29D   ; 0x03_72AD
ROL               ; 2A          ; $B1B8   ; 0x03_71C8                                                       ;             ; $B29F   ; 0x03_72AF

; ...................................................                                     ; ...................................................

LDA $9A           ; A5 9A       ; $8066   ; 0x03_8076 ; load boss bitfield, ???                             ;             ;         ;
CMP #$FF          ; C9 FF       ; $8068   ; 0x03_8078                                                       ;             ;         ;
BNE $06           ; D0 06       ; $806A   ; 0x03_807A ; branch to $8072                                     ;             ;         ;
LDA #$08          ; A9 08       ; $806C   ; 0x03_807C                                                       ;             ;         ;
STA $2A           ; 85 2A       ; $806E   ; 0x03_807E                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDA $C279,X       ; BD 79 C2    ; $8239   ; 0x03_C249 ; load boss bitflag, called just before weapon get screen     ;             ;         ;
ORA $9A           ; 05 9A       ; $823C   ; 0x03_C24C ; OR with boss bitfield                               ;             ;         ;
STA $9A           ; 85 9A       ; $823E   ; 0x03_C24E ; write to boss bitfield                              ;             ;         ;
LDA $C281,X       ; BD 81 C2    ; $8240   ; 0x03_C250 ; load item bitflag                                   ;             ;         ;
ORA $9B           ; 05 9B       ; $8243   ; 0x03_C253 ; OR with item bitfield                               ;             ;         ;
STA $9B           ; 85 9B       ; $8245   ; 0x03_C255 ; write to item bitfield                              ;             ;         ;
LDA #$0D          ; A9 0D       ; $8247   ; 0x03_C257                                                       ;             ;         ;
JSR $C000         ; 20 00 C0    ; $8249   ; 0x03_C259                                                       ;             ;         ;
JSR $8012         ; 20 12 80    ; $824C   ; 0x03_C25C                                                       ;             ;         ;
LDA #$0E          ; A9 0E       ; $824F   ; 0x03_C25F                                                       ;             ;         ;
JSR $C000         ; 20 00 C0    ; $8251   ; 0x03_C261                                                       ;             ;         ;
LDA $9A           ; A5 9A       ; $8254   ; 0x03_C264 ; load boss bitfield,                                 ;             ;         ;
CMP #$FF          ; C9 FF       ; $8256   ; 0x03_C266   ; load stage select after weapon get                ;             ;         ;
BEQ $03           ; F0 03       ; $8258   ; 0x03_C268 ; branch to $825D                                     ;             ;         ;
JMP $8076         ; 4C 76 80    ; $825A   ; 0x03_C26A                                                       ;             ;         ;
LDA #$07          ; A9 07       ; $825D   ; 0x03_C26D                                                       ;             ;         ;
STA $2A           ; 85 2A       ; $825F   ; 0x03_C26F                                                       ;             ;         ;
INC $2A           ; E6 2A       ; $8261   ; 0x03_C271                                                       ;             ;         ;
LDA $2A           ; A5 2A       ; $8263   ; 0x03_C273                                                       ;             ;         ;
CMP #$0E          ; C9 0E       ; $8265   ; 0x03_C275                                                       ;             ;         ;
BNE $0D           ; D0 0D       ; $8267   ; 0x03_C277 ; branch to $8276                                     ;             ;         ;
LDA #$0D          ; A9 0D       ; $8269   ; 0x03_C279                                                       ;             ;         ;
JSR $C000         ; 20 00 C0    ; $826B   ; 0x03_C27B                                                       ;             ;         ;
JSR $800F         ; 20 0F 80    ; $826E   ; 0x03_C27E                                                       ;             ;         ;



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