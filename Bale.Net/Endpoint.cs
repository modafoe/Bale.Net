﻿namespace Bale.Net;

internal sealed class ApiEndpoint
{
    private readonly string _token;
    public ApiEndpoint(string token)
    {
        _token = token;
    }
    internal string GetUrl(Endpoint endpoint) => $"/bot{_token}" + endpoint switch
    {
        Endpoint.GetMe                 => "/getme",
        Endpoint.SendMessage           => "/sendMessage",
        Endpoint.EditMessage           => "/EditMessageText",
        Endpoint.DeleteMessage         => "/deleteMessage",
        Endpoint.SetWebHook            => "/setWebhook",
        Endpoint.DeleteWebHook         => "/deleteWebhook",
        Endpoint.GetUpdates            => "/getUpdates",
        Endpoint.GetChat               => "/getchat",
        Endpoint.GetChatAdministrators => "/getChatAdministrators",
        Endpoint.GetChatMembersCount   => "/getChatMembersCount",
        Endpoint.GetChatMember         => "/getChatMember",
        Endpoint.SendPhoto             => "/SendPhoto",
        Endpoint.SendAudio             => "/SendAudio",
        Endpoint.SendDocument          => "/SendDocument",
        Endpoint.SendVideo             => "/SendVideo",
        Endpoint.SendVoice             => "/SendVoice",
        Endpoint.SendLocation          => "/SendLocation",
        Endpoint.GetFile               => "/GetFile",
        Endpoint.SendInvoice           => "/SendInvoice",
        Endpoint.SendContact           => "/SendContact",
        Endpoint.ForwardMessage        => "/ForwardMessage",
        Endpoint.CopyMessage           => "/CopyMessage",
        Endpoint.LeaveChat             => "/LeaveChat",
        Endpoint.PinChatMessage        => "/PinChatMessage",
        Endpoint.UnPinChatMessage      => "/unPinChatMessage",
        _                              => throw new ArgumentException("invalid argument")
    };
}

internal enum Endpoint
{
    GetMe,
    SendMessage,
    EditMessage,
    DeleteMessage,
    SetWebHook,
    DeleteWebHook,
    GetUpdates,
    GetChat,
    GetChatAdministrators,
    GetChatMembersCount,
    GetChatMember,
    SendPhoto,
    SendAudio,
    SendDocument,
    SendVideo,
    SendVoice,
    SendLocation,
    SendContact,
    GetFile,
    SendInvoice,
    None,
    ForwardMessage,
    CopyMessage,
    LeaveChat,
    PinChatMessage,
    UnPinChatMessage,
}