using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tts.Interfaces
{
    public interface ITextToSpeachService
    {
        public byte[] TextToSpeach(string text);
    }
}