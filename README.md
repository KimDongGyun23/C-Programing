# C-Programing



## 버전 정보
v1 : correct 색상 바뀌도록 하기 전  
v2 : correct 색상 바뀌도록 구현 완료  
v3 : 안내문구 출력 완료 / 잘못된 입력 값이 배경색이 그대로 남아있는 문제  
v4 : 폼 디자인 변경 / 코드 정리  
v5 : Correct 버튼 누를 시 2초 후 색상 기본값으로 돌아오도록 설정  
v6 : 코드 정리 및 디자인 변경  
v7 : 타임 어택으로 변경  
v8 : 스도쿠 그리드 생성 방법 변경 / 메뉴스트립 모드변경 생성  
v9 : 4*4 출력 완료 / 입력 값 오류 해결 / 모드 변경 시, 셀과 그리드 초기화 구현  
v10 : 버그 수정 / 난이도 조절 추가  
v11 : 사무라이 스도쿠 구현 / 홀짝 스도쿠 진행 중  
v12 : 홀짝 색상 변경 완료  
v13 : 코드 정리 및 버그 수정 / 난이도와 모드에 따른 배열을 생성하여 스도쿠 객체 생성 시에 넘겨줌  
v14 : 출력되는 힌트의 글자색 변경하여 기입하는 숫자와 구분이 가능하도록 함  
v15 : 게임 중 글자 색이 잘못 출력되는 버그 수정 / 직쏘 스도쿠 구현  
v16 : 시간 제한에 맞도록 난이도 수정  


## 다음 버전에서 해결해야할 점
v6 : 타임 어택 구현 / 타이머 값 재조정 필요  
v7 : 잘못 입력한 값을 더블 클릭 후, 아무 입력을 하지않으면 값이 삭제되지않고 그대로 남아있음 / correct 버튼 시 오류  
v8 : 변형 스도쿠 구현 / 4*4 구현 시 칸에 맞춰 출력되지않음 / 뒷 배경 셀 색상 변경 필요  
v9 : 다른 변형 스도쿠 구현  
v10 : 홀짝 스도쿠 구현  
v11 : 홀짝 스도쿠에서 출력되지 않는 값들도 홀짝 구분하여 색상 출력  
v12 : 잘못된 값을 입력한 후, CORRECT 버튼 누를 시 오류 발생 / 빨간색이 초기화되기 전에, 마우스가 셀에 들어갔다가 다른 셀로 이동하면 빨간색이 금방 없어져버림  
v13 : 직쏘 스도쿠 추가  
v15 : 입력 창에서 엔터키 누르면 에러 뜨는 현상  


## 스도쿠 문제 생성
9*9 스도쿠를 예시로 들자.  
규칙을 위반하지 않는 정답 값 하나를 생성한다.  
각 행의 번호를 012345678 이라고 한다면 0,1,2행과 3,4,5행과 6,7,8행을 한 그룹으로 묶는다.  

  
스도쿠 규칙에 의거하여  
1. 0행과 1행과 2행은 서로의 행을 바꾸어도 규칙에 위반되지 않는다.  
2. 0,1,2행과 3,4,5행의 위치를 바꾸어도 규칙에 위반되지 않는다. ( 그룹별로 위치를 바꾸어도 위반되지 않는다. )  

이를 각 행과 각 열에 대하여 적용한다면 수많은 문제가 생성이 가능하다.
