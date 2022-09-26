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

      var speechConfig = SpeechTranslationConfig.FromSubscription("eb5677582e83409cadbbd7a191f382f7", "brazilsouth");
      speechConfig.SpeechRecognitionLanguage = "pt-br";
      // speechConfig.AddTargetLanguage("en-US");
      var lang = new List<string>() { "en-US", "fr-FR", "es-AR" };
      lang.ForEach(speechConfig.AddTargetLanguage);
      var recognizer = new TranslationRecognizer(speechConfig);
      var result = await recognizer.RecognizeOnceAsync(); // await é utilizado para esperar por uma Promise.
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
