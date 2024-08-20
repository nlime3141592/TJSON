# TJSON

데이터 타입이 존재하는 변형 JSON을 구현하는 것이 목표

## Syntax

### Value
|empty|empty|
|:---:|:---:|
|ECMA-404 Standard Syntax|TJSON Syntax|

### Array
|empty|empty|
|:---:|:---:|
|ECMA-404 Standard Syntax|TJSON Syntax|

### Number
- 표준 JSON은 10진수 정수, 10진수 실수(소수점, e-표기법)만을 표현할 수 있었으나 2진수, 16진수 값도 입력할 수 있도록 Number 문장 성분의 다이어그램을 변경했다.

|![number-404](https://github.com/nlime3141592/TJSON/blob/main/img/syntax/ECMA-404%20Standard/Number.PNG)|![number-tjson](https://github.com/nlime3141592/TJSON/blob/main/img/syntax/TJSON%20Syntax/Number.png)|
|:---:|:---:|
|ECMA-404 Standard Syntax|TJSON Syntax|

#### Example
|Number|ECMA-404 JSON|TJSON|설명|
|:---:|:---:|:---:|:---:|
|-60|:o:|:o:||
|32.23e2|:o:|:o:||
|+68.67e-10|:x:|:o:|양의 부호 (+) 가능|
|0x7b6|:x:|:o:|16진수 값 가능|
|-0b1010011110|:x:|:o:|2진수 값 가능|
|01012345678|:x:|:o:|최상위 자리에 0이 가능|

### String
|empty|empty|
|:---:|:---:|
|ECMA-404 Standard Syntax|TJSON Syntax|
