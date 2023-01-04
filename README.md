# ElevateAI.SDK
#.Net core 6 SDK for ElevateAI

#Easy to use SDK for ElevateAI 

Steps 
1. Declare an interaction (give a url if you want us to download)  
2. Store Interaction ID
3. Upload a file if no url using Interaction ID
4. Check status every 30 seconds using Interaction ID
5. Once status is 'processed' or an error status https://docs.elevateai.com/tutorials/check-the-processing-status
6. Retrieve results (transcripts, ai results) https://docs.elevateai.com/tutorials/get-phrase-by-phrase-transcript 

#Usage:

```
using ElevateAI.SDK;


string token = "my token guid";
string baseUrl = @"https://api.elevateai.com/v1/";
string langaugeTag = "en-us";
string tModel = "highAccuracy";
string localFilePath = @"\\my\localfile.wav";

//step 1, step 2
var DelcareResponse = ElevateAISDK.DeclareAudioInteraction(langaugeTag, "default", "highAccuracy", token, true, null, baseUrl);

//step 3
var uploadResponse =ElevateAISDK.UploadFile(DelcareResponse.interactionIdentifier, token, localFilePath, baseUrl)

//step 4, step5
//Loop over status until processed
var status = ElevateAISDK.GetInteractionStatus(DelcareResponse.interactionIdentifier,token,baseUrl);

//step 6
//get results after file is processed 
var puncTranscript = ElevateAISDK.GetInteractionPunctuatedTranscript(DelcareResponse.interactionIdentifier, token, baseUrl);
var wordByWordTranscript = ElevateAISDK.GetInteractionWordByWordTranscript(DelcareResponse.interactionIdentifier, token, baseUrl);
var aiResults = ElevateAISDK.GetAIResults(DelcareResponse.interactionIdentifier, token, baseUrl);

```
