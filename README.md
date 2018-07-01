# KataOCR-P.P-1070949-
Reducción de complejidad ciclomatica en metodos de la KATA.

Version 1

BankOCR.cs   -----   16

ValidateAccount(string) : string        ---       5

Initialize() : void                                ---       4

ArrayToNumber(string[]): void         ---       3

ConvertToNumbers(string[]): void   ---       3

BANKOCR(string)                             ---       1


BANKOCRTests.cs


AllZeroesShouldReturnZeroes(): void ---   1

BANKOCRTests()                              ---      1

EmptyAccountsShouldReturnAllQuestionMarks(): void  --- 1

MixedAccounts(): void                    ---      1

ShouldReturnAllQuestionMarkWithTag() : void --- 1

ShouldReturnInvalidAccountTag(): void --- 1

ShouldReturnQuestionMark(): void      ---   1

ShouldReturnQuestionMarkWithTag(): void --- 1

ThreeNumbersShouldWorkAsWell(): void ---    1

TwoNumbersShouldWorkAsWell():void    ---    1


Version 2

BankOCR.cs   ----   25

ValidateAccount(string) : string        ---       2

Initialize() : void                                ---       2

ArrayToNumber(string[]): void         ---       1

ConvertToNumbers(string[]): void   ---       2

BANKOCR(string)                             ---       1

multiplyAllNumbers(string):int        ---       3

getAllAccounts(): void                     ---       2

getAccount(int, int): void                 ---       2

fillAllLines(stringp[], int): string         ---       2

addNumbers(string[], string): string ---      2

addQuestionMarkToAccount(string, string): string --- 2

ValidateAccount(string): string         ---      2

calcValidatedAccount(string): string  ---     2

calculateIfIsValid(string): bool             ---    1

multiplyByPosition(string, int, int): int   ---   1
