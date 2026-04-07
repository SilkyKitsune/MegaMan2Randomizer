; Large gaps between addresses are indicated by a line of periods -> '.'

; JP Version                                                                              ; NA Differences
;                 ;             ; Mapped  ; File      ;                                   ;                 ;             ; Mapped  ; File      ;
; Instructions    ; Bytes       ; Address ; Address   ; Comments                          ; Instructions    ; Bytes       ; Address ; Address   ; Comments
; --------------------------------------------------------------                          ; --------------------------------------------------------------
JSR $D478         ; 20 78 D4    ; $B0F2   ; 0x01_B102 ; pause menu                                          ;             ; $B0FA   ; 0x01_B10A
LDA #$F8          ; A9 F8       ; $B0F5   ; 0x01_B105                                                       ;             ; $B0FD   ; 0x01_B10D
STA $0605         ; 8D 05 06    ; $B0F7   ; 0x01_B107                                                       ;             ; $B0FF   ; 0x01_B10F
LDA #$00          ; A9 00       ; $B0FA   ; 0x01_B10A                                                       ;             ; $B102   ; 0x01_B112
JSR $B3B7         ; 20 B7 B3    ; $B0FC   ; 0x01_B10C                                     JSR $B3BF         ; 20 BF B3    ; $B104   ; 0x01_B114
LDA #$22          ; A9 22       ; $B0FF   ; 0x01_B10F                                                       ;             ; $B107   ; 0x01_B117
JSR $C477         ; 20 77 C4    ; $B101   ; 0x01_B111                                                       ;             ; $B109   ; 0x01_B119
JSR $C01B         ; 20 1B C0    ; $B104   ; 0x01_B114                                                       ;             ; $B10C   ; 0x01_B11C
LDA #$0E          ; A9 0E       ; $B107   ; 0x01_B117                                                       ;             ; $B10F   ; 0x01_B11F
STA $0380         ; 8D 80 03    ; $B109   ; 0x01_B119                                                       ;             ; $B111   ; 0x01_B121
LDA #$00          ; A9 00       ; $B10C   ; 0x01_B11C                                                       ;             ; $B114   ; 0x01_B124
STA $0381         ; 8D 81 03    ; $B10E   ; 0x01_B11E                                                       ;             ; $B116   ; 0x01_B126
STA $47           ; 85 47       ; $B111   ; 0x01_B121                                                       ;             ; $B119   ; 0x01_B129
STA $5B           ; 85 5B       ; $B113   ; 0x01_B123                                                       ;             ; $B11B   ; 0x01_B12B
STA $3C           ; 85 3C       ; $B115   ; 0x01_B125                                                       ;             ; $B11D   ; 0x01_B12D
STA $B4           ; 85 B4       ; $B117   ; 0x01_B127                                                       ;             ; $B11F   ; 0x01_B12F
STA $94           ; 85 94       ; $B119   ; 0x01_B129                                                       ;             ; $B121   ; 0x01_B131
STA $95           ; 85 95       ; $B11B   ; 0x01_B12B                                                       ;             ; $B123   ; 0x01_B133
STA $B1           ; 85 B1       ; $B11D   ; 0x01_B12D                                                       ;             ; $B125   ; 0x01_B135
LDA $5D           ; A5 5D       ; $B11F   ; 0x01_B12F ; load boss bitfield                                  ;             ; $B127   ; 0x01_B137
STA $5A           ; 85 5A       ; $B121   ; 0x01_B131                                                       ;             ; $B129   ; 0x01_B139
LDX #$00          ; A2 00       ; $B123   ; 0x01_B133                                                       ;             ; $B12B   ; 0x01_B13B
STX $59           ; 86 59       ; $B125   ; 0x01_B135                                                       ;             ; $B12D   ; 0x01_B13D
LDA #$00          ; A9 00       ; $B127   ; 0x01_B137                                                       ;             ; $B12F   ; 0x01_B13F
STA $0D           ; 85 0D       ; $B129   ; 0x01_B139                                                       ;             ; $B131   ; 0x01_B141
JSR $CE9A         ; 20 9A CE    ; $B12B   ; 0x01_B13B                                                       ;             ; $B133   ; 0x01_B143
LDX #$12          ; A2 12       ; $B12E   ; 0x01_B13E                                                       ;             ; $B136   ; 0x01_B146
JSR $CF06         ; 20 06 CF    ; $B130   ; 0x01_B140                                                       ;             ; $B138   ; 0x01_B148
LDY $31           ; A4 31       ; $B133   ; 0x01_B143                                                       ;             ; $B13B   ; 0x01_B14B
LDA $B4DC,Y       ; B9 DC B4    ; $B135   ; 0x01_B145                                     LDA $B4E4,Y       ; B9 E4 B4    ; $B13D   ; 0x01_B14D
STA $0300,X       ; 9D 00 03    ; $B138   ; 0x01_B148                                                       ;             ; $B140   ; 0x01_B150
LDA #$01          ; A9 01       ; $B13B   ; 0x01_B14B                                                       ;             ; $B143   ; 0x01_B153
STA $1C           ; 85 1C       ; $B13D   ; 0x01_B14D                                                       ;             ; $B145   ; 0x01_B155
JSR $B3C9         ; 20 C9 B3    ; $B13F   ; 0x01_B14F                                     JSR $B3D1         ; 20 D1 B3    ; $B147   ; 0x01_B157
JSR $C01B         ; 20 1B C0    ; $B142   ; 0x01_B152                                                       ;             ; $B14A   ; 0x01_B15A
LDA $0381         ; AD 81 03    ; $B145   ; 0x01_B155                                                       ;             ; $B14D   ; 0x01_B15D
CLC               ; 18          ; $B148   ; 0x01_B158                                                       ;             ; $B150   ; 0x01_B160
ADC #$10          ; 69 10       ; $B149   ; 0x01_B159                                                       ;             ; $B151   ; 0x01_B161
STA $0381         ; 8D 81 03    ; $B14B   ; 0x01_B15B                                                       ;             ; $B153   ; 0x01_B163
LDX $59           ; A6 59       ; $B14E   ; 0x01_B15E                                                       ;             ; $B156   ; 0x01_B166
INX               ; E8          ; $B150   ; 0x01_B160                                                       ;             ; $B158   ; 0x01_B168
CPX #$03          ; E0 03       ; $B151   ; 0x01_B161                                                       ;             ; $B159   ; 0x01_B169
BEQ $10           ; F0 10       ; $B153   ; 0x01_B163 ; branch to $B165                                     ;             ; $B15B   ; 0x01_B16B ; branch to $B16D
CLC               ; 18          ; $B155   ; 0x01_B165                                                       ;             ; $B15D   ; 0x01_B16D
LDA $04           ; A5 04       ; $B156   ; 0x01_B166                                                       ;             ; $B15E   ; 0x01_B16E
ADC #$20          ; 69 20       ; $B158   ; 0x01_B168                                                       ;             ; $B160   ; 0x01_B170
STA $04           ; 85 04       ; $B15A   ; 0x01_B16A                                                       ;             ; $B162   ; 0x01_B172
LDA $05           ; A5 05       ; $B15C   ; 0x01_B16C                                                       ;             ; $B164   ; 0x01_B174
ADC #$00          ; 69 00       ; $B15E   ; 0x01_B16E                                                       ;             ; $B166   ; 0x01_B176
STA $05           ; 85 05       ; $B160   ; 0x01_B170                                                       ;             ; $B168   ; 0x01_B178
JMP $B125         ; 4C 25 B1    ; $B162   ; 0x01_B172                                     JMP $B12D         ; 4C 2D B1    ; $B16A   ; 0x01_B17A
INC $3C           ; E6 3C       ; $B165   ; 0x01_B175                                                       ;             ; $B16D   ; 0x01_B17D
LDA $3C           ; A5 3C       ; $B167   ; 0x01_B177                                                       ;             ; $B16F   ; 0x01_B17F
CMP #$05          ; C9 05       ; $B169   ; 0x01_B179                                                       ;             ; $B171   ; 0x01_B181
BEQ $0E           ; F0 0E       ; $B16B   ; 0x01_B17B ; branch to $B17B                                     ;             ; $B173   ; 0x01_B183 ; branch to $B183
ASL               ; 0A          ; $B16D   ; 0x01_B17D                                                       ;             ; $B175   ; 0x01_B185
ASL               ; 0A          ; $B16E   ; 0x01_B17E                                                       ;             ; $B176   ; 0x01_B186
CLC               ; 18          ; $B16F   ; 0x01_B17F                                                       ;             ; $B177   ; 0x01_B187
ADC $57           ; 65 57       ; $B170   ; 0x01_B180                                                       ;             ; $B178   ; 0x01_B188
STA $04           ; 85 04       ; $B172   ; 0x01_B182                                                       ;             ; $B17A   ; 0x01_B18A
LDA $58           ; A5 58       ; $B174   ; 0x01_B184                                                       ;             ; $B17C   ; 0x01_B18C
STA $05           ; 85 05       ; $B176   ; 0x01_B186                                                       ;             ; $B17E   ; 0x01_B18E
JMP $B123         ; 4C 23 B1    ; $B178   ; 0x01_B188                                     JMP $B12B         ; 4C 2B B1    ; $B180   ; 0x01_B190
LDA #$20          ; A9 20       ; $B17B   ; 0x01_B18B                                                       ;             ; $B183   ; 0x01_B193
STA $0F           ; 85 0F       ; $B17D   ; 0x01_B18D                                                       ;             ; $B185   ; 0x01_B195
LDX #$01          ; A2 01       ; $B17F   ; 0x01_B18F                                                       ;             ; $B187   ; 0x01_B197
STX $0C           ; 86 0C       ; $B181   ; 0x01_B191                                                       ;             ; $B189   ; 0x01_B199
LDA $1A           ; A5 1A       ; $B183   ; 0x01_B193                                                       ;             ; $B18B   ; 0x01_B19B
AND #$1F          ; 29 1F       ; $B185   ; 0x01_B195                                                       ;             ; $B18D   ; 0x01_B19D
STA $0D           ; 85 0D       ; $B187   ; 0x01_B197                                                       ;             ; $B18F   ; 0x01_B19F
LDA #$9B          ; A9 9B       ; $B189   ; 0x01_B199                                                       ;             ; $B191   ; 0x01_B1A1
SEC               ; 38          ; $B18B   ; 0x01_B19B                                                       ;             ; $B193   ; 0x01_B1A3
SBC $0D           ; E5 0D       ; $B18C   ; 0x01_B19C                                                       ;             ; $B194   ; 0x01_B1A4
STA $0D           ; 85 0D       ; $B18E   ; 0x01_B19E                                                       ;             ; $B196   ; 0x01_B1A6
LDY $B517,X       ; BC 17 B5    ; $B190   ; 0x01_B1A0                                     LDY $B51F,X       ; BC 1F B5    ; $B198   ; 0x01_B1A8
LDA $5D           ; A5 5D       ; $B193   ; 0x01_B1A3 ; load boss bitfield                                  ;             ; $B19B   ; 0x01_B1AB
AND $B50D,X       ; 3D 0D B5    ; $B195   ; 0x01_B1A5                                     AND $B515,X       ; 3D 15 B5    ; $B19D   ; 0x01_B1AD
BEQ $52           ; F0 52       ; $B198   ; 0x01_B1A8 ; branch to $B1EC                                     ;             ; $B1A0   ; 0x01_B1B0 ; branch to $B1F4
TXA               ; 8A          ; $B19A   ; 0x01_B1AA                                                       ;             ; $B1A2   ; 0x01_B1B2
ASL               ; 0A          ; $B19B   ; 0x01_B1AB                                                       ;             ; $B1A3   ; 0x01_B1B3
TAX               ; AA          ; $B19C   ; 0x01_B1AC                                                       ;             ; $B1A4   ; 0x01_B1B4
LDA $B4E7,X       ; BD E7 B4    ; $B19D   ; 0x01_B1AD                                     LDA $B4EF,X       ; BD EF B4    ; $B1A5   ; 0x01_B1B5
STA $0E           ; 85 0E       ; $B1A0   ; 0x01_B1B0                                                       ;             ; $B1A8   ; 0x01_B1B8
LDA $006A,Y       ; B9 6A 00    ; $B1A2   ; 0x01_B1B2                                                       ;             ; $B1AA   ; 0x01_B1BA
PHA               ; 48          ; $B1A5   ; 0x01_B1B5                                                       ;             ; $B1AD   ; 0x01_B1BD
LSR               ; 4A          ; $B1A6   ; 0x01_B1B6                                                       ;             ; $B1AE   ; 0x01_B1BE
LSR               ; 4A          ; $B1A7   ; 0x01_B1B7                                                       ;             ; $B1AF   ; 0x01_B1BF
STA $10           ; 85 10       ; $B1A8   ; 0x01_B1B8                                                       ;             ; $B1B0   ; 0x01_B1C0
PLA               ; 68          ; $B1AA   ; 0x01_B1BA                                                       ;             ; $B1B2   ; 0x01_B1C2
AND #$03          ; 29 03       ; $B1AB   ; 0x01_B1BB                                                       ;             ; $B1B3   ; 0x01_B1C3
STA $11           ; 85 11       ; $B1AD   ; 0x01_B1BD                                                       ;             ; $B1B5   ; 0x01_B1C5
SEC               ; 38          ; $B1AF   ; 0x01_B1BF                                                       ;             ; $B1B7   ; 0x01_B1C7
LDA #$EC          ; A9 EC       ; $B1B0   ; 0x01_B1C0                                                       ;             ; $B1B8   ; 0x01_B1C8
SBC $11           ; E5 11       ; $B1B2   ; 0x01_B1C2                                                       ;             ; $B1BA   ; 0x01_B1CA
STA $11           ; 85 11       ; $B1B4   ; 0x01_B1C4                                                       ;             ; $B1BC   ; 0x01_B1CC
LDX #$00          ; A2 00       ; $B1B6   ; 0x01_B1C6                                                       ;             ; $B1BE   ; 0x01_B1CE
CPX $10           ; E4 10       ; $B1B8   ; 0x01_B1C8                                                       ;             ; $B1C0   ; 0x01_B1D0
BCS $04           ; B0 04       ; $B1BA   ; 0x01_B1CA ; branch to $B1C0                                     ;             ; $B1C2   ; 0x01_B1D2 ; branch to $B1C8
LDA #$E8          ; A9 E8       ; $B1BC   ; 0x01_B1CC                                                       ;             ; $B1C4   ; 0x01_B1D4
BNE $08           ; D0 08       ; $B1BE   ; 0x01_B1CE ; branch to $B1C8                                     ;             ; $B1C6   ; 0x01_B1D6 ; branch to $B1D0
BNE $04           ; D0 04       ; $B1C0   ; 0x01_B1D0 ; branch to $B1C6                                     ;             ; $B1C8   ; 0x01_B1D8 ; branch to $B1CE
LDA $11           ; A5 11       ; $B1C2   ; 0x01_B1D2                                                       ;             ; $B1CA   ; 0x01_B1DA
BNE $02           ; D0 02       ; $B1C4   ; 0x01_B1D4 ; branch to $B1C8                                     ;             ; $B1CC   ; 0x01_B1DC ; branch to $B1D0
LDA #$EC          ; A9 EC       ; $B1C6   ; 0x01_B1D6                                                       ;             ; $B1CE   ; 0x01_B1DE
LDY $0F           ; A4 0F       ; $B1C8   ; 0x01_B1D8                                                       ;             ; $B1D0   ; 0x01_B1E0
STA $0205,Y       ; 99 05 02    ; $B1CA   ; 0x01_B1DA                                                       ;             ; $B1D2   ; 0x01_B1E2
LDA $0E           ; A5 0E       ; $B1CD   ; 0x01_B1DD                                                       ;             ; $B1D5   ; 0x01_B1E5
STA $0204,Y       ; 99 04 02    ; $B1CF   ; 0x01_B1DF                                                       ;             ; $B1D7   ; 0x01_B1E7
LDA #$01          ; A9 01       ; $B1D2   ; 0x01_B1E2                                                       ;             ; $B1DA   ; 0x01_B1EA
STA $0206,Y       ; 99 06 02    ; $B1D4   ; 0x01_B1E4                                                       ;             ; $B1DC   ; 0x01_B1EC
LDA $0D           ; A5 0D       ; $B1D7   ; 0x01_B1E7                                                       ;             ; $B1DF   ; 0x01_B1EF
STA $0207,Y       ; 99 07 02    ; $B1D9   ; 0x01_B1E9                                                       ;             ; $B1E1   ; 0x01_B1F1
INY               ; C8          ; $B1DC   ; 0x01_B1EC                                                       ;             ; $B1E4   ; 0x01_B1F4
INY               ; C8          ; $B1DD   ; 0x01_B1ED                                                       ;             ; $B1E5   ; 0x01_B1F5
INY               ; C8          ; $B1DE   ; 0x01_B1EE                                                       ;             ; $B1E6   ; 0x01_B1F6
INY               ; C8          ; $B1DF   ; 0x01_B1EF                                                       ;             ; $B1E7   ; 0x01_B1F7
STY $0F           ; 84 0F       ; $B1E0   ; 0x01_B1F0                                                       ;             ; $B1E8   ; 0x01_B1F8
CLC               ; 18          ; $B1E2   ; 0x01_B1F2                                                       ;             ; $B1EA   ; 0x01_B1FA
ADC #$08          ; 69 08       ; $B1E3   ; 0x01_B1F3                                                       ;             ; $B1EB   ; 0x01_B1FB
STA $0D           ; 85 0D       ; $B1E5   ; 0x01_B1F5                                                       ;             ; $B1ED   ; 0x01_B1FD
INX               ; E8          ; $B1E7   ; 0x01_B1F7                                                       ;             ; $B1EF   ; 0x01_B1FF
CPX #$07          ; E0 07       ; $B1E8   ; 0x01_B1F8                                                       ;             ; $B1F0   ; 0x01_B200
BNE $CC           ; D0 CC       ; $B1EA   ; 0x01_B1FA ; branch to $B1B8                                     ;             ; $B1F2   ; 0x01_B202 ; branch to $B1C0
INC $0C           ; E6 0C       ; $B1EC   ; 0x01_B1FC                                                       ;             ; $B1F4   ; 0x01_B204
LDX $0C           ; A6 0C       ; $B1EE   ; 0x01_B1FE                                                       ;             ; $B1F6   ; 0x01_B206
CPX #$08          ; E0 08       ; $B1F0   ; 0x01_B200                                                       ;             ; $B1F8   ; 0x01_B208
BNE $8F           ; D0 8F       ; $B1F2   ; 0x01_B202 ; branch to $B183                                     ;             ; $B1FA   ; 0x01_B20A ; branch to $B18B
LDA $1A           ; A5 1A       ; $B1F4   ; 0x01_B204                                                       ;             ; $B1FC   ; 0x01_B20C
AND #$1F          ; 29 1F       ; $B1F6   ; 0x01_B206                                                       ;             ; $B1FE   ; 0x01_B20E
STA $0C           ; 85 0C       ; $B1F8   ; 0x01_B208                                                       ;             ; $B200   ; 0x01_B210
SEC               ; 38          ; $B1FA   ; 0x01_B20A                                                       ;             ; $B202   ; 0x01_B212
LDA #$A8          ; A9 A8       ; $B1FB   ; 0x01_B20B                                                       ;             ; $B203   ; 0x01_B213
SBC $0C           ; E5 0C       ; $B1FD   ; 0x01_B20D                                                       ;             ; $B205   ; 0x01_B215
STA $0C           ; 85 0C       ; $B1FF   ; 0x01_B20F                                                       ;             ; $B207   ; 0x01_B217
LDX #$17          ; A2 17       ; $B201   ; 0x01_B211                                                       ;             ; $B209   ; 0x01_B219
LDA $B527,X       ; BD 27 B5    ; $B203   ; 0x01_B213                                     LDA $B52F,X       ; BD 2F B5    ; $B20B   ; 0x01_B21B
STA $02E8,X       ; 9D E8 02    ; $B206   ; 0x01_B216                                                       ;             ; $B20E   ; 0x01_B21E
TXA               ; 8A          ; $B209   ; 0x01_B219                                                       ;             ; $B211   ; 0x01_B221
AND #$03          ; 29 03       ; $B20A   ; 0x01_B21A                                                       ;             ; $B212   ; 0x01_B222
CMP #$03          ; C9 03       ; $B20C   ; 0x01_B21C                                                       ;             ; $B214   ; 0x01_B224
BNE $09           ; D0 09       ; $B20E   ; 0x01_B21E ; branch to $B219                                     ;             ; $B216   ; 0x01_B226 ; branch to $B221
CLC               ; 18          ; $B210   ; 0x01_B220                                                       ;             ; $B218   ; 0x01_B228
LDA $0C           ; A5 0C       ; $B211   ; 0x01_B221                                                       ;             ; $B219   ; 0x01_B229
ADC $02E8,X       ; 7D E8 02    ; $B213   ; 0x01_B223                                                       ;             ; $B21B   ; 0x01_B22B
STA $02E8,X       ; 9D E8 02    ; $B216   ; 0x01_B226                                                       ;             ; $B21E   ; 0x01_B22E
DEX               ; CA          ; $B219   ; 0x01_B229                                                       ;             ; $B221   ; 0x01_B231
BPL $E7           ; 10 E7       ; $B21A   ; 0x01_B22A ; branch to $B203                                     ;             ; $B222   ; 0x01_B232 ; branch to $B20B
LDX $A6           ; A6 A6       ; $B21C   ; 0x01_B22C                                                       ;             ; $B224   ; 0x01_B234
LDY #$00          ; A0 00       ; $B21E   ; 0x01_B22E                                                       ;             ; $B226   ; 0x01_B236
LDA #$0A          ; A9 0A       ; $B220   ; 0x01_B230                                                       ;             ; $B228   ; 0x01_B238
JSR $C5AC         ; 20 AC C5    ; $B222   ; 0x01_B232                                                       ;             ; $B22A   ; 0x01_B23A
LDA $05           ; A5 05       ; $B225   ; 0x01_B235                                                       ;             ; $B22D   ; 0x01_B23D
PHA               ; 48          ; $B227   ; 0x01_B237                                                       ;             ; $B22F   ; 0x01_B23F
ORA #$F0          ; 09 F0       ; $B228   ; 0x01_B238                                                       ;             ; $B230   ; 0x01_B240
STA $02F9         ; 8D F9 02    ; $B22A   ; 0x01_B23A                                                       ;             ; $B232   ; 0x01_B242
PLA               ; 68          ; $B22D   ; 0x01_B23D                                                       ;             ; $B235   ; 0x01_B245
ASL               ; 0A          ; $B22E   ; 0x01_B23E                                                       ;             ; $B236   ; 0x01_B246
STA $05           ; 85 05       ; $B22F   ; 0x01_B23F                                                       ;             ; $B237   ; 0x01_B247
ASL               ; 0A          ; $B231   ; 0x01_B241                                                       ;             ; $B239   ; 0x01_B249
ASL               ; 0A          ; $B232   ; 0x01_B242                                                       ;             ; $B23A   ; 0x01_B24A
ADC $05           ; 65 05       ; $B233   ; 0x01_B243                                                       ;             ; $B23B   ; 0x01_B24B
STA $05           ; 85 05       ; $B235   ; 0x01_B245                                                       ;             ; $B23D   ; 0x01_B24D
SEC               ; 38          ; $B237   ; 0x01_B247                                                       ;             ; $B23F   ; 0x01_B24F
LDA $A6           ; A5 A6       ; $B238   ; 0x01_B248                                                       ;             ; $B240   ; 0x01_B250
SBC $05           ; E5 05       ; $B23A   ; 0x01_B24A                                                       ;             ; $B242   ; 0x01_B252
ORA #$F0          ; 09 F0       ; $B23C   ; 0x01_B24C                                                       ;             ; $B244   ; 0x01_B254
STA $02FD         ; 8D FD 02    ; $B23E   ; 0x01_B24E                                                       ;             ; $B246   ; 0x01_B256
LDY $5F           ; A4 5F       ; $B241   ; 0x01_B251                                                       ;             ; $B249   ; 0x01_B259
LDA $B505,Y       ; B9 05 B5    ; $B243   ; 0x01_B253                                     LDA $B50D,Y       ; B9 0D B5    ; $B24B   ; 0x01_B25B
STA $5F           ; 85 5F       ; $B246   ; 0x01_B256                                                       ;             ; $B24E   ; 0x01_B25E
LDX #$1C          ; A2 1C       ; $B248   ; 0x01_B258                                                       ;             ; $B250   ; 0x01_B260
LDA #$00          ; A9 00       ; $B24A   ; 0x01_B25A                                                       ;             ; $B252   ; 0x01_B262
STA $0206,X       ; 9D 06 02    ; $B24C   ; 0x01_B25C                                                       ;             ; $B254   ; 0x01_B264
DEX               ; CA          ; $B24F   ; 0x01_B25F                                                       ;             ; $B257   ; 0x01_B267
DEX               ; CA          ; $B250   ; 0x01_B260                                                       ;             ; $B258   ; 0x01_B268
DEX               ; CA          ; $B251   ; 0x01_B261                                                       ;             ; $B259   ; 0x01_B269
DEX               ; CA          ; $B252   ; 0x01_B262                                                       ;             ; $B25A   ; 0x01_B26A
BPL $F7           ; 10 F7       ; $B253   ; 0x01_B263 ; branch to $B24C                                     ;             ; $B25B   ; 0x01_B26B ; branch to $B254
LDA $5F           ; A5 5F       ; $B255   ; 0x01_B265                                                       ;             ; $B25D   ; 0x01_B26D
SEC               ; 38          ; $B257   ; 0x01_B267                                                       ;             ; $B25F   ; 0x01_B26F
SBC #$01          ; E9 01       ; $B258   ; 0x01_B268                                                       ;             ; $B260   ; 0x01_B270
AND #$07          ; 29 07       ; $B25A   ; 0x01_B26A                                                       ;             ; $B262   ; 0x01_B272
ASL               ; 0A          ; $B25C   ; 0x01_B26C                                                       ;             ; $B264   ; 0x01_B274
ASL               ; 0A          ; $B25D   ; 0x01_B26D                                                       ;             ; $B265   ; 0x01_B275
TAX               ; AA          ; $B25E   ; 0x01_B26E                                                       ;             ; $B266   ; 0x01_B276
LDA #$01          ; A9 01       ; $B25F   ; 0x01_B26F                                                       ;             ; $B267   ; 0x01_B277
STA $0206,X       ; 9D 06 02    ; $B261   ; 0x01_B271                                                       ;             ; $B269   ; 0x01_B279
LDA $23           ; A5 23       ; $B264   ; 0x01_B274                                                       ;             ; $B26C   ; 0x01_B27C
AND #$07          ; 29 07       ; $B266   ; 0x01_B276                                                       ;             ; $B26E   ; 0x01_B27E
BNE $07           ; D0 07       ; $B268   ; 0x01_B278 ; branch to $B271                                     ;             ; $B270   ; 0x01_B280 ; branch to $B279
LDA $23           ; A5 23       ; $B26A   ; 0x01_B27A                                                       ;             ; $B272   ; 0x01_B282
AND #$08          ; 29 08       ; $B26C   ; 0x01_B27C                                                       ;             ; $B274   ; 0x01_B284
JSR $B39F         ; 20 9F B3    ; $B26E   ; 0x01_B27E                                     JSR $B3A7         ; 20 A7 B3    ; $B276   ; 0x01_B286
JSR $C01B         ; 20 1B C0    ; $B271   ; 0x01_B281                                                       ;             ; $B279   ; 0x01_B289
LDA $18           ; A5 18       ; $B274   ; 0x01_B284                                                       ;             ; $B27C   ; 0x01_B28C
AND #$38          ; 29 38       ; $B276   ; 0x01_B286                                                       ;             ; $B27E   ; 0x01_B28E
BEQ $EA           ; F0 EA       ; $B278   ; 0x01_B288 ; branch to $B264                                     ;             ; $B280   ; 0x01_B290 ; branch to $B26C
PHA               ; 48          ; $B27A   ; 0x01_B28A                                                       ;             ; $B282   ; 0x01_B292
LDA #$01          ; A9 01       ; $B27B   ; 0x01_B28B                                                       ;             ; $B283   ; 0x01_B293
JSR $B39F         ; 20 9F B3    ; $B27D   ; 0x01_B28D                                     JSR $B3A7         ; 20 A7 B3    ; $B285   ; 0x01_B295
PLA               ; 68          ; $B280   ; 0x01_B290                                                       ;             ; $B288   ; 0x01_B298
AND #$30          ; 29 30       ; $B281   ; 0x01_B291                                                       ;             ; $B289   ; 0x01_B299
BEQ $32           ; F0 32       ; $B283   ; 0x01_B293 ; branch to $B2B7                                     ;             ; $B28B   ; 0x01_B29B ; branch to $B2BF
AND #$10          ; 29 10       ; $B285   ; 0x01_B295                                                       ;             ; $B28D   ; 0x01_B29D
BEQ $14           ; F0 14       ; $B287   ; 0x01_B297 ; branch to $B29D                                     ;             ; $B28F   ; 0x01_B29F ; branch to $B2A5
DEC $5F           ; C6 5F       ; $B289   ; 0x01_B299                                                       ;             ; $B291   ; 0x01_B2A1
LDA $5F           ; A5 5F       ; $B28B   ; 0x01_B29B                                                       ;             ; $B293   ; 0x01_B2A3
AND #$07          ; 29 07       ; $B28D   ; 0x01_B29D                                                       ;             ; $B295   ; 0x01_B2A5
STA $5F           ; 85 5F       ; $B28F   ; 0x01_B29F                                                       ;             ; $B297   ; 0x01_B2A7
BEQ $1C           ; F0 1C       ; $B291   ; 0x01_B2A1 ; branch to $B2AF                                     ;             ; $B299   ; 0x01_B2A9 ; branch to $B2B7
TAY               ; A8          ; $B293   ; 0x01_B2A3                                                       ;             ; $B29B   ; 0x01_B2AB
LDA $5D           ; A5 5D       ; $B294   ; 0x01_B2A4 ; load boss bitfield, pause menu                      ;             ; $B29C   ; 0x01_B2AC
AND $B50D,Y       ; 39 0D B5    ; $B296   ; 0x01_B2A6   ; selection changed? up pressed   AND $B515,Y       ; 39 15 B5    ; $B29E   ; 0x01_B2AE
BEQ $EE           ; F0 EE       ; $B299   ; 0x01_B2A9 ; branch to $B289                                     ;             ; $B2A1   ; 0x01_B2B1 ; branch to $B291
BNE $12           ; D0 12       ; $B29B   ; 0x01_B2AB ; branch to $B2AF                                     ;             ; $B2A3   ; 0x01_B2B3 ; branch to $B2B7
INC $5F           ; E6 5F       ; $B29D   ; 0x01_B2AD                                                       ;             ; $B2A5   ; 0x01_B2B5
LDA $5F           ; A5 5F       ; $B29F   ; 0x01_B2AF                                                       ;             ; $B2A7   ; 0x01_B2B7
AND #$07          ; 29 07       ; $B2A1   ; 0x01_B2B1                                                       ;             ; $B2A9   ; 0x01_B2B9
STA $5F           ; 85 5F       ; $B2A3   ; 0x01_B2B3                                                       ;             ; $B2AB   ; 0x01_B2BB
BEQ $08           ; F0 08       ; $B2A5   ; 0x01_B2B5 ; branch to $B2AF                                     ;             ; $B2AD   ; 0x01_B2BD ; branch to $B2B7
TAY               ; A8          ; $B2A7   ; 0x01_B2B7                                                       ;             ; $B2AF   ; 0x01_B2BF
LDA $5D           ; A5 5D       ; $B2A8   ; 0x01_B2B8 ; load boss bitfield, pause menu                      ;             ; $B2B0   ; 0x01_B2C0
AND $B50D,Y       ; 39 0D B5    ; $B2AA   ; 0x01_B2BA   ; selection changed? down pressed AND $B515,Y       ; 39 15 B5    ; $B2B2   ; 0x01_B2C2
BEQ $EE           ; F0 EE       ; $B2AD   ; 0x01_B2BD ; branch to $B29D                                     ;             ; $B2B5   ; 0x01_B2C5 ; branch to $B2A5
LDA #$1F          ; A9 1F       ; $B2AF   ; 0x01_B2BF                                                       ;             ; $B2B7   ; 0x01_B2C7
JSR $C477         ; 20 77 C4    ; $B2B1   ; 0x01_B2C1                                                       ;             ; $B2B9   ; 0x01_B2C9
JMP $B248         ; 4C 48 B2    ; $B2B4   ; 0x01_B2C4                                     JMP $B250         ; 4C 50 B2    ; $B2BC   ; 0x01_B2CC

