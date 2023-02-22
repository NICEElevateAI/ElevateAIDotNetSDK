# ElevateAI.SDK
#.Net core 6 SDK for ElevateAI

ElevateAI - the most afforable, accurate Speech-to-text (ASR) API. Free to use for hundreds of hours of audio per month!

Steps  - Pre Req: signup for a free account @ https://app.elevateai.com and retrieve your API token 
1. Declare an interaction (give a URI if you want ElevateAI to download the interaction via a Public URI)  
2. Store Interaction ID
3. Upload a file if no URI specified during declare using the Interaction ID
4. Check status every 30 seconds using Interaction ID until status is 'processed' or an error status https://docs.elevateai.com/tutorials/check-the-processing-status
5. Retrieve results (transcripts, ai results) https://docs.elevateai.com/tutorials/get-phrase-by-phrase-transcript 

#Usage:

```c#
using ElevateAI.SDK;
using ElevateAI.SDK.Responces;


string token = "my token guid";
string baseUrl = @"https://api.elevateai.com/v1/";
string langaugeTag = "en-us";
string vert = "default";
string transcriptionMode = "highAccuracy";
string localFilePath = @"\\my\localfile.wav";

//step 1, step 2
var delcareResponse = ElevateAISDK.DeclareAudioInteraction(langaugeTag, vert, transcriptionMode, token, true, null, baseUrl);

//step 3
var uploadResponse = ElevateAISDK.UploadFile(delcareResponse.InteractionIdentifier.Value.ToString(), token, localFilePath, baseUrl);


//step 4
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

//step 6
//get results after file is processed 
var puncTranscript = ElevateAISDK.GetInteractionPunctuatedTranscript(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var wordByWordTranscript = ElevateAISDK.GetInteractionWordByWordTranscript(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var aiResults = ElevateAISDK.GetAIResults(delcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);

```
