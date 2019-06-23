# 성경2PPT

> 성경 구절을 PPT로 만들어주는 프로그램

<p align="center"><img src="https://user-images.githubusercontent.com/4927894/59970937-1377a600-95ad-11e9-93b4-66eed61dd932.png" alt="성경2PPT 스크린샷"></p>
<p align="center">⬇️</p>
<p align="center"><img src="https://user-images.githubusercontent.com/4927894/36557220-072f3588-184b-11e8-85b4-05845fbe76c1.png" alt="성경2PPT로 만든 PPT 스크린샷"></p>


## 사용 성경 목록
| 소스 | 언어 | 성경 |
| --- | --- | --- |
| 갓피플 성경 | 한국어 | 개역개정, 쉬운성경 | 
| 갓피아 성경 | 한국어 | 개역개정 4판, 개역한글, 쉬운성경, 공동번역, 현대인의성경, 새번역 |
| GOODTV 성경 | 한국어 | 개역개정, 개역한글, 공동번역, 표준새번역, 우리말성경 |
| 갓피아 성경 | 영어 | NIV |
| GOODTV 성경 | 영어 | NIV, KJV, NASB |
| GOODTV 성경 | 일본어 | (日)구어역, (日)신공동역 |
| GOODTV 성경 | 중국어 | (中)번체, (中)간체 |
| 갓피아 성경 | 기타 | 히브리어(구약), 헬라어(신약) |
| GOODTV 성경 | 기타 | 히브리어, 헬라어 |


## 성경 구절 입력 방법

![성경2PPT 성경 구절 입력 칸 강조 스크린샷](https://user-images.githubusercontent.com/4927894/36576619-1bbd85aa-1895-11e8-9d3c-7b4a58cf807f.png)

**성경 구절 입력 칸**에 **성경 구절**을 아래 형식으로 입력하면 PPT를 만들 수 있습니다.
여러 **성경 구절**을 PPT로 만드려면 띄어쓰기(<kbd>Space</kbd>)로 구분해서 입력하세요.

### 형식

```
책_이름_약자[시작_장[:시작_절][-[끝_장[:끝_절]|끝_절]]]
```

### 예시

| 성경 구절 | 설명 |
| --- | --- |
| `창` | 창세기 전체 |
| `창1` | 창세기 1장 전체 |
| `롬1-3` | 로마서 1장 1절 - 3장 전체 |
| `레1-3:9` | 레위기 1장 1절 - 3장 9절 |
| `전1:3` | 전도서 1장 3절 |
| `스1:3-9` | 에스라 1장 3절 - 1장 9절 |
| `사1:3-3:9` | 이사야 1장 3절 - 3장 9절 |


## 템플릿

![성경2PPT 템플릿 스크린샷](https://user-images.githubusercontent.com/4927894/36580193-9972bece-18aa-11e8-93f2-035283e1a387.png)

**성경2PPT**는 PPT를 만들 때 **템플릿**을 사용합니다.
**템플릿**을 꾸미고 좋아하는 스타일로 PPT를 만드세요!

### 기능

* **치환자**: **템플릿**에 텍스트로 **치환자**를 사용하면
    반복되는 내용을 자동으로 입력할 수 있습니다.

    | 치환자 | 내용 | *접미사* 지원 |
    | --- | --- | :---: |
    | `[TITLE]` | 책 이름 | 예 |
    | `[STITLE]` | 책 이름 약자 | 예 |
    | `[CHAP]` | 장 번호 | 예 |
    | `[PARA]` | 절 번호 | 아니요 |
    | `[BODY]` | 내용 | 아니요 |
    | `[BODY1]` ~ `[BODY9]` | 내용(다중 성경 지원) | 아니요 |

    | 실험용 치환자 | 내용 | *접미사* 지원 |
    | --- | --- | :---: |
    | `[CPAS]` | 시작 절 번호 | 아니요 |
    | `[CPAE]` | 끝 절 번호 | 아니요 |
* **접미사**: **치환자** 뒤에 오는 텍스트를 `:`로 구분하여 입력할 수 있습니다.
    **치환자**를 표시하지 않으면 **접미사**도 표시하지 않습니다.

    | 예시 | 내용 | 책 이름 생략 시 | 장 번호 생략 시 |
    | --- | --- | --- | --- |
    | `[TITLE: ][CHAP::[PARA]]` |  `창세기 1:1` |  `1:1` |  `창세기` |


## 기타 기능

* **오프라인 캐시**: **성경 구절**을 한번 내려받으면 인터넷 연결 없이 PPT를 만들 수 있습니다.
* **장별로 PPT 나누기**: `책 이름/장 번호.pptx`의 구조로 장별로 PPT를 만들어 저장합니다.


## 설치 방법

**성경2PPT**는 [실행 요구 사항](#실행-요구-사항)만 만족하면 설치 없이 사용할 수 있습니다. [Releases](https://github.com/sunghwan2789/Bible2PPT/releases) 페이지에서 최신 버전을 내려받고 바로 사용하세요!


## 실행 요구 사항

### .NET Framework 4 Client Profile 이상
**성경2PPT**를 실행하는 데 필요한 프레임워크입니다. [여기](http://go.microsoft.com/fwlink/?LinkId=181012)에서 내려받아서 설치하시고, [여기](http://go.microsoft.com/fwlink/?linkid=221217)에서 업데이트를 설치하세요.

### Microsoft PowerPoint 2007 이상
PPT를 만들고 보는 데 필요한 프로그램입니다. 프로그램 구성 요소로 *Office 공유 기능* - *Visual Basic for Applications*를 설치해야 합니다.

### 인터넷 연결
**성경 구절**을 처음 받아올 때 인터넷 연결이 필요합니다.


## 기여 방법
**성경2PPT**는 당신의 기여를 기다리고 있습니다~ 사용 중 발생한 오류 혹은 추가하고 싶은 기능을 [Issues](https://github.com/sunghwan2789/Bible2PPT/issues) 페이지에 올려주세요!


## License
This software is licenced under the [MIT](LICENSE) © [Sunghwan Bang](https://github.com/sunghwan2789).
