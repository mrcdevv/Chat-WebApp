using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NAudio.Wave;
using tts.Interfaces;
using tts.Services;

namespace tts.Controllers
{
    [ApiController]
    public class TTSController : ControllerBase
    {
        private readonly ITextToSpeachService _service;

        public TTSController(ITextToSpeachService service)
        {
            _service = service;
        }

        public IActionResult ConvertTextToSpeach([FromBody] string text)
        {
            try
            {
                var audioBytes = _service.TextToSpeach(text);
                return File(audioBytes, "audio/wav");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al convertir texto a voz: {ex.Message}");
            }
        }

    }
}