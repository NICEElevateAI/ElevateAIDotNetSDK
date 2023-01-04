# ElevateAI.SDK
#.Net core 6 SDK for ElevateAI

#Easy to use SDK for ElevateAI 

#Usage:

```
using ElevateAI.SDK;


string token = "my token guid";
string baseUrl = @"https://api.elevateai.com/v1/";
string langaugeTag = "en-us";
string tModel = "highAccuracy";
string localFilePath = @"\\my\localfile.wav";

var DelcareResponse = ElevateAISDK.DeclareAudioInteraction(langaugeTag, "default", "highAccuracy", token, true, null, baseUrl);

var uploadResponse =ElevateAISDK.UploadFile(DelcareResponse.interactionIdentifier, token, localFilePath, baseUrl)



//Loop over status until processed
var status = ElevateAISDK.GetInteractionStatus(DelcareResponse.interactionIdentifier,token,baseUrl);

//get results after file is processed 
var puncTranscript = ElevateAISDK.GetInteractionPunctuatedTranscript(DelcareResponse.interactionIdentifier, token, baseUrl);
var wordByWordTranscript = ElevateAISDK.GetInteractionWordByWordTranscript(DelcareResponse.interactionIdentifier, token, baseUrl);
var aiResults = ElevateAISDK.GetAIResults(DelcareResponse.interactionIdentifier, token, baseUrl);

```