; ...................................................                                     ; ...................................................

LDA #$00          ; A9 00       ; $B3E9   ; 0x01_B3F9 ; pause menu                                          ;             ; $B3F1   ; 0x01_B401
STA $06           ; 85 06       ; $B3EB   ; 0x01_B3FB                                                       ;             ; $B3F3   ; 0x01_B403
LDA #$AC          ; A9 AC       ; $B3ED   ; 0x01_B3FD                                                       ;             ; $B3F5   ; 0x01_B405
STA $07           ; 85 07       ; $B3EF   ; 0x01_B3FF                                                       ;             ; $B3F7   ; 0x01_B407
LDA #$02          ; A9 02       ; $B3F1   ; 0x01_B401                                                       ;             ; $B3F9   ; 0x01_B409
LDX #$00          ; A2 00       ; $B3F3   ; 0x01_B403                                                       ;             ; $B3FB   ; 0x01_B40B
LDY $0381         ; AC 81 03    ; $B3F5   ; 0x01_B405                                                       ;             ; $B3FD   ; 0x01_B40D
JSR $C400         ; 20 00 C4    ; $B3F8   ; 0x01_B408                                                       ;             ; $B400   ; 0x01_B410
LDA #$10          ; A9 10       ; $B3FB   ; 0x01_B40B                                                       ;             ; $B403   ; 0x01_B413
STA $5E           ; 85 5E       ; $B3FD   ; 0x01_B40D                                                       ;             ; $B405   ; 0x01_B415
LDA #$01          ; A9 01       ; $B3FF   ; 0x01_B40F                                                       ;             ; $B407   ; 0x01_B417
STA $0C           ; 85 0C       ; $B401   ; 0x01_B411                                                       ;             ; $B409   ; 0x01_B419
LDA $3C           ; A5 3C       ; $B403   ; 0x01_B413                                                       ;             ; $B40B   ; 0x01_B41B
ASL               ; 0A          ; $B405   ; 0x01_B415                                                       ;             ; $B40D   ; 0x01_B41D
STA $0D           ; 85 0D       ; $B406   ; 0x01_B416                                                       ;             ; $B40E   ; 0x01_B41E
LDA $0D           ; A5 0D       ; $B408   ; 0x01_B418                                                       ;             ; $B410   ; 0x01_B420
TAX               ; AA          ; $B40A   ; 0x01_B41A                                                       ;             ; $B412   ; 0x01_B422
LDA $5D           ; A5 5D       ; $B40B   ; 0x01_B41B ; load boss bitfield                                  ;             ; $B413   ; 0x01_B423
ORA #$01          ; 09 01       ; $B40D   ; 0x01_B41D                                                       ;             ; $B415   ; 0x01_B425
AND $B50D,X       ; 3D 0D B5    ; $B40F   ; 0x01_B41F                                     AND $B515,X       ; 3D 15 B5    ; $B417   ; 0x01_B427
BEQ $29           ; F0 29       ; $B412   ; 0x01_B422 ; branch to $B43D                                     ;             ; $B41A   ; 0x01_B42A ; branch to $B445
LDA $0D           ; A5 0D       ; $B414   ; 0x01_B424                                                       ;             ; $B41C   ; 0x01_B42C
ASL               ; 0A          ; $B416   ; 0x01_B426                                                       ;             ; $B41E   ; 0x01_B42E
TAY               ; A8          ; $B417   ; 0x01_B427                                                       ;             ; $B41F   ; 0x01_B42F
LDA $B4FB,X       ; BD FB B4    ; $B418   ; 0x01_B428                                     LDA $B503,X       ; BD 03 B5    ; $B420   ; 0x01_B430
TAX               ; AA          ; $B41B   ; 0x01_B42B                                                       ;             ; $B423   ; 0x01_B433
LDA $B4E7,Y       ; B9 E7 B4    ; $B41C   ; 0x01_B42C                                     LDA $B4EF,Y       ; B9 EF B4    ; $B424   ; 0x01_B434
STA $0204,X       ; 9D 04 02    ; $B41F   ; 0x01_B42F                                                       ;             ; $B427   ; 0x01_B437
LDA $B4E8,Y       ; B9 E8 B4    ; $B422   ; 0x01_B432                                     LDA $B4F0,Y       ; B9 F0 B4    ; $B42A   ; 0x01_B43A
STA $0205,X       ; 9D 05 02    ; $B425   ; 0x01_B435                                                       ;             ; $B42D   ; 0x01_B43D
LDA #$20          ; A9 20       ; $B428   ; 0x01_B438                                                       ;             ; $B430   ; 0x01_B440
STA $0206,X       ; 9D 06 02    ; $B42A   ; 0x01_B43A                                                       ;             ; $B432   ; 0x01_B442
LDA $1A           ; A5 1A       ; $B42D   ; 0x01_B43D                                                       ;             ; $B435   ; 0x01_B445
AND #$1F          ; 29 1F       ; $B42F   ; 0x01_B43F                                                       ;             ; $B437   ; 0x01_B447
STA $0207,X       ; 9D 07 02    ; $B431   ; 0x01_B441                                                       ;             ; $B439   ; 0x01_B449
LDA #$8E          ; A9 8E       ; $B434   ; 0x01_B444                                                       ;             ; $B43C   ; 0x01_B44C
SEC               ; 38          ; $B436   ; 0x01_B446                                                       ;             ; $B43E   ; 0x01_B44E
SBC $0207,X       ; FD 07 02    ; $B437   ; 0x01_B447                                                       ;             ; $B43F   ; 0x01_B44F
STA $0207,X       ; 9D 07 02    ; $B43A   ; 0x01_B44A                                                       ;             ; $B442   ; 0x01_B452
INC $0D           ; E6 0D       ; $B43D   ; 0x01_B44D                                                       ;             ; $B445   ; 0x01_B455
DEC $0C           ; C6 0C       ; $B43F   ; 0x01_B44F                                                       ;             ; $B447   ; 0x01_B457
BPL $C5           ; 10 C5       ; $B441   ; 0x01_B451 ; branch to $B408                                     ;             ; $B449   ; 0x01_B459 ; branch to $B410
LDX #$12          ; A2 12       ; $B443   ; 0x01_B453                                                       ;             ; $B44B   ; 0x01_B45B
RTS               ; 60          ; $B445   ; 0x01_B455                                                       ;             ; $B44D   ; 0x01_B45D

