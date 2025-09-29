using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.VisualBasic;

namespace VoiceBotTG
{
    class SpeechToText
    {
        public async Task RecognizerOfVoice()
        {
            var config = SpeechConfig.FromSubscription("YourKey", "YourRegion");
            using var recognizer = new SpeechRecognizer(config);

            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine($"Распознано: {result.Text}");
        }
    }
}