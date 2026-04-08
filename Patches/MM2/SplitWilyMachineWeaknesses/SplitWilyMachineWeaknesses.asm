; Large gaps between addresses are indicated by a line of periods -> '.'

; JP Version                                                                              ; NA Differences
;                 ;             ; Mapped  ; File      ;                                   ;                 ;             ; Mapped  ; File      ;
; Instructions    ; Bytes       ; Address ; Address   ; Comments                          ; Instructions    ; Bytes       ; Address ; Address   ; Comments
; --------------------------------------------------------------                          ; --------------------------------------------------------------
LDA #$0F          ; A9 0F       ; $9A10   ; 0x02_DA20                                                       ;             ;         ;
STA $0366         ; 8D 66 03    ; $9A12   ; 0x02_DA22                                                       ;             ;         ;
LDA $B1           ; A5 B1       ; $9A15   ; 0x02_DA25 ; load boss state?                                    ;             ;         ;
CMP #$04          ; C9 04       ; $9A17   ; 0x02_DA27 ; compare against phase 2 states                      ;             ;         ;
BCS $0C           ; B0 0C       ; $9A19   ; 0x02_DA29 ; branch to $9A27                                     ;             ;         ;
LDA $A9           ; A5 A9       ; $9A1B   ; 0x02_DA2B ; load weapon index                                   ;             ;         ;
CMP #$02          ; C9 02       ; $9A1D   ; 0x02_DA2D ; compare against air shooter                         ;             ;         ;
BEQ $0C           ; F0 0C       ; $9A1F   ; 0x02_DA2F ; branch to $9A2D                                     ;             ;         ;
CMP #$05          ; C9 05       ; $9A21   ; 0x02_DA31 ; compare against quick boomerang                     ;             ;         ;
BEQ $08           ; F0 08       ; $9A23   ; 0x02_DA33 ; branch to $9A2D                                     ;             ;         ;
BNE $0E           ; D0 0E       ; $9A25   ; 0x02_DA35 ; branch to $9A35                                     ;             ;         ;
LDA $A9           ; A5 A9       ; $9A27   ; 0x02_DA37 ; load weapon index                                   ;             ;         ;
CMP #$01          ; C9 01       ; $9A29   ; 0x02_DA39 ; compare against atomic fire                         ;             ;         ;
BNE $08           ; D0 08       ; $9A2B   ; 0x02_DA3B ; branch to $9A35                                     ;             ;         ;
LDA $0421         ; AD 21 04    ; $9A2D   ; 0x02_DA3D ; load boss flags                                     ;             ;         ;
ORA #$08          ; 09 08       ; $9A30   ; 0x02_DA40 ; set invincible flag                                 ;             ;         ;
STA $0421         ; 8D 21 04    ; $9A32   ; 0x02_DA42 ; write boss flags                                    ;             ;         ;
JSR $A59D         ; 20 9D A5    ; $9A35   ; 0x02_DA45                                                       ;             ;         ;
BCC $43           ; 90 43       ; $9A38   ; 0x02_DA48 ; branch to $9A7D                                     ;             ;         ;
LDA $B1           ; A5 B1       ; $9A3A   ; 0x02_DA4A                                                       ;             ;         ;
CMP #$04          ; C9 04       ; $9A3C   ; 0x02_DA4C                                                       ;             ;         ;
BCS $16           ; B0 16       ; $9A3E   ; 0x02_DA4E ; branch to $9A56                                     ;             ;         ;
LDA #$04          ; A9 04       ; $9A40   ; 0x02_DA50                                                       ;             ;         ;
STA $B1           ; 85 B1       ; $9A42   ; 0x02_DA52                                                       ;             ;         ;
LDA #$0C          ; A9 0C       ; $9A44   ; 0x02_DA54                                                       ;             ;         ;
STA $05AB         ; 8D AB 05    ; $9A46   ; 0x02_DA56                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $9A49   ; 0x02_DA59                                                       ;             ;         ;
STA $0601         ; 8D 01 06    ; $9A4B   ; 0x02_DA5B                                                       ;             ;         ;
STA $0621         ; 8D 21 06    ; $9A4E   ; 0x02_DA5E                                                       ;             ;         ;
STA $04E1         ; 8D E1 04    ; $9A51   ; 0x02_DA61                                                       ;             ;         ;
BEQ $32           ; F0 32       ; $9A54   ; 0x02_DA64 ; branch to $9A88                                     ;             ;         ;
LDA #$74          ; A9 74       ; $9A56   ; 0x02_DA66                                                       ;             ;         ;
JSR $A10C         ; 20 0C A1    ; $9A58   ; 0x02_DA68                                                       ;             ;         ;
CLC               ; 18          ; $9A5B   ; 0x02_DA6B                                                       ;             ;         ;
LDA $0461         ; AD 61 04    ; $9A5C   ; 0x02_DA6C                                                       ;             ;         ;
ADC #$28          ; 69 28       ; $9A5F   ; 0x02_DA6F                                                       ;             ;         ;
STA $0461         ; 8D 61 04    ; $9A61   ; 0x02_DA71                                                       ;             ;         ;
LDA #$57          ; A9 57       ; $9A64   ; 0x02_DA74                                                       ;             ;         ;
STA $04A1         ; 8D A1 04    ; $9A66   ; 0x02_DA76                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $9A69   ; 0x02_DA79                                                       ;             ;         ;
STA $04E1         ; 8D E1 04    ; $9A6B   ; 0x02_DA7B                                                       ;             ;         ;
LDA #$56          ; A9 56       ; $9A6E   ; 0x02_DA7E                                                       ;             ;         ;
JSR $A22D         ; 20 2D A2    ; $9A70   ; 0x02_DA80                                                       ;             ;         ;
BCS $05           ; B0 05       ; $9A73   ; 0x02_DA83 ; branch to $9A7A                                     ;             ;         ;
LDA #$00          ; A9 00       ; $9A75   ; 0x02_DA85                                                       ;             ;         ;
STA $0430,Y       ; 99 30 04    ; $9A77   ; 0x02_DA87                                                       ;             ;         ;
JMP $9625         ; 4C 25 96    ; $9A7A   ; 0x02_DA8A                                                       ;             ;         ;
LDA $02           ; A5 02       ; $9A7D   ; 0x02_DA8D                                                       ;             ;         ;
CMP #$01          ; C9 01       ; $9A7F   ; 0x02_DA8F                                                       ;             ;         ;
BNE $05           ; D0 05       ; $9A81   ; 0x02_DA91 ; branch to $9A88                                     ;             ;         ;
LDA #$30          ; A9 30       ; $9A83   ; 0x02_DA93                                                       ;             ;         ;
STA $0366         ; 8D 66 03    ; $9A85   ; 0x02_DA95                                                       ;             ;         ;
JSR $91A4         ; 20 A4 91    ; $9A88   ; 0x02_DA98                                                       ;             ;         ;
RTS               ; 60          ; $9A8B   ; 0x02_DA9B                                                       ;             ;         ;



; New Instructions
; -----------------------------------------------------
; gonna remove 0x02_DA25 - 0x02_DA42 which leaves 0x20 bytes available for possible future changes