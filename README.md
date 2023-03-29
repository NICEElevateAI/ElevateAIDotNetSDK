<p align="center">
<img src="https://raw.githubusercontent.com/NICEElevateAI/NICEElevateAI/main/images/ElevateAI-blue-red-logo.png" />
</p>

<div align="center"><a name="menu"></a>
  <h4>
    <a href="https://www.elevateai.com">
      Website
    </a>
    <span> | </span>
    <a href="https://docs.elevateai.com">
      Documentation
    </a>
    <span> | </span>
    <a href="https://www.elevateai.com/blogs">
      Blog
    </a>
  </h4>
</div>

# .Net core 6 SDK for ElevateAI

[ElevateAI](https://www.elevateai.com) provides an API for Speech-to-text (ASR), behavioral analysis and sentiment analysis of voice interactions.

### Example
1. [Signup](https://app.elevateai.com) and retrieve API token from ElevateAI.
1. Declare an interaction. Provide a URI if you want ElevateAI to download the interaction via a Public URI.
2. Retrieve Interaction ID from JSON response and store.
3. Upload a file.
4. Check status every 30 seconds using Interaction ID until status returns 'processed' or an [error status](https://docs.elevateai.com/tutorials/check-the-processing-status).
5. Retrieve results - [phrase-by-phrase transcript](https://docs.elevateai.com/tutorials/get-phrase-by-phrase-transcript), [punctuated transcript](https://docs.elevateai.com/tutorials/get-punctuated-transcript), and [AI results](https://docs.elevateai.com/tutorials/get-cx-ai).

```c#
using ElevateAI.SDK;
using ElevateAI.SDK.Responses;


string token = "API-TOKEN";
string baseUrl = @"https://api.elevateai.com/v1/";
string langaugeTag = "en-us";
string vert = "default";
string transcriptionMode = "highAccuracy";
string localFilePath = @"\\my\localfile.wav";

//Step 1,2
var delcareResponse = ElevateAISDK.DeclareAudioInteraction(langaugeTag, vert, transcriptionMode, token, true, null, baseUrl);

//Step 3
var uploadResponse = ElevateAISDK.UploadFile(delcareResponse.InteractionIdentifier.Value.ToString(), token, localFilePath, baseUrl);


//Step 4
//Loop over status until processed
InteractionStatusResponse status = null;
while (true)
{
    status = ElevateAISDK.GetInteractionStatus(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
    if (status.InteractionStatus.status == "processed" || status.InteractionStatus.status == "fileUploadFailed" || status.InteractionStatus.status == "fileDownloadFailed" || status.InteractionStatus.status == "processingFailed")
    {
        break;
    }
    Thread.Sleep(30000);
}

//step 5
//get results after file is processed 
var puncTranscript = ElevateAISDK.GetInteractionPunctuatedTranscript(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var wordByWordTranscript = ElevateAISDK.GetInteractionWordByWordTranscript(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var aiResults = ElevateAISDK.GetAIResults(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);

```
