using ElevateAI.SDK.PunctuatedTranscriptResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateAI.SDK
{
    public static class Helper
    {
        public static string JoinUriSegments(string uri, params string[] segments)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return null;

            if (segments == null || segments.Length == 0)
                return uri;

            return segments.Aggregate(uri, (current, segment) => $"{current.TrimEnd('/')}/{segment.TrimStart('/')}");
        }
        public static HttpClientHandler GetClientHandler()
        {
            return new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false,

            };
        }
        public static HttpClient GetHttpClient(string token)
        {
            HttpClient client = new HttpClient(GetClientHandler());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);
            return client;
        }

    }
    /// <summary>
    /// Experiment: can we write the transcript as a WebVTT (standard subtitle format) fil?
    /// <see href="https://www.w3.org/TR/webvtt1/"/>
    /// WebVTT is supported by W3C and extends SRT
    /// <see href="https://docs.fileformat.com/video/srt/"/>
    /// <see href="https://dcmp.org/learn/603-captioning-key---speaker-identification"/>
    /// </summary>
    public static class WebVttWriter
    {
        public static string ConvertToWebVtt(PunctuatedTranscriptModel t)
        {
            return "WebVTT\r\n\r\n" +
                string.Join("\r\n\r\n",
                t.sentenceSegments.Select((segment, index) =>
                    $"{index}" +// this number line is optional. for archive we probably don't want it (less clutter. cleaner file)
                    $"\r\n{segment.startTimeOffset.AsSrtString()} --> {segment.endTimeOffset.AsSrtString()}" +
                    $"\r\n<v Speaker#{segment.participant}>" +
                    $" {segment.phrase}"));
        }
        /// <summary>
        /// format does not support days and required a `,` as separator.
        /// </summary>
        /// <returns></returns>
        private static string AsSrtString(this int milliseconds)
        {
            var span = TimeSpan.FromMilliseconds(milliseconds);
            return $"{(int)span.TotalHours:D2}:{span.Minutes:D2}:{span.Seconds:D2}.{span.Milliseconds}";
        }
    }


}
