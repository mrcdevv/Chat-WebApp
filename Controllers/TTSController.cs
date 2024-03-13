using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NAudio.Wave;

namespace tts.Controllers
{
    [ApiController]
    public class TTSController : ControllerBase
    {

        public IActionResult ConvertTextToSpeach([FromBody] string text)
        {
            try
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
                return File(audioBytes, "audio/wav");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al convertir texto a voz: {ex.Message}");
            }
        }

    }
}