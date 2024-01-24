# INTRODUCTION.

C# 을 활용하여 만든 스도쿠 게임입니다. 

다양한 모드와 난이도를 설정하여 게임을 진행할 수 있습니다.

---

# PRODUCT.

총 4가지 모드와 타임어택 기능 및 난이도 조절 기능이 있습니다.<br/><br/>

### 🐽 기본 스도쿠 
![image](https://github.com/KimDongGyun23/C-Programing/assets/104538667/f990cb78-2084-436e-ad03-d20eb431cefa)

스도쿠라고 하면 대부분이 생각하는 기본 정사각형 모양입니다.
 
총 3개( 4 * 4, 9 * 9, 16 * 16 )의 크기로 조절이 가능합니다.<br/><br/>

### 🐽홀짝 스도쿠
![image](https://github.com/KimDongGyun23/C-Programing/assets/104538667/2d4e6780-40a6-4089-99e2-fed943e13bf4)

홀수의 배경색을 회색으로 칠하여 추가적인 힌트를 제공하는 방식입니다. 

따라서, 기본 스도쿠보다 더 쉽게 해결할 수 있을 것입니다.<br/><br/>

### 🐽 사무라이 스도쿠
![image](https://github.com/KimDongGyun23/C-Programing/assets/104538667/614c8fa2-d79a-4b61-a4df-18f7c4685528)

사진과 같이 9 * 9 스도쿠 다섯 개를 X 모양으로 이어 붙인 모양입니다.
 
숫자가 상당히 많아서 복잡하다고 생각하기 쉽습니다. 

하지만, 이어진 부분들이 많아서 생각보다는 쉽게 해결 가능합니다.<br/><br/>

### 🐽 직쏘 스도쿠
![image](https://github.com/KimDongGyun23/C-Programing/assets/104538667/78a17dc7-82df-445b-a938-35dcac62bbbd)

어느정도 스도쿠를 풀어본 분들은 직쏘 스도쿠를 즐겨 찾으십니다. 

기본 스도쿠 모양에서 벗어나서 다양한 모양으로 존재하기 때문에 색다른 재미를 느낄 수 있습니다.  <br/><br/>

### 🐽 타임어택
타임어택 모드에서는 3, 5, 7, 10분 중 사용자가 원하는 시간을 선택하여 게임을 즐길 수 있습니다. 

사용자는 선택한 시간 내에 게임을 완료해야 합니다.<br/><br/>

게임이 시작되면 스톱워치가 타이머로 변경되며, 선택한 시간이 줄어드는 것을 확인할 수 있습니다. 

이로써 사용자는 남은 시간에 대한 경쟁적인 요소를 느끼면서 게임을 진행할 수 있습니다.

타임어택 모드를 종료하면 스톱워치가 다시 활성화되어 정상적인 시간 측정 기능을 사용할 수 있습니다. 

### 🐽 난이도
Easy, Medium, Hard 모드 중에서 원하는 난이도를 선택할 수 있습니다. 

각각의 난이도에 따라서 보이는 힌트의 개수가 달라지도록 설정하였습니다. 

---

# CONTRIBUTION.

### 🐽 주제
---
윈도우폼의 기초를 학습하는 동안 스도쿠 프로젝트를 동시에 진행하게 되었습니다. 

기초를 활용하면서 다양한 기능을 추가할 수 있는 주제를 고민하던 중 스도쿠가 떠올랐습니다. 

이는 간단하면서도 다양한 기능을 적용할 수 있어 이상적인 주제로 선택되었습니다.<br/><br/>

### 🐽 아이디어
---
스도쿠의 다양한 정답을 생성하는 방법에 대한 고민을 하게 되었습니다.

게임을 시작할 때마다 유효성을 검사하면서 새로운 게임판을 생성하는 것은 비효율적이었고, 다른 대안을 찾아야 했습니다.<br/><br/>

제가 고안한 방법은 하나의 정답지를 만들고, 이를 규칙에 어긋나지 않도록 섞는 것이었습니다.

규칙을 충분히 고려한다면 유효성 검사 및 수정으로 인한 시간과 메모리를 절약할 수 있을 것이라고 판단했습니다. <br/><br/>

기본 9 * 9 스도쿠를 기준으로 3행씩 묶어 섞고, 해당 3행도 섞으면 규칙에 어긋나지 않는다는 사실을 깨달았습니다.

이를 통해 열과 행을 잘 섞는다면 수많은 정답지를 만들어낼 수 있었습니다.

뿐만 아니라, 이 아이디어를 다른 모드에도 적용하여 규칙을 지키면서 성능을 유지하며 다양한 정답지를 얻을 수 있었습니다.<br/><br/>

### 🐽 기능 개발
---
프로젝트에서는 다른 팀원이 작성한 클래스를 기반으로 기능을 구현하는 역할을 맡았습니다. 

각 버튼에 디자인을 적용하고 해당 버튼들의 기능을 구현하는 작업을 진행했습니다.<br/><br/>

특히 사용자의 이벤트를 처리하는 부분에서 예기치 못한 상황에 대비하고 오류를 최소화하기 위해 노력했습니다. 

이를 통해 다양한 상황에서 안정적으로 동작하는 사용자 친화적인 인터페이스를 개발하는 데에 기여했습니다.<br/><br/>

---

# RETROSPECTIVE.

C# 언어를 처음 익히면서 진행한 팀 프로젝트였습니다. 

처음이라 어려움도 있었지만, 프로젝트 팀장을 맡아 참여한 경험으로 더욱 애정을 가지고 노력했습니다. 

부족한 부분은 끊임없이 찾아보고 팀원들과 소통하여 조금씩 발전해 나갔습니다.<br/><br/>


### 🐽 계획성에 있어서 가장 만족스러운 프로젝트였습니다.
---
프로젝트 초기에는 대략적인 일정을 세우고, 매주 목요일마다 회의를 진행하여 진행 상황을 확인했습니다.

회의를 통해 부족한 부분을 즉각 보완하고, 각자의 역할을 정해 일주일 동안 진행할 일들을 계획했습니다. 

이를 통해 팀원들은 계획을 지켜가며 좋은 성과를 이뤄냈습니다.<br/><br/>

계획성이 가장 돋보였던 부분은 시험 기간을 염두하고 프로젝트 일정을 세운 것입니다. 

시험 기간을 고려하여 최소 1-2주 전에 프로젝트를 완성하도록 목표를 세우고, 그 목표를 달성했습니다. 

이로써 시험 기간에는 프로젝트에 대한 걱정 없이 공부에만 집중할 수 있었습니다.<br/><br/>

계획적인 접근과 일정 관리는 다양한 이점을 가져다주는 것을 느꼈습니다. 

또한, 주기적인 회의는 올바른 방향으로 나아가기 위한 중요한 도구라 생각됩니다. 

다양한 상황에 빠르게 대응하고 팀원들 간의 소통을 강화하는데 기여한 경험이었습니다.
