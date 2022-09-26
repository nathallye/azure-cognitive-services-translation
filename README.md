# Aplicativo de tradução usando os Serviços Cognitivos da Microsoft

## Tradução

- Uso do serviço de tradução de texto; 
- Uso de tradução de fala, podendo traduzir para mais de um idioma simultaneamente.
  Bonjour -> Olá
  Olá -> Hola/こんにちは
  
## Criação do projeto - no Visual Studio

  1. O primeiro passo foi iniciar um projeto simples de console:
  
  ``` C#
  using System;

  namespace Translate
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
      }
    }
  }
  ```
  
  2. Feito isso, precisamos instalar o pacote `Microsoft.CognitiveServices.Speech`, podemos fazer isso usando o comando a seguir:

  ```
  Install-Package Microsoft.CognitiveServices.Speech
  ```
  
  Ou, seguindo os passos seguintes: `Projeto` > `Gerenciar pacotes do NuGet...` > `Procurar` > `Microsoft.CognitiveServices.Speech` > `Instalar`.

  3. Concluído a instalação do pacote conseguimos usá-lo no projeto:
  
  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
      }
    }
  }
  ```

  4. Vamos mudar o método de `static void Main` para `static assyn Task Main` para trabalharmos com os métodos assíncronos da biblioteca `CognitiveServices`:

  ``` C#
  using System;
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");
      }
    }
  }
  ```
  
  5. **Criação da subscription ID:** No `Portal do Azure` vamos em `Criar um recurso(Create a resource)` em seguida buscaremos por `Cognitive Services` em seguida podemos criar clicando em `Create`.
    
  - Concluído os passos acima iremos para a tela de `Create Cognitive Services` na seção `Basics` e preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192127942-a3cee6d1-ec98-4503-9767-be173c2efec3.png)

  - Em seguida, na seção `Identity` preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192128011-4791f51b-2857-475f-92df-6f91c51812a9.png)

  - Na seção `Tags` preencheremos os campos da forma seguinte:

    ![image](https://user-images.githubusercontent.com/86172286/192128035-54e95c48-f021-43f6-b659-4881621bee07.png)

  - Por fim, em `Review + Create` podemos revisão as informações e criar esse recurso clicando em `Create`.

  - Depois que o recurso for provisionado aparecerá a mensagem `Your deployment is complete` e podemos acessar esse recurso clicando em `Go to resource`.

    ![image](https://user-images.githubusercontent.com/86172286/192128144-255a4e2c-dbf8-4139-b8a2-9b721b7ba959.png)

  - Agora em `Keys and Endpoint(Chaves e Ponto de Extremidade)`, conseguimos encontrar a chave da assinatura para inserirmos no código no Visual Studio  

    ![image](https://user-images.githubusercontent.com/86172286/192128224-1c156b3d-ae11-4c15-b23c-e83e56904998.png)

    ``` C#
    using Microsoft.CognitiveServices.Speech;
    using Microsoft.CognitiveServices.Speech.Audio;
    using Microsoft.CognitiveServices.Speech.Translation;

    namespace Translate
    {
      class Program
      {
        static async Task Main(string[] args)
        {
          Console.WriteLine("Hello, girl!");

          var speechConfig = SpeechTranslationConfig.FromSubscription("subscription_KEY 1", "subscription_Location/Region");
        }
      }
    }
    ```

  6. Em seguida, iremos definir a linguagem padrão do nosso projeto:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
      }
    }
  }
  ```

  7. A priori, iremos definir que nossa aplicação irá traduzir para um único idioma:
  
  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        speechConfig.AddTargetLanguage("en-US");
      }
    }
  }
  ```

  8. Precisamos reconhecer qual linguagem que está indo a nossa tradução, então nesse caso, uma vez que definimos a linguagem vamos trabalhar com a tradução que precisamos reconhecer/`recognizer`.
  Para isso, vamos criar uma nova instância de `TranslationRecognizer` passando o passando o `speechConfig` que contém as informações do id subscription, da linguagem padrão e para qual idioma iremos traduzir:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        speechConfig.AddTargetLanguage("en-US");
        var recognizer = new TranslationRecognizer(speechConfig);
      }
    }
  }
  ```

  9. E para capturarmos esse resultado de forma assíncrona vamos armazenar dentro da variável `result` a promise retornada do `recognizer`:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        speechConfig.AddTargetLanguage("en-US");
        var recognizer = new TranslationRecognizer(speechConfig);
        var result = await recognizer.RecognizeOnceAsync(); // await é utilizado para esperar por uma Promise.
      }
    }
  }
  ```

  10. Em seguida, iremos fazer uma verificação se o `result` é uma tradução de `fala`, se verdadeiro, é retornado no resultado um objeto de chave/valor,então será necessário um `forEach` para percorrer a chave e valor desse item que está dentro de `result.Translations` e exibir no console:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        speechConfig.AddTargetLanguage("en-US");
        var recognizer = new TranslationRecognizer(speechConfig);
        var result = await recognizer.RecognizeOnceAsync(); 
        if (result.Reason == ResultReason.TranslatedSpeech)
          {
            foreach (var item in result.Translations)
            {
              Console.WriteLine($"{item.Key}: {item.Value}");
            }
          }
      }
    }
  }
  ```

  11. E para ele depois que exibir o console continue esperando "na linha" ao invés de encerrar a aplicação vamos usar o `ReadKey`:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        speechConfig.AddTargetLanguage("en-US");
        var recognizer = new TranslationRecognizer(speechConfig);
        var result = await recognizer.RecognizeOnceAsync(); 
        if (result.Reason == ResultReason.TranslatedSpeech)
          {
            foreach (var item in result.Translations)
            {
              Console.WriteLine($"{item.Key}: {item.Value}");
            }
          }
        
        Console.ReadKey();
      }
    }
  }
  ```

  12. Agora, conseguimos executar nossa aplicação e testar:
  
   ![image](https://user-images.githubusercontent.com/86172286/192175943-730b86a3-dd37-49cb-9938-f85039854ad8.png)

  13. Para configurarmos a tradução para mais de um idioma vamos criar uma lista/array de idiomas/`lang`, em seguida, iremos aplicar o método `ForEach` "em cima" desse array e adicionar cada item/cada language dentro do `speechConfig.AddTargetLanguage`:

  ``` C#
  using Microsoft.CognitiveServices.Speech;
  using Microsoft.CognitiveServices.Speech.Audio;
  using Microsoft.CognitiveServices.Speech.Translation;

  namespace Translate
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        Console.WriteLine("Hello, girl!");

        var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
        speechConfig.SpeechRecognitionLanguage = "pt-br";
        // speechConfig.AddTargetLanguage("en-US");
        var lang = new List<string>() { "en-US", "fr-FR", "es-AR" };
        lang.ForEach(speechConfig.AddTargetLanguage);
        
        var recognizer = new TranslationRecognizer(speechConfig);
        var result = await recognizer.RecognizeOnceAsync(); 
        if (result.Reason == ResultReason.TranslatedSpeech)
          {
            foreach (var item in result.Translations)
            {
              Console.WriteLine($"{item.Key}: {item.Value}");
            }
          }
        
        Console.ReadKey();
      }
    }
  }
  ```
  
  ![image](https://user-images.githubusercontent.com/86172286/192176607-e1d1727a-1bf2-4086-bb44-641cdad8272b.png)


  
