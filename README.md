# Dotnet-Eventbus-Outbox-Pattern

# Contextos
- user
- post

## Thunder client

```json
{"client":"Thunder Client","collectionName":"event-outbox-pattern","dateExported":"2021-05-28T03:28:13.009Z","version":"1.1","folders":[],"requests":[{"containerId":"","sortNum":10000,"headers":[{"name":"Accept","value":"*/*"},{"name":"User-Agent","value":"Thunder Client (https://www.thunderclient.io)"}],"colId":"3353ebb4-219d-44ae-a422-9261f6c1367f","name":"get user","url":"{{url}}/api/user","method":"GET","modified":"2021-05-28T02:53:58.717Z","created":"2021-05-28T02:34:19.029Z","_id":"a7441494-8555-45bd-bd57-d8c9ffa3c933","tests":[]},{"containerId":"","sortNum":20000,"headers":[],"colId":"3353ebb4-219d-44ae-a422-9261f6c1367f","name":"post user","url":"{{url}}/api/user","method":"POST","modified":"2021-05-28T02:42:16.152Z","created":"2021-05-28T02:35:01.631Z","_id":"a39c9579-5dd2-4dfd-bf0f-6f254e4415e3","body":{"type":"json","raw":"{\n\"Name\":\"Flávia A. O. Celebrone\",\n\"Mail\":\"flavia.dessa@gmail.com\",\n\"OtherData\":\"oie oie oie\"\n}"},"tests":[]},{"containerId":"","sortNum":30000,"headers":[],"colId":"3353ebb4-219d-44ae-a422-9261f6c1367f","name":"put user","url":"{{url}}/api/user/2","method":"PUT","modified":"2021-05-28T02:53:56.450Z","created":"2021-05-28T02:42:33.682Z","_id":"3ca230f6-f337-4e69-b0db-884cf93b2962","body":{"type":"json","raw":"{\n    \"Name\":\"Flávia Celebrone\",\n    \"Mail\":\"flavia.dessa@gmail.com\",\n    \"OtherData\":\"oie oie oie 2\"\n}"},"tests":[]}]}
```