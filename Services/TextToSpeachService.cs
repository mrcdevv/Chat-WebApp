using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Speech;
using GTranslate;
using System.Speech.Synthesis;
using NAudio.Wave;
using tts.Interfaces;

namespace tts.Services
{
    public class TextToSpeachService : ITextToSpeachService
    {
        public void GetAvailableVoices()
        {
        }

        public byte[] TextToSpeach(string text)
        {
            // Sintetizar voz utilizando System.Speech.Synthesis
            var synthesizer = new SpeechSynthesizer();
            var stream = new MemoryStream();
            synthesizer.SetOutputToWaveStream(stream);
            synthesizer.Speak(text);
            stream.Position = 0;

            // Convertir el audio a formato WAV utilizando NAudio
            var inputStream = new WaveFileReader(stream);
            var outputStream = new MemoryStream();
            WaveFileWriter.WriteWavFileToStream(outputStream, inputStream);

            // Devolver el archivo de audio generado
            byte[] audioBytes = outputStream.ToArray();
            return audioBytes;
        }

    }
}