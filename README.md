# C-Programing

- inputCell 생성 시 마우스 Cell 마우스 이벤트가 제대로 작동하지 않는
  문제 해결

  1. Cell_Enter / Cell_Leave 내용 수정: child 유무 확인 후 child의
     색상까지 변경하도록 수정.
  2. InputCell_MouseEnter / InputCell_MouseLeave 추가: 마우스 커서가
     inputCell에서 Cell로 이동하거나 inputCell에서 바로 벗어났을 경우에
     색 변경에 대한 내용. Cell_Enter / Cell_Leave와 상호보완적으로
     동작함.

- draw_grid.cs 임의수정: 출력되는 선의 굵기 통일, 색상 변경(DarkGray,
  Balck)

- Form의 sudokuGrid 삭제 후 draw_gird.cs를 사용한 grid 생성 함수 임시로
  작성: 현재 커밋된 신규 내용이 없어 임시로 작성함. 나중에 내용이
  확정되어 커밋될 경우 즉시 수정 예정.

- InputCell_KeyPress에서 Enter Key 입력 시 문자열 체크 조건문 변경:
  문자열이 비어있는 경우만 체크했나, 숫자 이외의 문자가 포함되어
  있는지 판단하는 것으로 변경.
