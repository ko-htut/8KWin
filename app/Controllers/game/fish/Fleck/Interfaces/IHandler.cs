using System.Collections.Generic;

namespace Fleck
{
    public interface IHandler
    {
        byte[] CreateHandshake(string subProtocol = null);
        void Receive(IEnumerable<byte> data);
        byte[] FrameText(string text);
        byte[] FrameBinary(byte[] bytes);
        byte[] FrameBinary(byte[] bytes, int start, int length);
        byte[] FramePing(byte[] bytes);
        byte[] FramePong(byte[] bytes);
        byte[] FrameClose(int code);
    }
}