; ...................................................                                     ; ...................................................

LDA #$00          ; A9 00       ; $B594   ; 0x01_B5A4 ; stage select                                        ;             ; $B59C   ; 0x01_B5AC
STA $0C           ; 85 0C       ; $B596   ; 0x01_B5A6                                                       ;             ; $B59E   ; 0x01_B5AE
STA $0D           ; 85 0D       ; $B598   ; 0x01_B5A8                                                       ;             ; $B5A0   ; 0x01_B5B0
ASL               ; 0A          ; $B59A   ; 0x01_B5AA                                                       ;             ; $B5A2   ; 0x01_B5B2
TAX               ; AA          ; $B59B   ; 0x01_B5AB                                                       ;             ; $B5A3   ; 0x01_B5B3
LDA $BE7F,X       ; BD 7F BE    ; $B59C   ; 0x01_B5AC                                     LDA $BE87,X       ; BD 87 BE    ; $B5A4   ; 0x01_B5B4
STA $04           ; 85 04       ; $B59F   ; 0x01_B5AF                                                       ;             ; $B5A7   ; 0x01_B5B7
LDA $BE80,X       ; BD 80 BE    ; $B5A1   ; 0x01_B5B1                                     LDA $BE88,X       ; BD 88 BE    ; $B5A9   ; 0x01_B5B9
STA $05           ; 85 05       ; $B5A4   ; 0x01_B5B4                                                       ;             ; $B5AC   ; 0x01_B5BC
LDX $0C           ; A6 0C       ; $B5A6   ; 0x01_B5B6                                                       ;             ; $B5AE   ; 0x01_B5BE
CPX #$06          ; E0 06       ; $B5A8   ; 0x01_B5B8                                                       ;             ; $B5B0   ; 0x01_B5C0
BNE $04           ; D0 04       ; $B5AA   ; 0x01_B5BA ; branch to $B5B0                                     ;             ; $B5B2   ; 0x01_B5C2 ; branch to $B5B8
LDA #$00          ; A9 00       ; $B5AC   ; 0x01_B5BC                                                       ;             ; $B5B4   ; 0x01_B5C4
BEQ $05           ; F0 05       ; $B5AE   ; 0x01_B5BE ; branch to $B5B5                                     ;             ; $B5B6   ; 0x01_B5C6 ; branch to $B5BD
LDA $5D           ; A5 5D       ; $B5B0   ; 0x01_B5C0 ; load boss bitfield                                  ;             ; $B5B8   ; 0x01_B5C8
AND $BFC4,X       ; 3D C4 BF    ; $B5B2   ; 0x01_B5C2                                     AND $BFCC,X       ; 3D CC BF    ; $B5BA   ; 0x01_B5CA
STA $0E           ; 85 0E       ; $B5B5   ; 0x01_B5C5                                                       ;             ; $B5BD   ; 0x01_B5CD
LDY #$00          ; A0 00       ; $B5B7   ; 0x01_B5C7                                                       ;             ; $B5BF   ; 0x01_B5CF
LDA $05           ; A5 05       ; $B5B9   ; 0x01_B5C9                                                       ;             ; $B5C1   ; 0x01_B5D1
STA $2006         ; 8D 06 20    ; $B5BB   ; 0x01_B5CB                                                       ;             ; $B5C3   ; 0x01_B5D3
LDA $04           ; A5 04       ; $B5BE   ; 0x01_B5CE                                                       ;             ; $B5C6   ; 0x01_B5D6
STA $2006         ; 8D 06 20    ; $B5C0   ; 0x01_B5D0                                                       ;             ; $B5C8   ; 0x01_B5D8
LDX #$06          ; A2 06       ; $B5C3   ; 0x01_B5D3                                                       ;             ; $B5CB   ; 0x01_B5DB
LDA $0C           ; A5 0C       ; $B5C5   ; 0x01_B5D5                                                       ;             ; $B5CD   ; 0x01_B5DD
CMP #$05          ; C9 05       ; $B5C7   ; 0x01_B5D7                                                       ;             ; $B5CF   ; 0x01_B5DF
BCS $05           ; B0 05       ; $B5C9   ; 0x01_B5D9 ; branch to $B5D0                                     ;             ; $B5D1   ; 0x01_B5E1 ; branch to $B5D8
LDA $BE13,Y       ; B9 13 BE    ; $B5CB   ; 0x01_B5DB                                     LDA $BE1B,Y       ; B9 1B BE    ; $B5D3   ; 0x01_B5E3
BNE $0A           ; D0 0A       ; $B5CE   ; 0x01_B5DE ; branch to $B5DA                                     ;             ; $B5D6   ; 0x01_B5E6 ; branch to $B5E2
BNE $05           ; D0 05       ; $B5D0   ; 0x01_B5E0 ; branch to $B5D7                                     ;             ; $B5D8   ; 0x01_B5E8 ; branch to $B5DF
LDA $BE37,Y       ; B9 37 BE    ; $B5D2   ; 0x01_B5E2                                     LDA $BE3F,Y       ; B9 3F BE    ; $B5DA   ; 0x01_B5EA
BNE $03           ; D0 03       ; $B5D5   ; 0x01_B5E5 ; branch to $B5DA                                     ;             ; $B5DD   ; 0x01_B5ED ; branch to $B5E2
LDA $BE5B,Y       ; B9 5B BE    ; $B5D7   ; 0x01_B5E7                                     LDA $BE63,Y       ; B9 63 BE    ; $B5DF   ; 0x01_B5EF
CMP #$21          ; C9 21       ; $B5DA   ; 0x01_B5EA                                                       ;             ; $B5E2   ; 0x01_B5F2
BNE $0A           ; D0 0A       ; $B5DC   ; 0x01_B5EC ; branch to $B5E8                                     ;             ; $B5E4   ; 0x01_B5F4 ; branch to $B5F0
LDA $0E           ; A5 0E       ; $B5DE   ; 0x01_B5EE                                                       ;             ; $B5E6   ; 0x01_B5F6
BEQ $04           ; F0 04       ; $B5E0   ; 0x01_B5F0 ; branch to $B5E6                                     ;             ; $B5E8   ; 0x01_B5F8 ; branch to $B5EE
LDA #$00          ; A9 00       ; $B5E2   ; 0x01_B5F2                                                       ;             ; $B5EA   ; 0x01_B5FA
BEQ $02           ; F0 02       ; $B5E4   ; 0x01_B5F4 ; branch to $B5E8                                     ;             ; $B5EC   ; 0x01_B5FC ; branch to $B5F0
LDA #$21          ; A9 21       ; $B5E6   ; 0x01_B5F6                                                       ;             ; $B5EE   ; 0x01_B5FE
STA $2007         ; 8D 07 20    ; $B5E8   ; 0x01_B5F8                                                       ;             ; $B5F0   ; 0x01_B600
INY               ; C8          ; $B5EB   ; 0x01_B5FB                                                       ;             ; $B5F3   ; 0x01_B603
DEX               ; CA          ; $B5EC   ; 0x01_B5FC                                                       ;             ; $B5F4   ; 0x01_B604
BNE $D6           ; D0 D6       ; $B5ED   ; 0x01_B5FD ; branch to $B5C5                                     ;             ; $B5F5   ; 0x01_B605 ; branch to $B5CD
CLC               ; 18          ; $B5EF   ; 0x01_B5FF                                                       ;             ; $B5F7   ; 0x01_B607
LDA $04           ; A5 04       ; $B5F0   ; 0x01_B600                                                       ;             ; $B5F8   ; 0x01_B608
ADC #$20          ; 69 20       ; $B5F2   ; 0x01_B602                                                       ;             ; $B5FA   ; 0x01_B60A
STA $04           ; 85 04       ; $B5F4   ; 0x01_B604                                                       ;             ; $B5FC   ; 0x01_B60C
LDA $05           ; A5 05       ; $B5F6   ; 0x01_B606                                                       ;             ; $B5FE   ; 0x01_B60E
ADC #$00          ; 69 00       ; $B5F8   ; 0x01_B608                                                       ;             ; $B600   ; 0x01_B610
STA $05           ; 85 05       ; $B5FA   ; 0x01_B60A                                                       ;             ; $B602   ; 0x01_B612
CPY #$24          ; C0 24       ; $B5FC   ; 0x01_B60C                                                       ;             ; $B604   ; 0x01_B614
BNE $B9           ; D0 B9       ; $B5FE   ; 0x01_B60E ; branch to $B5B9                                     ;             ; $B606   ; 0x01_B616 ; branch to $B5C1
STA $2006         ; 8D 06 20    ; $B600   ; 0x01_B610                                                       ;             ; $B608   ; 0x01_B618
LDA $04           ; A5 04       ; $B603   ; 0x01_B613                                                       ;             ; $B60B   ; 0x01_B61B
STA $2006         ; 8D 06 20    ; $B605   ; 0x01_B615                                                       ;             ; $B60D   ; 0x01_B61D
LDX $0D           ; A6 0D       ; $B608   ; 0x01_B618                                                       ;             ; $B610   ; 0x01_B620
LDY #$07          ; A0 07       ; $B60A   ; 0x01_B61A                                                       ;             ; $B612   ; 0x01_B622
LDA $BF67,X       ; BD 67 BF    ; $B60C   ; 0x01_B61C                                     LDA $BF6F,X       ; BD 6F BF    ; $B614   ; 0x01_B624
STA $2007         ; 8D 07 20    ; $B60F   ; 0x01_B61F                                                       ;             ; $B617   ; 0x01_B627
INX               ; E8          ; $B612   ; 0x01_B622                                                       ;             ; $B61A   ; 0x01_B62A
DEY               ; 88          ; $B613   ; 0x01_B623                                                       ;             ; $B61B   ; 0x01_B62B
BNE $F6           ; D0 F6       ; $B614   ; 0x01_B624 ; branch to $B60C                                     ;             ; $B61C   ; 0x01_B62C ; branch to $B614
STX $0D           ; 86 0D       ; $B616   ; 0x01_B626                                                       ;             ; $B61E   ; 0x01_B62E
LDX $0C           ; A6 0C       ; $B618   ; 0x01_B628                                                       ;             ; $B620   ; 0x01_B630
LDA $BE8D,X       ; BD 8D BE    ; $B61A   ; 0x01_B62A                                     LDA $BE95,X       ; BD 95 BE    ; $B622   ; 0x01_B632
CLC               ; 18          ; $B61D   ; 0x01_B62D                                                       ;             ; $B625   ; 0x01_B635
ADC #$08          ; 69 08       ; $B61E   ; 0x01_B62E                                                       ;             ; $B626   ; 0x01_B636
LDX #$23          ; A2 23       ; $B620   ; 0x01_B630                                                       ;             ; $B628   ; 0x01_B638
STX $2006         ; 8E 06 20    ; $B622   ; 0x01_B632                                                       ;             ; $B62A   ; 0x01_B63A
STA $2006         ; 8D 06 20    ; $B625   ; 0x01_B635                                                       ;             ; $B62D   ; 0x01_B63D
LDA #$88          ; A9 88       ; $B628   ; 0x01_B638                                                       ;             ; $B630   ; 0x01_B640
STA $2007         ; 8D 07 20    ; $B62A   ; 0x01_B63A                                                       ;             ; $B632   ; 0x01_B642
LDA #$22          ; A9 22       ; $B62D   ; 0x01_B63D                                                       ;             ; $B635   ; 0x01_B645
STA $2007         ; 8D 07 20    ; $B62F   ; 0x01_B63F                                                       ;             ; $B637   ; 0x01_B647
INC $0C           ; E6 0C       ; $B632   ; 0x01_B642                                                       ;             ; $B63A   ; 0x01_B64A
LDA $5D           ; A5 5D       ; $B634   ; 0x01_B644 ; load boss bitfield                                  ;             ; $B63C   ; 0x01_B64C
AND #$7E          ; 29 7E       ; $B636   ; 0x01_B646                                                       ;             ; $B63E   ; 0x01_B64E
CMP #$7E          ; C9 7E       ; $B638   ; 0x01_B648                                                       ;             ; $B640   ; 0x01_B650
BNE $08           ; D0 08       ; $B63A   ; 0x01_B64A ; branch to $B644                                     ;             ; $B642   ; 0x01_B652 ; branch to $B64C
LDA $0C           ; A5 0C       ; $B63C   ; 0x01_B64C                                                       ;             ; $B644   ; 0x01_B654
CMP #$07          ; C9 07       ; $B63E   ; 0x01_B64E                                                       ;             ; $B646   ; 0x01_B656
BEQ $0B           ; F0 0B       ; $B640   ; 0x01_B650 ; branch to $B64D                                     ;             ; $B648   ; 0x01_B658 ; branch to $B655
BNE $06           ; D0 06       ; $B642   ; 0x01_B652 ; branch to $B64A                                     ;             ; $B64A   ; 0x01_B65A ; branch to $B652
LDA $0C           ; A5 0C       ; $B644   ; 0x01_B654                                                       ;             ; $B64C   ; 0x01_B65C
CMP #$06          ; C9 06       ; $B646   ; 0x01_B656                                                       ;             ; $B64E   ; 0x01_B65E
BEQ $03           ; F0 03       ; $B648   ; 0x01_B658 ; branch to $B64D                                     ;             ; $B650   ; 0x01_B660 ; branch to $B655
JMP $B59A         ; 4C 9A B5    ; $B64A   ; 0x01_B65A                                     JMP $B5A2         ; 4C A2 B5    ; $B652   ; 0x01_B662
STX $2006         ; 8E 06 20    ; $B64D   ; 0x01_B65D                                                       ;             ; $B655   ; 0x01_B665
LDA #$CC          ; A9 CC       ; $B650   ; 0x01_B660                                                       ;             ; $B658   ; 0x01_B668
STA $2006         ; 8D 06 20    ; $B652   ; 0x01_B662                                                       ;             ; $B65A   ; 0x01_B66A
STA $2007         ; 8D 07 20    ; $B655   ; 0x01_B665                                                       ;             ; $B65D   ; 0x01_B66D
LDA #$33          ; A9 33       ; $B658   ; 0x01_B668                                                       ;             ; $B660   ; 0x01_B670
STA $2007         ; 8D 07 20    ; $B65A   ; 0x01_B66A                                                       ;             ; $B662   ; 0x01_B672
LDA $5D           ; A5 5D       ; $B65D   ; 0x01_B66D ; load boss bitfield                                  ;             ; $B665   ; 0x01_B675
AND #$7E          ; 29 7E       ; $B65F   ; 0x01_B66F                                                       ;             ; $B667   ; 0x01_B677
CMP #$7E          ; C9 7E       ; $B661   ; 0x01_B671                                                       ;             ; $B669   ; 0x01_B679
BEQ $21           ; F0 21       ; $B663   ; 0x01_B673 ; branch to $B686                                     ;             ; $B66B   ; 0x01_B67B ; branch to $B68E
LDY #$04          ; A0 04       ; $B665   ; 0x01_B675                                                       ;             ; $B66D   ; 0x01_B67D
LDX #$00          ; A2 00       ; $B667   ; 0x01_B677                                                       ;             ; $B66F   ; 0x01_B67F
LDA $BFA4,X       ; BD A4 BF    ; $B669   ; 0x01_B679                                     LDA $BFAC,X       ; BD AC BF    ; $B671   ; 0x01_B681
STA $2006         ; 8D 06 20    ; $B66C   ; 0x01_B67C                                                       ;             ; $B674   ; 0x01_B684
INX               ; E8          ; $B66F   ; 0x01_B67F                                                       ;             ; $B677   ; 0x01_B687
LDA $BFA4,X       ; BD A4 BF    ; $B670   ; 0x01_B680                                     LDA $BFAC,X       ; BD AC BF    ; $B678   ; 0x01_B688
STA $2006         ; 8D 06 20    ; $B673   ; 0x01_B683                                                       ;             ; $B67B   ; 0x01_B68B
INX               ; E8          ; $B676   ; 0x01_B686                                                       ;             ; $B67E   ; 0x01_B68E
LDA $BFA4,X       ; BD A4 BF    ; $B677   ; 0x01_B687                                     LDA $BFAC,X       ; BD AC BF    ; $B67F   ; 0x01_B68F
STA $2007         ; 8D 07 20    ; $B67A   ; 0x01_B68A                                                       ;             ; $B682   ; 0x01_B692
INX               ; E8          ; $B67D   ; 0x01_B68D                                                       ;             ; $B685   ; 0x01_B695
TXA               ; 8A          ; $B67E   ; 0x01_B68E                                                       ;             ; $B686   ; 0x01_B696
AND #$07          ; 29 07       ; $B67F   ; 0x01_B68F                                                       ;             ; $B687   ; 0x01_B697
BNE $F4           ; D0 F4       ; $B681   ; 0x01_B691 ; branch to $B677                                     ;             ; $B689   ; 0x01_B699 ; branch to $B67F
DEY               ; 88          ; $B683   ; 0x01_B693                                                       ;             ; $B68B   ; 0x01_B69B
BNE $E3           ; D0 E3       ; $B684   ; 0x01_B694 ; branch to $B669                                     ;             ; $B68C   ; 0x01_B69C ; branch to $B671
LDA #$A3          ; A9 A3       ; $B686   ; 0x01_B696                                     LDA #$AB          ; A9 AB       ; $B68E   ; 0x01_B69E
STA $35           ; 85 35       ; $B688   ; 0x01_B698                                                       ;             ; $B690   ; 0x01_B6A0
LDA #$BD          ; A9 BD       ; $B68A   ; 0x01_B69A                                                       ;             ; $B692   ; 0x01_B6A2
STA $36           ; 85 36       ; $B68C   ; 0x01_B69C                                                       ;             ; $B694   ; 0x01_B6A4
LDA #$20          ; A9 20       ; $B68E   ; 0x01_B69E                                                       ;             ; $B696   ; 0x01_B6A6
JSR $D647         ; 20 47 D6    ; $B690   ; 0x01_B6A0                                                       ;             ; $B698   ; 0x01_B6A8
LDA $5D           ; A5 5D       ; $B693   ; 0x01_B6A3 ; load boss bitfield                                  ;             ; $B69B   ; 0x01_B6AB
AND #$08          ; 29 08       ; $B695   ; 0x01_B6A5                                                       ;             ; $B69D   ; 0x01_B6AD
BEQ $0D           ; F0 0D       ; $B697   ; 0x01_B6A7 ; branch to $B6A6                                     ;             ; $B69F   ; 0x01_B6AF ; branch to $B6AE
LDA #$D3          ; A9 D3       ; $B699   ; 0x01_B6A9                                     LDA #$DB          ; A9 DB       ; $B6A1   ; 0x01_B6B1
STA $35           ; 85 35       ; $B69B   ; 0x01_B6AB                                                       ;             ; $B6A3   ; 0x01_B6B3
LDA #$BD          ; A9 BD       ; $B69D   ; 0x01_B6AD                                                       ;             ; $B6A5   ; 0x01_B6B5
STA $36           ; 85 36       ; $B69F   ; 0x01_B6AF                                                       ;             ; $B6A7   ; 0x01_B6B7
LDA #$10          ; A9 10       ; $B6A1   ; 0x01_B6B1                                                       ;             ; $B6A9   ; 0x01_B6B9
JSR $D647         ; 20 47 D6    ; $B6A3   ; 0x01_B6B3                                                       ;             ; $B6AB   ; 0x01_B6BB
LDY #$00          ; A0 00       ; $B6A6   ; 0x01_B6B6                                                       ;             ; $B6AE   ; 0x01_B6BE
LDX #$40          ; A2 40       ; $B6A8   ; 0x01_B6B8                                                       ;             ; $B6B0   ; 0x01_B6C0
JSR $D478         ; 20 78 D4    ; $B6AA   ; 0x01_B6BA                                                       ;             ; $B6B2   ; 0x01_B6C2
LDX #$04          ; A2 04       ; $B6AD   ; 0x01_B6BD                                                       ;             ; $B6B5   ; 0x01_B6C5
LDA #$00          ; A9 00       ; $B6AF   ; 0x01_B6BF                                                       ;             ; $B6B7   ; 0x01_B6C7
STA $31           ; 85 31       ; $B6B1   ; 0x01_B6C1                                                       ;             ; $B6B9   ; 0x01_B6C9
ASL               ; 0A          ; $B6B3   ; 0x01_B6C3                                                       ;             ; $B6BB   ; 0x01_B6CB
ASL               ; 0A          ; $B6B4   ; 0x01_B6C4                                                       ;             ; $B6BC   ; 0x01_B6CC
TAY               ; A8          ; $B6B5   ; 0x01_B6C5                                                       ;             ; $B6BD   ; 0x01_B6CD
STX $0C           ; 86 0C       ; $B6B6   ; 0x01_B6C6                                                       ;             ; $B6BE   ; 0x01_B6CE
LDX #$00          ; A2 00       ; $B6B8   ; 0x01_B6C8                                                       ;             ; $B6C0   ; 0x01_B6D0
LDA $BEC2,Y       ; B9 C2 BE    ; $B6BA   ; 0x01_B6CA                                     LDA $BECA,Y       ; B9 CA BE    ; $B6C2   ; 0x01_B6D2
STA $0D,X         ; 95 0D       ; $B6BD   ; 0x01_B6CD                                                       ;             ; $B6C5   ; 0x01_B6D5
INX               ; E8          ; $B6BF   ; 0x01_B6CF                                                       ;             ; $B6C7   ; 0x01_B6D7
INY               ; C8          ; $B6C0   ; 0x01_B6D0                                                       ;             ; $B6C8   ; 0x01_B6D8
CPX #$04          ; E0 04       ; $B6C1   ; 0x01_B6D1                                                       ;             ; $B6C9   ; 0x01_B6D9
BNE $F5           ; D0 F5       ; $B6C3   ; 0x01_B6D3 ; branch to $B6BA                                     ;             ; $B6CB   ; 0x01_B6DB ; branch to $B6C2
LDX $0C           ; A6 0C       ; $B6C5   ; 0x01_B6D5                                                       ;             ; $B6CD   ; 0x01_B6DD
JSR $BC52         ; 20 52 BC    ; $B6C7   ; 0x01_B6D7                                     JSR $BC5A         ; 20 5A BC    ; $B6CF   ; 0x01_B6DF
INC $31           ; E6 31       ; $B6CA   ; 0x01_B6DA                                                       ;             ; $B6D2   ; 0x01_B6E2
LDA $31           ; A5 31       ; $B6CC   ; 0x01_B6DC                                                       ;             ; $B6D4   ; 0x01_B6E4
CMP #$06          ; C9 06       ; $B6CE   ; 0x01_B6DE                                                       ;             ; $B6D6   ; 0x01_B6E6
BNE $E1           ; D0 E1       ; $B6D0   ; 0x01_B6E0 ; branch to $B6B3                                     ;             ; $B6D8   ; 0x01_B6E8 ; branch to $B6BB
LDA #$01          ; A9 01       ; $B6D2   ; 0x01_B6E2                                                       ;             ; $B6DA   ; 0x01_B6EA
JSR $C477         ; 20 77 C4    ; $B6D4   ; 0x01_B6E4                                                       ;             ; $B6DC   ; 0x01_B6EC
LDA #$00          ; A9 00       ; $B6D7   ; 0x01_B6E7                                                       ;             ; $B6DF   ; 0x01_B6EF
STA $1B           ; 85 1B       ; $B6D9   ; 0x01_B6E9                                                       ;             ; $B6E1   ; 0x01_B6F1
STA $1A           ; 85 1A       ; $B6DB   ; 0x01_B6EB                                                       ;             ; $B6E3   ; 0x01_B6F3
LDA $FF           ; A5 FF       ; $B6DD   ; 0x01_B6ED                                                       ;             ; $B6E5   ; 0x01_B6F5
ORA #$80          ; 09 80       ; $B6DF   ; 0x01_B6EF                                                       ;             ; $B6E7   ; 0x01_B6F7
STA $FF           ; 85 FF       ; $B6E1   ; 0x01_B6F1                                                       ;             ; $B6E9   ; 0x01_B6F9
STA $2000         ; 8D 00 20    ; $B6E3   ; 0x01_B6F3                                                       ;             ; $B6EB   ; 0x01_B6FB
LDA #$00          ; A9 00       ; $B6E6   ; 0x01_B6F6                                                       ;             ; $B6EE   ; 0x01_B6FE
STA $31           ; 85 31       ; $B6E8   ; 0x01_B6F8                                                       ;             ; $B6F0   ; 0x01_B700
STA $23           ; 85 23       ; $B6EA   ; 0x01_B6FA                                                       ;             ; $B6F2   ; 0x01_B702
TAY               ; A8          ; $B6EC   ; 0x01_B6FC                                                       ;             ; $B6F4   ; 0x01_B704
TYA               ; 98          ; $B6ED   ; 0x01_B6FD                                                       ;             ; $B6F5   ; 0x01_B705
ASL               ; 0A          ; $B6EE   ; 0x01_B6FE                                                       ;             ; $B6F6   ; 0x01_B706
ASL               ; 0A          ; $B6EF   ; 0x01_B6FF                                                       ;             ; $B6F7   ; 0x01_B707
TAX               ; AA          ; $B6F0   ; 0x01_B700                                                       ;             ; $B6F8   ; 0x01_B708
LDA #$23          ; A9 23       ; $B6F1   ; 0x01_B701                                                       ;             ; $B6F9   ; 0x01_B709
STA $0312,X       ; 9D 12 03    ; $B6F3   ; 0x01_B703                                                       ;             ; $B6FB   ; 0x01_B70B
LDA $BE94,Y       ; B9 94 BE    ; $B6F6   ; 0x01_B706                                     LDA $BE9C,Y       ; B9 9C BE    ; $B6FE   ; 0x01_B70E
STA $0314,X       ; 9D 14 03    ; $B6F9   ; 0x01_B709                                                       ;             ; $B701   ; 0x01_B711
INY               ; C8          ; $B6FC   ; 0x01_B70C                                                       ;             ; $B704   ; 0x01_B714
CPY #$0A          ; C0 0A       ; $B6FD   ; 0x01_B70D                                                       ;             ; $B705   ; 0x01_B715
BNE $EC           ; D0 EC       ; $B6FF   ; 0x01_B70F ; branch to $B6ED                                     ;             ; $B707   ; 0x01_B717 ; branch to $B6F5
LDX #$00          ; A2 00       ; $B701   ; 0x01_B711                                                       ;             ; $B709   ; 0x01_B719
LDY #$00          ; A0 00       ; $B703   ; 0x01_B713                                                       ;             ; $B70B   ; 0x01_B71B
LDA $BE9E,Y       ; B9 9E BE    ; $B705   ; 0x01_B715                                     LDA $BEA6,Y       ; B9 A6 BE    ; $B70D   ; 0x01_B71D
STA $032B,X       ; 9D 2B 03    ; $B708   ; 0x01_B718                                                       ;             ; $B710   ; 0x01_B720
INX               ; E8          ; $B70B   ; 0x01_B71B                                                       ;             ; $B713   ; 0x01_B723
INX               ; E8          ; $B70C   ; 0x01_B71C                                                       ;             ; $B714   ; 0x01_B724
INX               ; E8          ; $B70D   ; 0x01_B71D                                                       ;             ; $B715   ; 0x01_B725
INX               ; E8          ; $B70E   ; 0x01_B71E                                                       ;             ; $B716   ; 0x01_B726
INY               ; C8          ; $B70F   ; 0x01_B71F                                                       ;             ; $B717   ; 0x01_B727
CPY #$04          ; C0 04       ; $B710   ; 0x01_B720                                                       ;             ; $B718   ; 0x01_B728
BNE $F1           ; D0 F1       ; $B712   ; 0x01_B722 ; branch to $B705                                     ;             ; $B71A   ; 0x01_B72A ; branch to $B70D
LDA #$55          ; A9 55       ; $B714   ; 0x01_B724                                                       ;             ; $B71C   ; 0x01_B72C
JSR $BAFA         ; 20 FA BA    ; $B716   ; 0x01_B726                                     JSR $BB02         ; 20 02 BB    ; $B71E   ; 0x01_B72E
JSR $C01B         ; 20 1B C0    ; $B719   ; 0x01_B729                                                       ;             ; $B721   ; 0x01_B731
LDA $18           ; A5 18       ; $B71C   ; 0x01_B72C                                                       ;             ; $B724   ; 0x01_B734
AND #$C8          ; 29 C8       ; $B71E   ; 0x01_B72E                                                       ;             ; $B726   ; 0x01_B736
BEQ $34           ; F0 34       ; $B720   ; 0x01_B730 ; branch to $B756                                     ;             ; $B728   ; 0x01_B738 ; branch to $B75E
AND #$C0          ; 29 C0       ; $B722   ; 0x01_B732                                                       ;             ; $B72A   ; 0x01_B73A
BEQ $47           ; F0 47       ; $B724   ; 0x01_B734 ; branch to $B76D                                     ;             ; $B72C   ; 0x01_B73C ; branch to $B775
LDX $31           ; A6 31       ; $B726   ; 0x01_B736                                                       ;             ; $B72E   ; 0x01_B73E
PHA               ; 48          ; $B728   ; 0x01_B738                                                       ;             ; $B730   ; 0x01_B740
LDA #$00          ; A9 00       ; $B729   ; 0x01_B739                                                       ;             ; $B731   ; 0x01_B741
JSR $BAFA         ; 20 FA BA    ; $B72B   ; 0x01_B73B                                     JSR $BB02         ; 20 02 BB    ; $B733   ; 0x01_B743
LDA $31           ; A5 31       ; $B72E   ; 0x01_B73E                                                       ;             ; $B736   ; 0x01_B746
ASL               ; 0A          ; $B730   ; 0x01_B740                                                       ;             ; $B738   ; 0x01_B748
TAY               ; A8          ; $B731   ; 0x01_B741                                                       ;             ; $B739   ; 0x01_B749
PLA               ; 68          ; $B732   ; 0x01_B742                                                       ;             ; $B73A   ; 0x01_B74A
ASL               ; 0A          ; $B733   ; 0x01_B743                                                       ;             ; $B73B   ; 0x01_B74B
BCS $03           ; B0 03       ; $B734   ; 0x01_B744 ; branch to $B739                                     ;             ; $B73C   ; 0x01_B74C ; branch to $B741
INY               ; C8          ; $B736   ; 0x01_B746                                                       ;             ; $B73E   ; 0x01_B74E
BNE $FA           ; D0 FA       ; $B737   ; 0x01_B747 ; branch to $B733                                     ;             ; $B73F   ; 0x01_B74F ; branch to $B73B
LDA $5D           ; A5 5D       ; $B739   ; 0x01_B749 ; load boss bitfield                                  ;             ; $B741   ; 0x01_B751
AND #$7E          ; 29 7E       ; $B73B   ; 0x01_B74B                                                       ;             ; $B743   ; 0x01_B753
CMP #$7E          ; C9 7E       ; $B73D   ; 0x01_B74D                                                       ;             ; $B745   ; 0x01_B755
BNE $05           ; D0 05       ; $B73F   ; 0x01_B74F ; branch to $B746                                     ;             ; $B747   ; 0x01_B757 ; branch to $B74E
CLC               ; 18          ; $B741   ; 0x01_B751                                                       ;             ; $B749   ; 0x01_B759
TYA               ; 98          ; $B742   ; 0x01_B752                                                       ;             ; $B74A   ; 0x01_B75A
ADC #$0C          ; 69 0C       ; $B743   ; 0x01_B753                                                       ;             ; $B74B   ; 0x01_B75B
TAY               ; A8          ; $B745   ; 0x01_B755                                                       ;             ; $B74D   ; 0x01_B75D
LDA $BEA8,Y       ; B9 A8 BE    ; $B746   ; 0x01_B756                                     LDA $BEB0,Y       ; B9 B0 BE    ; $B74E   ; 0x01_B75E
STA $31           ; 85 31       ; $B749   ; 0x01_B759                                                       ;             ; $B751   ; 0x01_B761
LDA #$FF          ; A9 FF       ; $B74B   ; 0x01_B75B                                                       ;             ; $B753   ; 0x01_B763
STA $23           ; 85 23       ; $B74D   ; 0x01_B75D                                                       ;             ; $B755   ; 0x01_B765
LDA #$1F          ; A9 1F       ; $B74F   ; 0x01_B75F                                                       ;             ; $B757   ; 0x01_B767
JSR $C477         ; 20 77 C4    ; $B751   ; 0x01_B761                                                       ;             ; $B759   ; 0x01_B769
BNE $C3           ; D0 C3       ; $B754   ; 0x01_B764 ; branch to $B719                                     ;             ; $B75C   ; 0x01_B76C ; branch to $B721
LDY #$00          ; A0 00       ; $B756   ; 0x01_B766                                                       ;             ; $B75E   ; 0x01_B76E
LDA $23           ; A5 23       ; $B758   ; 0x01_B768                                                       ;             ; $B760   ; 0x01_B770
AND #$0F          ; 29 0F       ; $B75A   ; 0x01_B76A                                                       ;             ; $B762   ; 0x01_B772
BNE $0C           ; D0 0C       ; $B75C   ; 0x01_B76C ; branch to $B76A                                     ;             ; $B764   ; 0x01_B774 ; branch to $B772
LDA $23           ; A5 23       ; $B75E   ; 0x01_B76E                                                       ;             ; $B766   ; 0x01_B776
AND #$10          ; 29 10       ; $B760   ; 0x01_B770                                                       ;             ; $B768   ; 0x01_B778
BNE $02           ; D0 02       ; $B762   ; 0x01_B772 ; branch to $B766                                     ;             ; $B76A   ; 0x01_B77A ; branch to $B76E
LDY #$55          ; A0 55       ; $B764   ; 0x01_B774                                                       ;             ; $B76C   ; 0x01_B77C
TYA               ; 98          ; $B766   ; 0x01_B776                                                       ;             ; $B76E   ; 0x01_B77E
JSR $BAFA         ; 20 FA BA    ; $B767   ; 0x01_B777                                     JSR $BB02         ; 20 02 BB    ; $B76F   ; 0x01_B77F
JMP $B719         ; 4C 19 B7    ; $B76A   ; 0x01_B77A                                     JMP $B721         ; 4C 21 B7    ; $B772   ; 0x01_B782

