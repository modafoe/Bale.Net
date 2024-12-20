﻿using Bale.Net.Types;

namespace Bale.Net.Interfaces;

public interface IMessages
{
    /// <summary>
    /// send a message to a specific chat
    /// </summary>
    /// <param name="chatId">id of the chat</param>
    /// <param name="message">the text message</param>
    /// <param name="replyMarkup">optional- replay markup keyboard</param>
    /// <param name="replayToMessageId">optional- message id to replay</param>
    /// <returns>the sent message</returns>
    ValueTask<Message> SendMessageAsync(ChatId chatId, string message, ReplyMarkup? replyMarkup = null, long replayToMessageId = 0);
    /// <summary>
    /// edit a text message or remove the replay markup keyboard from the message
    /// </summary>
    /// <param name="chatId">id of the chat</param>
    /// <param name="messageId">id of the message to edit</param>
    /// <param name="message">new text message</param>
    /// <param name="replyMarkup">new replay markup keyboard (pass null to remove the keyboard)</param>
    /// <returns>the new edited message</returns>
    ValueTask<EditMessage> EditMessageTextAsync(ChatId chatId, long messageId, string message, ReplyMarkup? replyMarkup = null);
    ValueTask<bool> PinChatMessageAsync(ChatId chatId, long messageId);
    ValueTask<bool> UnPinChatMessageAsync(ChatId chatId, long messageId);
    /// <summary>
    /// forward a message to the target chat
    /// </summary>
    /// <param name="chatId">the destination chat</param>
    /// <param name="fromChatId">the source chat</param>
    /// <param name="msgId">id of the message to be forwarded</param>
    /// <returns>the forwarded message</returns>
    ValueTask<Message> ForwardMessageAsync(ChatId chatId, ChatId fromChatId, long msgId);

    /// <summary>
    /// same as ForwardMessage but it doesnt reveal the original author of the message
    /// </summary>
    /// <param name="chatId">the destination chat</param>
    /// <param name="fromChatId">the source chat</param>
    /// <param name="msgId">id of the message to be copied</param>
    /// <returns>the copied message</returns>
    ValueTask<Message> CopyMessageAsync(ChatId chatId, ChatId fromChatId, long msgId);

    /// <summary>
    /// delete a message from a chat
    /// </summary>
    /// <param name="chatId">id of the chat</param>
    /// <param name="messageId">message id</param>
    /// <returns>returns true if the message was deleted</returns>
    ValueTask<bool> DeleteMessageAsync(ChatId chatId, long messageId);
}