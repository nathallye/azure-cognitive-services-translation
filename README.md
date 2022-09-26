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

  namespace Mic
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