; ...................................................                                     ; ...................................................

LDA $5D           ; A5 5D       ; $BB31   ; 0x01_BB41 ; load boss bitfield, stage select                    ;             ; $BB39   ; 0x01_BB49
AND #$7E          ; 29 7E       ; $BB33   ; 0x01_BB43                                                       ;             ; $BB3B   ; 0x01_BB4B
CMP #$7E          ; C9 7E       ; $BB35   ; 0x01_BB45                                                       ;             ; $BB3D   ; 0x01_BB4D
BNE $04           ; D0 04       ; $BB37   ; 0x01_BB47 ; branch to $BB3D                                     ;             ; $BB3F   ; 0x01_BB4F ; branch to $BB45
LDA #$86          ; A9 86       ; $BB39   ; 0x01_BB49                                                       ;             ; $BB41   ; 0x01_BB51
BNE $02           ; D0 02       ; $BB3B   ; 0x01_BB4B ; branch to $BB3F                                     ;             ; $BB43   ; 0x01_BB53 ; branch to $BB47
LDA #$8A          ; A9 8A       ; $BB3D   ; 0x01_BB4D                                                       ;             ; $BB45   ; 0x01_BB55
STA $1C           ; 85 1C       ; $BB3F   ; 0x01_BB4F                                                       ;             ; $BB47   ; 0x01_BB57
RTS               ; 60          ; $BB41   ; 0x01_BB51                                                       ;             ; $BB49   ; 0x01_BB59

