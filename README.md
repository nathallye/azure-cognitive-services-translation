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
  
   4. **Criação da subscription ID:** No `Portal do Azure` vamos em `Criar um recurso(Create a resource)` em seguida buscaremos por `Cognitive Services` em seguida podemos criar clicando em `Create`.
    
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
    using System;
    using Microsoft.CognitiveServices.Speech;
    using Microsoft.CognitiveServices.Speech.Audio;

    namespace Mic
    {
      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("Hello, girl!");
          var config = SpeechConfig.FromSubscription("subscription_KEY 1", "subscription_Location/Region");
        }
      }
    }
    ```
