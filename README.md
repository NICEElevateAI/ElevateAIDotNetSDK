# ElevateAI.SDK
#.Net core 6 SDK for ElevateAI

ElevateAI - the most afforable, accurate Speech-to-text (ASR) API. Free to use for hundreds of hours of audio per month!

Steps 
1. Declare an interaction (give a url if you want us to download)  
2. Store Interaction ID
3. Upload a file if no url using Interaction ID
4. Check status every 30 seconds using Interaction ID until status is 'processed' or an error status https://docs.elevateai.com/tutorials/check-the-processing-status
5. Retrieve results (transcripts, ai results) https://docs.elevateai.com/tutorials/get-phrase-by-phrase-transcript 

#Usage:

```
using ElevateAI.SDK;
using ElevateAI.SDK.Responces;


string token = "my token guid";
string baseUrl = @"https://api.elevateai.com/v1/";
string langaugeTag = "en-us";
string vert = "default1";
string transcriptionMode = "highAccuracy";
string localFilePath = @"\\my\localfile.wav";

//step 1, step 2
var DelcareResponse = ElevateAISDK.DeclareAudioInteraction(langaugeTag, vert, transcriptionMode, token, true, null, baseUrl);

//step 3
var uploadResponse = ElevateAISDK.UploadFile(DelcareResponse.InteractionIdentifier.Value.ToString(), token, localFilePath, baseUrl);


//step 4
//Loop over status until processed
InteractionStatusResponse status = null;
while (true)
{
    status = ElevateAISDK.GetInteractionStatus(DelcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
    if (status.InteractionStatus.status == "processed" || status.InteractionStatus.status == "fileUploadFailed" || status.InteractionStatus.status == "fileDownloadFailed" || status.InteractionStatus.status == "processingFailed")
    {
        break;
    }
    Thread.Sleep(30000);
}

//step 5
//get results after file is processed 
var puncTranscript = ElevateAISDK.GetInteractionPunctuatedTranscript(DelcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var wordByWordTranscript = ElevateAISDK.GetInteractionWordByWordTranscript(DelcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);
var aiResults = ElevateAISDK.GetAIResults(DelcareResponse.InteractionIdentifier.Value.ToString(), token, baseUrl);

```