; ...................................................                                     ; ...................................................

LDX $31           ; A6 31       ; $C11B   ; 0x01_C12B ; load stage index?                                   ;             ;         ;
CPX #$09          ; E0 09       ; $C11D   ; 0x01_C12D                                                       ;             ;         ;
BEQ $16           ; F0 16       ; $C11F   ; 0x01_C12F ; branch to $C137                                     ;             ;         ;
CPX #$06          ; E0 06       ; $C121   ; 0x01_C131                                                       ;             ;         ;
BCS $16           ; B0 16       ; $C123   ; 0x01_C133 ; branch to $C13B                                     ;             ;         ;
LDA $5D           ; A5 5D       ; $C125   ; 0x01_C135 ; load boss bitfield                                  ;             ;         ;
ORA $C148,X       ; 1D 48 C1    ; $C127   ; 0x01_C137 ; OR with boss bitflag                                ;             ;         ;
STA $5D           ; 85 5D       ; $C12A   ; 0x01_C13A ; write to boss bitfield                              ;             ;         ;
LDA #$00          ; A9 00       ; $C12C   ; 0x01_C13C                                                       ;             ;         ;
STA $BC           ; 85 BC       ; $C12E   ; 0x01_C13E                                                       ;             ;         ;
STA $55           ; 85 55       ; $C130   ; 0x01_C140                                                       ;             ;         ;
STA $68           ; 85 68       ; $C132   ; 0x01_C142                                                       ;             ;         ;
JMP $905A         ; 4C 5A 90    ; $C134   ; 0x01_C144                                                       ;             ;         ;
INC $31           ; E6 31       ; $C137   ; 0x01_C147                                                       ;             ;         ;
DEC $BB           ; C6 BB       ; $C139   ; 0x01_C149                                                       ;             ;         ;
LDA #$00          ; A9 00       ; $C13B   ; 0x01_C14B                                                       ;             ;         ;
STA $B4           ; 85 B4       ; $C13D   ; 0x01_C14D                                                       ;             ;         ;
STA $AB           ; 85 AB       ; $C13F   ; 0x01_C14F                                                       ;             ;         ;
STA $68           ; 85 68       ; $C141   ; 0x01_C151                                                       ;             ;         ;
INC $31           ; E6 31       ; $C143   ; 0x01_C153                                                       ;             ;         ;
JMP $906A         ; 4C 6A 90    ; $C145   ; 0x01_C155                                                       ;             ;         ;

