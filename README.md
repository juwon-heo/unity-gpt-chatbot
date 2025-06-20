# 💬 Unity GPT Chat UI

Unity에서 OpenAI GPT API를 호출해 실시간 대화를 구현한 간단한 채팅 UI 구현입니다.
![화면 캡처 2025-06-19 193838](https://github.com/user-attachments/assets/6690dc0b-4738-4199-a879-673490b3fb6f)






## 📦 프로젝트 소개
이 프로젝트는 Unity와 OpenAI GPT API를 활용하여, 사용자가 입력한 텍스트에 대해 GPT가 답변을 반환하는 **기본 채팅 시스템**입니다.
- Unity 6(LTS) 환경에서 개발
- TextMeshPro 기반 UI 사용
- OpenAI GPT API 연동
- 프리팹 기반 메시지 동적 생성
  

## 🧩 주요 기능
- 사용자의 입력을 OpenAI API에 전송
- 응답을 받아 UI에 출력
- 채팅 메시지를 실시간으로 추가
- 간단한 에러 핸들링 포함


## 📁 프로젝트 구조
    Assets/

        ├── Scripts/

        │ └── MyGPT.cs # GPT API와 연결 및 채팅 처리

        ├── Prefabs/

        │ └── ChatMessage.prefab # 대화 메시지 프리팹

        ├── Scenes/

        │ └── APITest.unity # 테스트용 메인 씬



## 🧪 사용 방법
1. **OpenAI API 키 발급**  
   - [https://platform.openai.com](https://platform.openai.com) 에서 API 키를 발급받습니다.

2. **Unity에서 API 키 입력**  
   `MyGPT.cs` 스크립트 내 `apiKey` 변수에 키를 입력합니다.

   ```csharp
   private string apiKey = "Your Api-key";  // 여기에 API 키 입력
3. 씬 실행 (APITest)
   - Unity에서 APITest 씬을 실행합니다.
   - 채팅 입력창에 내용을 입력하고 전송하면 GPT의 응답을 받을 수 있습니다.


## ✅ 필요 조건
- Unity 2022.3 이상 (Unity 6 기준)
- TextMeshPro 설치
- OpenAI API Key

# 💬 Unity GPT Chat UI

Unity에서 OpenAI GPT API를 호출해 실시간 대화를 구현한 간단한 채팅 UI 구현입니다.
![화면 캡처 2025-06-19 193838](https://github.com/user-attachments/assets/c8f777e5-e27c-426b-b65a-05e1433bb068)





## 📦 프로젝트 소개
이 프로젝트는 Unity와 OpenAI GPT API를 활용하여, 사용자가 입력한 텍스트에 대해 GPT가 답변을 반환하는 **기본 채팅 시스템**입니다.
- Unity 6 환경에서 개발
- TextMeshPro 기반 UI 사용
- OpenAI GPT API 연동
- 프리팹 기반 메시지 동적 생성
  

## 🧩 주요 기능
- 사용자의 입력을 OpenAI API에 전송
- 응답을 받아 UI에 출력
- 채팅 메시지를 실시간으로 추가
- 간단한 에러 핸들링 포함


## 📁 프로젝트 구조
    Assets/

        ├── Scripts/

        │ └── MyGPT.cs # GPT API와 연결 및 채팅 처리

        ├── Prefabs/

        │ └── ChatMessage.prefab # 대화 메시지 프리팹

        ├── Scenes/

        │ └── APITest.unity # 테스트용 메인 씬



## 🧪 사용 방법
1. **OpenAI API 키 발급**  
   - [https://platform.openai.com](https://platform.openai.com) 에서 API 키를 발급받습니다.

2. **Unity에서 API 키 입력**  
   `MyGPT.cs` 스크립트 내 `apiKey` 변수에 키를 입력합니다.

   ```csharp
   private string apiKey = "sk-...";  // 여기에 API 키 입력
3. 씬 실행 (APITest)
   - Unity에서 APITest 씬을 실행합니다.
   - 채팅 입력창에 내용을 입력하고 전송하면 GPT의 응답을 받을 수 있습니다.


## ✅ 필요 조건
- Unity 2022.3 이상 (Unity 6 기준)
- TextMeshPro 설치
- OpenAI API Key
