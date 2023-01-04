using ElevateAI.SDK.AIResults;
using ElevateAI.SDK.ChatData;
using ElevateAI.SDK.PunctuatedTranscriptResult;
using ElevateAI.SDK.Responces;
using ElevateAI.SDK.TranscriptResults;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ElevateAI.SDK
{
    public static class ElevateAISDK
    {
        private static string JoinUriSegments(string uri, params string[] segments)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return null;

            if (segments == null || segments.Length == 0)
                return uri;

            return segments.Aggregate(uri, (current, segment) => $"{current.TrimEnd('/')}/{segment.TrimStart('/')}");
        }

        /// <summary>
        /// Declares an interaction to the ElevateAI API. See https://docs.elevateai.com for detailed parameter options 
        /// </summary>
        /// <param name="languageTag">ex: en</param>
        /// <param name="verticle">ex: default</param>
        /// <param name="transcriptionMode">ex: highAccuracy</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="includeAIResults"></param>
        /// <param name="downloadURL">URL to fetch media files. Leave Null if uploading local file.</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>DeclareInteractionResponse (Contains the Interaction Identifier), see HttpResponseMessage for status code</returns>
        public static DeclareInteractionResponse DeclareAudioInteraction(string languageTag, string verticle, string transcriptionMode, string token, bool includeAIResults, Uri? downloadURL, string elevateAIBaseUrl)
        {
            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions");

            Interaction downloadCommand = new Interaction()
            {
                languageTag = languageTag,
                audioTranscriptionMode = transcriptionMode,
                type = "audio",
                includeAiResults = includeAIResults,
                vertical = verticle,
                downloadUri = downloadURL

            };

            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false,


            };
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);

            var mediaDeclaration = System.Text.Json.JsonSerializer.Serialize(downloadCommand);
            var content = new StringContent(mediaDeclaration, Encoding.UTF8, "application/json");
            var response = client.PostAsync(declareUrl, content);

            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {
          
                return new DeclareInteractionResponse
                {

                    HttpResponseMessage = response.Result,
                    InteractionIdentifier = null
                };
            }

            var contentWait = response.Result.Content.ReadAsStringAsync();
            InteractionDeclareResponse interactionDeclareResponse = JsonConvert.DeserializeObject<InteractionDeclareResponse>(contentWait.Result);
            contentWait.Wait();

            DeclareInteractionResponse result = new DeclareInteractionResponse
            {

                HttpResponseMessage = response.Result,
                InteractionIdentifier = Guid.Parse(interactionDeclareResponse.interactionIdentifier)
            };

            return result;

        }


        /// <summary>
        /// Declares a chat interaction to the ElevateAI API. See https://docs.elevateai.com for detailed parameter options 
        /// </summary>
        /// <param name="languageTag">ex: en</param>
        /// <param name="verticle">ex: default</param>
        /// <param name="transcriptionMode">ex: highAccuracy</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="includeAIResults"></param>
        /// <param name="chat">Chat model</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>DeclareInteractionResponse (Contains the Interaction Identifier), see HttpResponseMessage for status code</returns>
        public static DeclareInteractionResponse DeclareChatInteraction(string languageTag, string verticle, string transcriptionMode, string token, bool includeAIResults, ChatModel chat, string elevateAIBaseUrl)
        {
            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions");

            Interaction downloadCommand = new Interaction()
            {
                languageTag = languageTag,
                audioTranscriptionMode = transcriptionMode,
                type = "chat",
                includeAiResults = includeAIResults,
                vertical = verticle,
                chat = chat

            };

            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false,


            };
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);

            var mediaDeclaration = System.Text.Json.JsonSerializer.Serialize(downloadCommand);
            var content = new StringContent(mediaDeclaration, Encoding.UTF8, "application/json");
            var response = client.PostAsync(declareUrl, content);

            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new DeclareInteractionResponse
                {

                    HttpResponseMessage = response.Result,
                    InteractionIdentifier = null
                };
            }

            var contentWait = response.Result.Content.ReadAsStringAsync();
            InteractionDeclareResponse interactionDeclareResponse = JsonConvert.DeserializeObject<InteractionDeclareResponse>(contentWait.Result);
            contentWait.Wait();

            DeclareInteractionResponse result = new DeclareInteractionResponse
            {

                HttpResponseMessage = response.Result,
                InteractionIdentifier = Guid.Parse(interactionDeclareResponse.interactionIdentifier)
            };

            return result;

        }

        /// <summary>
        /// Declares a ThirdPartyTranscript interaction to the ElevateAI API. See https://docs.elevateai.com for detailed parameter options 
        /// </summary>
        /// <param name="languageTag">ex: en</param>
        /// <param name="verticle">ex: default</param>
        /// <param name="transcriptionMode">ex: highAccuracy</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="includeAIResults"></param>
        /// <param name="transcript">Transcript model</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>DeclareInteractionResponse (Contains the Interaction Identifier), see HttpResponseMessage for status code</returns>
        public static DeclareInteractionResponse DeclareThirdPartyTranscriptInteraction(string languageTag, string verticle, string transcriptionMode, string token, bool includeAIResults, TranscriptModel transcript, string elevateAIBaseUrl)
        {
            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions");

            Interaction downloadCommand = new Interaction()
            {
                languageTag = languageTag,
                audioTranscriptionMode = transcriptionMode,
                type = "transcript",
                includeAiResults = includeAIResults,
                vertical = verticle,
                transcript = transcript

            };

            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false,


            };
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);

            var mediaDeclaration = System.Text.Json.JsonSerializer.Serialize(downloadCommand);
            var content = new StringContent(mediaDeclaration, Encoding.UTF8, "application/json");
            var response = client.PostAsync(declareUrl, content);

            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new DeclareInteractionResponse
                {

                    HttpResponseMessage = response.Result,
                    InteractionIdentifier = null
                };
            }

            var contentWait = response.Result.Content.ReadAsStringAsync();
            InteractionDeclareResponse interactionDeclareResponse = JsonConvert.DeserializeObject<InteractionDeclareResponse>(contentWait.Result);
            contentWait.Wait();

            DeclareInteractionResponse result = new DeclareInteractionResponse
            {

                HttpResponseMessage = response.Result,
                InteractionIdentifier = Guid.Parse(interactionDeclareResponse.interactionIdentifier)
            };

            return result;

        }

        /// <summary>
        /// Fetches the Status of an interaction. See https://docs.elevateai.com for detailed parameter options 
        /// </summary>
        /// <param name="interactionId">Interaction Identifier generated from Declare Interaction</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>InteractionStatusResponse, see HttpResponseMessage for status code</returns>
        public static InteractionStatusResponse GetInteractionStatus(string interactionId, string token, string elevateAIBaseUrl)
        {
            var statusUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions/{0}/status");

            var startTime = DateTime.Now;
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false
            };
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);


            var response = client.GetAsync(string.Format(statusUrl, interactionId));
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new InteractionStatusResponse
                {

                    HttpResponseMessage = response.Result,
                    InteractionStatus = null
                };
            }
            var contentWait = response.Result.Content.ReadAsStringAsync();
            InteractionStatus interactionStatus = JsonConvert.DeserializeObject<InteractionStatus>(contentWait.Result);
            contentWait.Wait();
            var totalMs = DateTime.Now - startTime;
            InteractionStatusResponse result = new InteractionStatusResponse
            {
                HttpResponseMessage = response.Result,
                InteractionStatus = interactionStatus
            };

            return result;

        }

        /// <summary>
        /// Fetches the word-by-word transcript. See https://docs.elevateai.com for details
        /// </summary>
        /// <param name="interactionId">Interaction Identifier generated from Declare Interaction</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>TranscriptResponse, see HttpResponseMessage for status code</returns>
        public static TranscriptResponse GetInteractionWordByWordTranscript(string interactionId, string token, string elevateAIBaseUrl)
        {

            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions/{0}/transcript");
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false
            };
            HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);


            var response = client.GetAsync(string.Format(declareUrl, interactionId));
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new TranscriptResponse
                {

                    HttpResponseMessage = response.Result,
                    Transcript = null
                };
            }
            var contentWait = response.Result.Content.ReadAsStringAsync();
            TranscriptModel transcriptModel = JsonConvert.DeserializeObject<TranscriptModel>(contentWait.Result);
            contentWait.Wait();
            TranscriptResponse result = new TranscriptResponse
            {

                HttpResponseMessage = response.Result,
                Transcript = transcriptModel
            };

            return result;

        }
      
        /// <summary>
        /// Fetches the punctuated transcript. See https://docs.elevateai.com for details
        /// </summary>
        /// <param name="interactionId">Interaction Identifier generated from Declare Interaction</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>PunctuatedTranscriptResponse, see HttpResponseMessage for status code</returns>
        public static PunctuatedTranscriptResponse GetInteractionPunctuatedTranscript(string interactionId, string token, string elevateAIBaseUrl)
        {

            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions/{0}/transcripts/punctuated");
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false
            };
            HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);


            var response = client.GetAsync(string.Format(declareUrl, interactionId));
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new PunctuatedTranscriptResponse
                {

                    HttpResponseMessage = response.Result,
                    Transcript = null
                };
            }
            var contentWait = response.Result.Content.ReadAsStringAsync();
            PunctuatedTranscriptModel transcriptModel = JsonConvert.DeserializeObject<PunctuatedTranscriptModel>(contentWait.Result);
            contentWait.Wait();
            PunctuatedTranscriptResponse result = new PunctuatedTranscriptResponse
            {

                HttpResponseMessage = response.Result,
                Transcript = transcriptModel
            };

            return result;

        }
      
        /// <summary>
        /// Fetches AI Results. See https://docs.elevateai.com for details
        /// </summary>
        /// <param name="interactionId">Interaction Identifier generated from Declare Interaction</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns>AiResponse, see HttpResponseMessage for status code</returns>
        public static AIResponse GetAIResults(string interactionId, string token, string elevateAIBaseUrl)
        {

            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions/{0}/ai");
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false
            };
            HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("X-API-TOKEN", token);


            var response = client.GetAsync(string.Format(declareUrl, interactionId));
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {

                return new AIResponse
                {

                    HttpResponseMessage = response.Result,
                    AIResults = null
                };
            }
            var contentWait = response.Result.Content.ReadAsStringAsync();
            AIModel aiModel = JsonConvert.DeserializeObject<AIModel>(contentWait.Result);
            contentWait.Wait();
            AIResponse result = new AIResponse
            {

                HttpResponseMessage = response.Result,
                AIResults = aiModel
            };

            return result;

        }

        /// <summary>
        ///  Uploads a local file to The ElevateAIAPI  See https://docs.elevateai.com for details
        /// </summary>
        /// <param name="interactionId">Interaction Identifier generated from Declare Interaction</param>
        /// <param name="token">Your API token acquired from https://app.elevateai.com</param>
        /// <param name="filePath">Local file path</param>
        /// <param name="elevateAIBaseUrl">Base ElevateAI URL ex: https://api.elevateai.com/v1/</param>
        /// <returns></returns>
        public static HttpResponseMessage UploadFile(string interactionId, string token,  string filePath,string elevateAIBaseUrl)
        {
            var declareUrl = JoinUriSegments(elevateAIBaseUrl, "/interactions/{0}/upload");
            ServicePointManager.MaxServicePointIdleTime = 10000;
  
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                AllowAutoRedirect = false
            };

            HttpClient _httpClient = new HttpClient(clientHandler);


            _httpClient.DefaultRequestHeaders.Add("X-API-TOKEN", token);
            var formContent = new MultipartFormDataContent();

            var FilePath = filePath;

            formContent.Add(new StreamContent(File.OpenRead(FilePath)), "files", Path.GetFileName(FilePath));

            _httpClient.BaseAddress = new Uri(declareUrl);

            var response = _httpClient.PostAsync(string.Format(declareUrl, interactionId), formContent);
            response.Wait();
            return response.Result;


        }
    }

}