; ...................................................                                     ; ...................................................

LDA #$80          ; A9 80       ; $C873   ; 0x01_C883 ; load magnet beam bitflag                            ;             ;         ;
ORA $5D           ; 05 5D       ; $C875   ; 0x01_C885 ; OR with boss bitfield                               ;             ;         ;
STA $5D           ; 85 5D       ; $C877   ; 0x01_C887 ; write to boss bitfield                              ;             ;         ;
LDA #$1C          ; A9 1C       ; $C879   ; 0x01_C889                                                       ;             ;         ;
STA $71           ; 85 71       ; $C87B   ; 0x01_C88B                                                       ;             ;         ;
LDA #$1A          ; A9 1A       ; $C87D   ; 0x01_C88D                                                       ;             ;         ;
JSR $C477         ; 20 77 C4    ; $C87F   ; 0x01_C88F                                                       ;             ;         ;
RTS               ; 60          ; $C882   ; 0x01_C892                                                       ;             ;         ;



; New Instructions
; -----------------------------------------------------

LDA $FB           ; A5 FB       ; $B11F   ; 0x01_B12F ; load weapon bitfield                                ;             ; $B127   ; 0x01_B137

; ...................................................                                     ; ...................................................

LDA $FB           ; A5 FB       ; $B193   ; 0x01_B1A3 ; load weapon bitfield                                ;             ; $B19B   ; 0x01_B1AB

