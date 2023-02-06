﻿using System.Text.Json;
using Bale.Net.Interfaces;
using Bale.Net.Types;

namespace Bale.Net.Implementations;

public class Attachments : IAttachments
{
    private readonly BaleClient _client;
    public Attachments(BaleClient client)
    {
        _client = client;
    }
    public async ValueTask<Message> SendPhotoAsync(long chatId, Media media, string? caption = null, long replayToMessageId = 0) =>
        await SendAttachmentAsync(Endpoint.SendPhoto, "photo", chatId, media, caption, replayToMessageId);
    public async ValueTask<Message> SendAudioAsync(long chatId, Media media, string? caption = null, long replayToMessageId = 0) =>
        await SendAttachmentAsync(Endpoint.SendAudio, "audio", chatId, media, caption, replayToMessageId);
    public async ValueTask<Message> SendDocumentAsync(long chatId, Media media, string? caption = null, long replayToMessageId = 0) =>
        await SendAttachmentAsync(Endpoint.SendDocument, "document", chatId, media, caption, replayToMessageId);
    
    private async ValueTask<Message> SendAttachmentAsync(Endpoint endpoint, string contentName, long chatId, Media media, string? caption = null, long replayToMessageId = 0)
    {
        var url = _client.ApiEndpoint.GetUrl(endpoint);
        url += $"?chat_id={chatId}";
        if (caption is not null)
            url += $"&caption={caption}";

        if (replayToMessageId is not 0)
            url += $"&reply_to_message_id={replayToMessageId}";

        var response = await _client.HttpClient.PostAsync(url, media.GetContent(contentName));
        var content = JsonSerializer.Deserialize<BaseApiResponse<Message>>(await response.Content.ReadAsStringAsync());

        if (content is null)
            throw new Exception("api failed to return any data,perhaps there are some internal errors");

        if (!content.Ok)
            throw new Exception($"Failed to send photo with error code:[{content.ErrorCode}],description:{content.Description}");

        return content.Result;
    }
}