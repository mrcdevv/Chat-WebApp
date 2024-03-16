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
                var audioBytes =
                return File(audioBytes, "audio/wav");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al convertir texto a voz: {ex.Message}");
            }
        }

    }
}