; ...................................................                                     ; ...................................................

LDA $FB           ; A5 FB       ; $B294   ; 0x01_B2A4 ; load weapon bitfield                                ;             ; $B29C   ; 0x01_B2AC

; ...................................................                                     ; ...................................................

LDA $FB           ; A5 FB       ; $B2A8   ; 0x01_B2B8 ; load weapon bitfield                                ;             ; $B2B0   ; 0x01_B2C0

; ...................................................                                     ; ...................................................

LDA $FB           ; A5 FB       ; $B40B   ; 0x01_B41B ; load weapon bitfield                                ;             ; $B413   ; 0x01_B423

; ...................................................                                     ; ...................................................

JMP $FF06         ; 4C 06 FF    ; $C125   ; 0x01_C135 ; jump to new instructions                            ;             ;         ;
ORA $5D           ; 05 5D       ; $C128   ; 0x01_C138 ; OR with boss bitfield                               ;             ;         ;

; ...................................................                                     ; ...................................................

JMP $FF13         ; 4C 13 FF    ; $C873   ; 0x01_C883 ; jump to new instructions                            ;             ;         ;
NOP               ; EA          ; $C876   ; 0x01_C886 ; NOP to fill unused byte                             ;             ;         ;

; ...................................................                                     ; ...................................................

LDA $FF00,X       ; BD 00 FF    ; $FF06   ; 0x01_FF16 ; load weapon bitflag                                 ;             ;         ;
ORA $FB           ; 05 FB       ; $FF09   ; 0x01_FF19 ; OR with weapon bitfield                             ;             ;         ;
STA $FB           ; 85 FB       ; $FF0B   ; 0x01_FF1B ; write to weapon bitfield                            ;             ;         ;
LDA $C148,X       ; BD 48 C1    ; $FF0D   ; 0x01_FF1D ; load boss bitflag                                   ;             ;         ;
JMP $C128         ; 4C 28 C1    ; $FF10   ; 0x01_FF20

LDA #$80          ; A9 80       ; $FF13   ; 0x01_FF23 ; load magnet beam bitflag                            ;             ;         ;
ORA $FB           ; 05 FB       ; $FF15   ; 0x01_FF25 ; OR with weapon bitfield                             ;             ;         ;
STA $FB           ; 85 FB       ; $FF17   ; 0x01_FF27 ; write to weapon bitfield                            ;             ;         ;
LDA #$80          ; A9 80       ; $FF19   ; 0x01_FF29 ; load magnet beam bitflag again                      ;             ;         ;
ORA $5D           ; 05 5D       ; $FF1B   ; 0x01_FF2B ; OR with boss bitfield                               ;             ;         ;
JMP $C877         ; 4C 77 C8    ; $FF1D   ; 0x01_FF2D                                                       ;             ;         ;